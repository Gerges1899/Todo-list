using Volo.Abp.Modularity;

namespace TodoListApp;

public abstract class TodoListAppApplicationTestBase<TStartupModule> : TodoListAppTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
