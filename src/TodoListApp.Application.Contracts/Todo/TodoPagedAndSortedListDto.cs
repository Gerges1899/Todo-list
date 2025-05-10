using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace TodoListApp.Todo
{
    public class TodoPagedAndSortedListDto : PagedAndSortedResultRequestDto
    {
        public string? SearchText { get; set; }          
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
        public int? Status { get; set; } 
        public int? Priority { get; set; }
    }
}
