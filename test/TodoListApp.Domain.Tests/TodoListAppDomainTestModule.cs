using Volo.Abp.Modularity;

namespace TodoListApp;

[DependsOn(
    typeof(TodoListAppDomainModule),
    typeof(TodoListAppTestBaseModule)
)]
public class TodoListAppDomainTestModule : AbpModule
{

}
