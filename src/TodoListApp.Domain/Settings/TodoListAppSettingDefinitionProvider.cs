using Volo.Abp.Settings;

namespace TodoListApp.Settings;

public class TodoListAppSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(TodoListAppSettings.MySetting1));
    }
}
