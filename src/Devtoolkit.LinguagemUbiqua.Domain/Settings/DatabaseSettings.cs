using System.Diagnostics.CodeAnalysis;
using Devtoolkit.LinguagemUbiqua.Domain.Contracts.Settings;

namespace Devtoolkit.LinguagemUbiqua.Domain.Settings
{
    [ExcludeFromCodeCoverage]
    public class DatabaseSettings : IDatabaseSettings
    {
        public string CollectionName { get; set; } = string.Empty;

        public string ConnectionString { get; set; } = string.Empty;

        public string DatabaseName { get; set; } = string.Empty;
    }
}
