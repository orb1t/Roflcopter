using System.Diagnostics.CodeAnalysis;
using JetBrains.Application.Settings;
using JetBrains.ReSharper.Feature.Services.TodoItems;

namespace Roflcopter.Plugin.TodoItems
{
    [SettingsKey(typeof(TodoSettings), "TodoItemsCountSettings")]
    [SuppressMessage("ReSharper", "NotNullMemberIsNotInitialized")]
    public class TodoItemsCountSettings
    {
        [SettingsEntry(true, "Is enabled")]
        public bool IsEnabled { get; set; }

        [SettingsEntry("Bug\nTodo", "Definitions")]
        public readonly string Definitions;
    }
}