﻿using CavisProject.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CavisProject.Domain.Entity
{
    public class Appointment : BaseEntity
    {
        public string? Title { get; set; }
        public DateTime? Date { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string? PhoneNumber { get; set; }
        [ForeignKey("CalendarId")]
        public Guid? CalendarId { get; set; }
        public string? Email { get; set; }
        public AppointmentStatusEnum Status { get; set;}
        public virtual ICollection<AppointmentDetail>? AppointmentDetails { get; set; }
        public virtual ICollection<Transaction>? Transaction { get; set; }
    }
}
