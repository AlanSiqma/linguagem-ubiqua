using System.Diagnostics.CodeAnalysis;
using ToolBoxDeveloper.DomainContext.Domain.Contracts.Settings;

namespace ToolBoxDeveloper.DomainContext.Domain.Settings
{
    [ExcludeFromCodeCoverage]
    public class DatabaseSettings : IDatabaseSettings
    {
        public string CollectionName { get; set; } = string.Empty;

        public string ConnectionString { get; set; } = string.Empty;

        public string DatabaseName { get; set; } = string.Empty;
    }
}
