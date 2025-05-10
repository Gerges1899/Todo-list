using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoListApp.enums;

namespace TodoListApp.Todo
{
    public class CreateTodoDto
    {
        [System.Text.Json.Serialization.JsonIgnore]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }

        public Status Status { get; set; }

        public Priority Priority { get; set; }

        public DateTime? DueDate { get; set; }
    }
}
