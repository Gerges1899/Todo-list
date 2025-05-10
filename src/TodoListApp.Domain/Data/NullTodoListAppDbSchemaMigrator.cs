using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace TodoListApp.Data;

/* This is used if database provider does't define
 * ITodoListAppDbSchemaMigrator implementation.
 */
public class NullTodoListAppDbSchemaMigrator : ITodoListAppDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
