using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SyC.Entity;
using Microsoft.EntityFrameworkCore.Design;
namespace Syc.Persistence
{
    public class SycContext : DbContext
    {
        public SycContext(DbContextOptions<SycContext> options)
            : base(options)
        {
        }


        public DbSet<User> Users { get; set; }
            public DbSet<Contact> Contacts { get; set; }

            

           
        


    }
}
