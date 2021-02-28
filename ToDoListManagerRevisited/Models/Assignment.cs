using System;
using System.Collections.Generic;

namespace ToDoListManagerRevisited.Models
{
    public partial class Assignment
    {
        public int AssignmentId { get; set; }
        public DateTime AssignmentDueDate { get; set; }
        public string AssignmentDescription { get; set; }
        public bool AssignmentCompletionStatus { get; set; }
        public string AssignedUserName { get; set; }

        public virtual AspNetUsers AssignedUserNameNavigation { get; set; }
    }
}
