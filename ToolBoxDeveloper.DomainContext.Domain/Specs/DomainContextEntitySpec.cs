using System;
using System.Linq.Expressions;
using ToolBoxDeveloper.DomainContext.Domain.Entities;

namespace ToolBoxDeveloper.DomainContext.Domain.Specs
{
    public static class DomainContextEntitySpec
    {
        public static Expression<Func<DomainContextEntity, bool>> FindEntityById(string id)
        {
            return x => x.Id.Equals(id);
        }
    }
}
