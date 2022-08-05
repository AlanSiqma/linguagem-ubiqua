using System.Diagnostics.CodeAnalysis;
using ToolBoxDeveloper.DomainContext.Domain.Contracts;

namespace ToolBoxDeveloper.DomainContext.Domain.Settings
{
    [ExcludeFromCodeCoverage]
    public class DatabaseSettings : IDatabaseSettings
    {
        public string CollectionName { get; set; }

        public string ConnectionString { get; set; }

        public string DatabaseName { get; set; }
    }
}
