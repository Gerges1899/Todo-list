using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TodoListApp.enums;
using Volo.Abp.Domain.Entities.Auditing;

namespace TodoListApp.Todo
{
    public class Todo : AuditedAggregateRoot<Guid>
    {
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        public string? Description { get; set; }

        public Status Status { get; set; }

        public Priority Priority { get; set; }

        public DateTime? DueDate { get; set; }

        public Todo SetValues(string title,string? description,Status status,Priority priority,DateTime? duedate) 
        {
            Title = title;
            Description = description; 
            Status = status;
            Priority = priority;
            DueDate = duedate;
            return this;
        }
    }
}
