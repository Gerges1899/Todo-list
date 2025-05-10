using Xunit;

namespace TodoListApp.EntityFrameworkCore;

[CollectionDefinition(TodoListAppTestConsts.CollectionDefinitionName)]
public class TodoListAppEntityFrameworkCoreCollection : ICollectionFixture<TodoListAppEntityFrameworkCoreFixture>
{

}
