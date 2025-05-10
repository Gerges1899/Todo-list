using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TodoListApp.enums;

namespace TodoListApp.Todo
{
    public class UpdateTodoDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }

        public Status Status { get; set; }

        public Priority Priority { get; set; }

        public DateTime? DueDate { get; set; }
    }
}
