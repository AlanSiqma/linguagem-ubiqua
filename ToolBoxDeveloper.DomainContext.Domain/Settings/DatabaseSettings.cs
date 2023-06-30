using System.Diagnostics.CodeAnalysis;
using ToolBoxDeveloper.DomainContext.Domain.Contracts.Settings;

namespace ToolBoxDeveloper.DomainContext.Domain.Settings
{
    [ExcludeFromCodeCoverage]
    public class DatabaseSettings : IDatabaseSettings
    {
        ~DatabaseSettings()
        {
            this.CollectionName = null;
            this.ConnectionString = null;
            this.DatabaseName = null;
        }

        public string CollectionName { get; set; }

        public string ConnectionString { get; set; }

        public string DatabaseName { get; set; }
    }
}
