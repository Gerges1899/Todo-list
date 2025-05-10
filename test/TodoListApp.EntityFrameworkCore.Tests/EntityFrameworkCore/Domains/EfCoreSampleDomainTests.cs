using TodoListApp.Samples;
using Xunit;

namespace TodoListApp.EntityFrameworkCore.Domains;

[Collection(TodoListAppTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<TodoListAppEntityFrameworkCoreTestModule>
{

}
