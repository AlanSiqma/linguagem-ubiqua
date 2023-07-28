namespace Devtoolkit.LinguagemUbiqua.Domain.Contracts.Settings
{
    public interface IDatabaseSettings
    {
        string CollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
