using Volo.Abp.Modularity;

namespace TodoListApp;

/* Inherit from this class for your domain layer tests. */
public abstract class TodoListAppDomainTestBase<TStartupModule> : TodoListAppTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
