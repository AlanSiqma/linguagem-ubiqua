using System.Diagnostics.CodeAnalysis;
using ToolBoxDeveloper.DomainContext.MVC.Domain.Contracts;

namespace ToolBoxDeveloper.DomainContext.MVC.Domain.Settings
{
    [ExcludeFromCodeCoverage]
    public class DatabaseSettings : IDatabaseSettings
    {
        public string CollectionName { get; set; }

        public string ConnectionString { get; set; }

        public string DatabaseName { get; set; }
    }
}
