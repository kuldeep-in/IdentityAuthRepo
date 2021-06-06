using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityAuthentication.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityAuthUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.Entity<WorkItem>().HasKey(a => a.WorkItemId);
            //builder.Entity<Team>().HasKey(a => a.TeamId);

            base.OnModelCreating(builder);

        }
    }
}
