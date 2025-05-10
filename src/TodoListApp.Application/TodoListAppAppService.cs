using TodoListApp.Localization;
using Volo.Abp.Application.Services;

namespace TodoListApp;

/* Inherit your application services from this class.
 */
public abstract class TodoListAppAppService : ApplicationService
{
    protected TodoListAppAppService()
    {
        LocalizationResource = typeof(TodoListAppResource);
    }
}
