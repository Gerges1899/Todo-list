using TodoListApp.Samples;
using Xunit;

namespace TodoListApp.EntityFrameworkCore.Applications;

[Collection(TodoListAppTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<TodoListAppEntityFrameworkCoreTestModule>
{

}
