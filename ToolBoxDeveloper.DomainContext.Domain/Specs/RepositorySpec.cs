using System;
using System.Linq.Expressions;
using ToolBoxDeveloper.DomainContext.Domain.Entities.Base;

namespace ToolBoxDeveloper.DomainContext.Domain.Specs
{
    public static class RepositorySpec
    {
        public static Expression<Func<T, bool>> FindEntityById<T>(string id) where T : BaseEntity
        {
            return x => x.Id.Equals(id);
        }
    }
}
