using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChallengeDisney.PreAcel.Entities;
using ChallengeDisney.PreAcel.Interfaces.Repositories.Generic;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Disney.Context
{
    public class UserContext : IdentityDbContext<User>
    {
        //Hereda de un Identity context, da funcionalidad particular

        private const string Schema = "users";
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //Fluent dpi
            //No hay ningún db set
            base.OnModelCreating(builder);
            builder.HasDefaultSchema(Schema);
        }
    }
}
