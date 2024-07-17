using Devtoolkit.LinguagemUbiqua.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Devtoolkit.LinguagemUbiqua.Infra.Data.Sqlite.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<DomainContextEntity> DomainContextEntity { get; set; }

        public DbSet<UserEntity> UserEntity { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("DataSource=app.db;Cache=Shared");
    }
}
