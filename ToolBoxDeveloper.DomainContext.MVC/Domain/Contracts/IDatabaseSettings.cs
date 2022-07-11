namespace ToolBoxDeveloper.DomainContext.MVC.Domain.Contracts
{
    public interface IDatabaseSettings
    {
        string CollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
