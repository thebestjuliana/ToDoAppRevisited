﻿using System;
using System.Collections.Generic;

namespace ToDoListManagerRevisited.Models
{
    public partial class Assignment
    {
        public int AssignmentId { get; set; }
        public DateTime AssignmentDueDate { get; set; }
        public string AssignmentDescription { get; set; }
        public bool? AssignmentCompletionStatus { get; set; } = false;
        public string UserId { get; set; }

        public virtual AspNetUsers User { get; set; }
    }
}
