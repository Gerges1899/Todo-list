using AutoMapper.Internal.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Guids;

namespace TodoListApp.Todo
{
    public class TodoService : ApplicationService
    {
        private readonly TodoManager _todoManager;
        private readonly IGuidGenerator _guidGenerator;
        public TodoService(TodoManager todoManager,IGuidGenerator guidGenerator)
        {
            _todoManager = todoManager;
            _guidGenerator = guidGenerator;
        }

        public async Task<ResponseAPI> GetById(Guid id)
        {
            var result = await _todoManager.GetById(id);
            return new ResponseAPI(true,"",result,"");
        }

        public async Task<ResponseAPI> AddTodo(CreateTodoDto input)
        {
            input.Id = _guidGenerator.Create();
            var todo = ObjectMapper.Map<CreateTodoDto, Todo>(input);
            var result = await _todoManager.AddTodo(todo);
            return new ResponseAPI(true, "", result, "");
        }

        public async Task<ResponseAPI> UpdateTodo(UpdateTodoDto input,Guid id)
        {
            var todo = ObjectMapper.Map<UpdateTodoDto, Todo>(input);
            var result = await _todoManager.UpdateTodo(todo,id);
            return new ResponseAPI(true, "", result, "");
        }

        public async Task<ResponseAPI> DeleteTodo(Guid id)
        {
            var result = _todoManager.DeleteTodo(id);
            return new ResponseAPI(true, "", true, "");
        }

        public async Task<ResponseAPI> GetTodoFilteredListAsync(TodoPagedAndSortedListDto filters)
        {
            var result = await _todoManager.GetTodoList(filters.SearchText, filters.From, filters.To,
                filters.Sorting, filters.Status, filters.Priority);

            var totalCount = await AsyncExecuter.CountAsync(result);
            var sortedList = await AsyncExecuter.ToListAsync(result);
            var pagedList = sortedList.Skip(filters.SkipCount).Take(filters.MaxResultCount).ToList();

            var finalresult = ObjectMapper.Map<List<Todo>, List<TodoDto>>(pagedList);
            return new ResponseAPI(true, "", new {TotalCount = totalCount,Items=finalresult}, "");


        }

    }
}
