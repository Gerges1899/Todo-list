using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoListApp.enums;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace TodoListApp.Todo
{
    public class TodoManager : DomainService
    {
        private readonly IRepository<Todo,Guid> _todoRepo;
        private readonly IReadOnlyRepository<Todo,Guid> _todoRoRepo;

        public TodoManager(IRepository<Todo,Guid> todoRepo, IReadOnlyRepository<Todo, Guid> todoRoRepo)
        {
            _todoRepo = todoRepo;
            _todoRoRepo = todoRoRepo;
        }

        public async Task<Todo> GetById(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new BusinessException(TodoListAppDomainErrorCodes.IdIsEmpty);
            }
            var query = await _todoRepo.GetAsync(id);
            if(query == null)
            {
                throw new BusinessException(TodoListAppDomainErrorCodes.TodoNotFound);
            }
            return query;
        }
        private async Task<ValidationResult> IsValidTodo(Todo input,bool isUpdate)
        {
            if (string.IsNullOrWhiteSpace(input.Title))
            {
                return new ValidationResult(false, TodoListAppDomainErrorCodes.TitleIsEmpty);
            }
            if (input.Title.Length > 100)
            {
                return new ValidationResult(false, TodoListAppDomainErrorCodes.TitleIsExceededLength);
            }
            return new ValidationResult(true, "");
        }
        public async Task<Todo> AddTodo(Todo input)
        {
            var isValid =await IsValidTodo(input,false);
            if (isValid.IsSucceed)
            {
                var newTodo = await _todoRepo.InsertAsync(input);
                return newTodo;
            }
            throw new BusinessException(isValid.ErrorCode);
        }
        public async Task<Todo> UpdateTodo(Todo input,Guid id)
        {
            var todo = await GetById(id);
            var isValid = await IsValidTodo(input, true);
            if (isValid.IsSucceed)
            {
                todo = todo.SetValues(input.Title, input.Description, input.Status, input.Priority, input.DueDate);
                var newTodo = await _todoRepo.UpdateAsync(todo);
                return newTodo;
            }
            throw new BusinessException(isValid.ErrorCode);
        }
        public async Task DeleteTodo(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new BusinessException(TodoListAppDomainErrorCodes.IdIsEmpty);
            }
            var query = await GetById(id);
            if (query == null)
            {
                throw new BusinessException(TodoListAppDomainErrorCodes.TodoNotFound);
            }
            try
            {
                await _todoRepo.DeleteAsync(id);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public async Task<IQueryable<Todo>> GetTodoList(string? searchText,DateTime? From,DateTime? To,string sortBy,int? status,int? priority)
        {
            var query = from Todo in await _todoRoRepo.GetQueryableAsync()
                        where( string.IsNullOrWhiteSpace(searchText) || Todo.Title.ToLower().Contains(searchText.ToLower())) &&
                        (!status.HasValue || Todo.Status == (Status)status.Value) &&
                        (!priority.HasValue || Todo.Priority == (Priority)priority.Value) &&
                        (!From.HasValue || Todo.DueDate >= From) &&
                        (!To.HasValue || Todo.DueDate <= To) select Todo;

            if (!string.IsNullOrWhiteSpace(sortBy))
            {
                switch (sortBy)
                {
                    case "Status":
                        query = query.OrderByDescending(x => x.Status); break;
                    case "Priority":
                        query = query.OrderByDescending(x => x.Priority); break;
                    default:
                        query = query.OrderByDescending(x => x.CreationTime); break;
                }
            }
            return query;

        }
    }
}
