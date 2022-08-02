using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Diagnostics.CodeAnalysis;

namespace ToolBoxDeveloper.DomainContext.MVC.Domain.Entities.Base
{
    [ExcludeFromCodeCoverage]
    public class BaseEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
    }
}
