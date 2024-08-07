﻿using CavisProject.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CavisProject.Domain.Entity
{
    public class Calendar : BaseEntity
    {
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
        public double? Duration { get; set; }
        public virtual ICollection<CalendarDetail>? CalendarDetails { get; set; }

    }
}
