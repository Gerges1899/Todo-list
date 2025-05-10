using Volo.Abp.Modularity;

namespace TodoListApp;

[DependsOn(
    typeof(TodoListAppApplicationModule),
    typeof(TodoListAppDomainTestModule)
)]
public class TodoListAppApplicationTestModule : AbpModule
{

}
