using CavisProject.Application.Commons;
using CavisProject.Application.Interfaces;
using CavisProject.Application.ViewModels.EmailViewModels;
using CavisProject.Domain.Entity;
using Microsoft.AspNetCore.Identity;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using MailKit.Net.Smtp;
using System.Text;
using System.Threading.Tasks;
using CavisProject.Application.ViewModels.RefreshTokenViewModels;
using CavisProject.Application.ViewModels.UserViewModels;
using FluentValidation.Results;
using FluentValidation;
using System.Data.Common;

namespace CavisProject.Application.Services
{
    public class EmailService : IEmailService
    {
        private EmailConfiguration _emailConfiguration;
        private readonly UserManager<User> _userManager;
        private readonly IValidator<UserResetPasswordModel> _validatorResetPassword;
        public EmailService(EmailConfiguration emailConfiguration, UserManager<User> userManager, IValidator<UserResetPasswordModel> validatorResetPassword)
        {
            _emailConfiguration = emailConfiguration;
            _userManager = userManager;
            _validatorResetPassword = validatorResetPassword;
        }

        public async Task<ApiResponse<bool>> SendOTPEmailAsync(string email)
        {
            var response = new ApiResponse<bool>();
            if (string.IsNullOrEmpty(email))
            {
                response.Data = false;
                response.isSuccess = true;
                response.Message = "Không được bỏ trống email!";
                return response;
            }

            string otp = new Random().Next(0, 1000000).ToString("D6");
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress
                ("CavisAppBeauty", _emailConfiguration.From));
            emailMessage.To.Add(new MailboxAddress
                (email, email));
            emailMessage.Subject = "Your OTP Code";
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Plain)
            {
                Text = $"Your OTP code is: {otp}"
            };

            using var client = new SmtpClient();
            try
            {
                var checkEmailExist = await _userManager.FindByEmailAsync(email);
                if (checkEmailExist == null)
                {
                    response.Data = false;
                    response.isSuccess = true;
                    response.Message = "Email không tồn tại!";
                    return response;
                }

                checkEmailExist.OTPEmail = otp;
                checkEmailExist.ExpireOTPEmail = DateTime.Now.AddSeconds(90);
                var checkUpdate = await _userManager.UpdateAsync(checkEmailExist);
                if (!checkUpdate.Succeeded)
                {
                    response.Data = false;
                    response.isSuccess = false;
                    response.Message = "Cannot update OTP email!";
                    return response;
                }
                await client.ConnectAsync(_emailConfiguration.SmtpServer, _emailConfiguration.Port, true);
                // Loại bỏ cơ chế xác thực XOAUTH2  MailKit.Security.SecureSocketOptions.StartTls
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                await client.AuthenticateAsync(_emailConfiguration.Username, _emailConfiguration.Password);
                await client.SendAsync(emailMessage);
                response.Data = true;
                response.isSuccess = true;
                response.Message = "OTP sent successfully.";
            }
            catch (Exception ex)
            {
                response.Data = false;
                response.isSuccess = false;
                response.Message = ex.Message;
            }
            finally
            {
                await client.DisconnectAsync(true);
                client.Dispose();
            }
            return response;
        }

        public async Task<ApiResponse<bool>> ResetPasswordAsync(string email, UserResetPasswordModel userResetPasswordModel)
        {
            var response = new ApiResponse<bool>();
            try
            {
                ValidationResult validationResult = await _validatorResetPassword.ValidateAsync(userResetPasswordModel);
                if (!validationResult.IsValid)
                {
                    response.isSuccess = false;
                    response.Message = string.Join(", ", validationResult.Errors.Select(error => error.ErrorMessage));
                    return response;
                }
                if (string.IsNullOrEmpty(email))
                {
                    response.Data = false;
                    response.isSuccess = false;
                    response.Message = "Email must not empty!";
                    return response;
                }
                var user = await _userManager.FindByEmailAsync(email);
                if (user == null)
                {
                    response.Data = false;
                    response.isSuccess = false;
                    response.Message = "Email is not exist!";
                    return response;
                }
                if (user.OTPEmail != userResetPasswordModel.OTP)
                {
                    response.Data = false;
                    response.isSuccess = true;
                    response.Message = "OTP không tồn tại!";
                    return response;
                }
                if (user.ExpireOTPEmail < DateTime.Now)
                {
                    response.Data = false;
                    response.isSuccess = true;
                    response.Message = "OTP đã hết hiệu lực!";
                    return response;
                }
                var resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
                var checkResetPassword = await _userManager.ResetPasswordAsync(user, resetToken, userResetPasswordModel.NewPassword);
                if (!checkResetPassword.Succeeded) {
                    response.Data = false;
                    response.isSuccess = false;
                    response.Message = "Reset password is fail!";
                    return response;
                }
                user.ExpireOTPEmail = null;
                user.OTPEmail = null;
                var checkUpdateUser = await _userManager.UpdateAsync(user);
                response.Data = true;
                response.isSuccess = true;
                response.Message = "Reset password is successful!";
                return response;
            }
            catch (DbException ex)
            {
                response.isSuccess = false;
                response.Message = ex.Message;
            }
            catch (Exception ex)
            {
                response.isSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
