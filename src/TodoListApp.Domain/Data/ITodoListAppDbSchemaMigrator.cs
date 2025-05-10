using System.Threading.Tasks;

namespace TodoListApp.Data;

public interface ITodoListAppDbSchemaMigrator
{
    Task MigrateAsync();
}
