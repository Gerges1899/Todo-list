using TodoListApp.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace TodoListApp.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(TodoListAppEntityFrameworkCoreModule),
    typeof(TodoListAppApplicationContractsModule)
)]
public class TodoListAppDbMigratorModule : AbpModule
{
}
