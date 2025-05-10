using TodoListApp.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace TodoListApp.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class TodoListAppController : AbpControllerBase
{
    protected TodoListAppController()
    {
        LocalizationResource = typeof(TodoListAppResource);
    }
}
