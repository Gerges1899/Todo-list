using Microsoft.Extensions.Localization;
using TodoListApp.Localization;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace TodoListApp;

[Dependency(ReplaceServices = true)]
public class TodoListAppBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<TodoListAppResource> _localizer;

    public TodoListAppBrandingProvider(IStringLocalizer<TodoListAppResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}
