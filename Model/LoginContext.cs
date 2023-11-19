using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Login
{
    //Login.LoginContext
    public class LoginContext : IdentityDbContext<Appuser>
    {
        public LoginContext(DbContextOptions<LoginContext> options) : base(options)
        {
        }
        public DbSet<Login.Model.Crud> Cruds{get;set;}
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            foreach (var entity  in builder.Model.GetEntityTypes())
            {
                var tablename = entity.GetTableName();
                if(tablename.StartsWith("AspNet"))
                {
                    entity.SetTableName(tablename.Substring(6));
                }
            }
        }

    }
}