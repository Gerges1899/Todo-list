using AutoMapper;
using TodoListApp.Todo;

namespace TodoListApp;

public class TodoListAppApplicationAutoMapperProfile : Profile
{
    public TodoListAppApplicationAutoMapperProfile()
    {
        CreateMap<Todo.Todo, TodoDto>();
        CreateMap<TodoDto, Todo.Todo>();

        CreateMap<CreateTodoDto, Todo.Todo>();
        CreateMap<Todo.Todo, CreateTodoDto>();

        CreateMap<UpdateTodoDto, Todo.Todo>();
        CreateMap<Todo.Todo, UpdateTodoDto>();
    }
}
