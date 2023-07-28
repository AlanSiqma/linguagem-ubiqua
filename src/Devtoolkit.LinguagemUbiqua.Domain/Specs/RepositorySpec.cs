using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using Devtoolkit.LinguagemUbiqua.Domain.Entities.Base;

namespace Devtoolkit.LinguagemUbiqua.Domain.Specs
{
    [ExcludeFromCodeCoverage]
    public static class RepositorySpec
    {
        public static Expression<Func<T, bool>> FindEntityById<T>(string id) where T : BaseEntity
        {
            return x => x.Id.Equals(id);
        }
    }
}