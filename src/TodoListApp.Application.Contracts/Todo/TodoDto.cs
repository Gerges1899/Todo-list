using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoListApp.enums;
using Volo.Abp.Application.Dtos;

namespace TodoListApp.Todo
{
    public class TodoDto : AuditedEntityDto<Guid>
    {
        public string Title { get; set; }
        public string? Description { get; set; }

        public Status Status { get; set; }

        public Priority Priority { get; set; }

        public DateTime? DueDate { get; set; }
    }
}
