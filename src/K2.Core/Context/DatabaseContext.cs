using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using K2.Core.Entity;
using _2K.Core.Entity;
using _2K.Core.Entity.Base;

namespace _2K.Core.Context
{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext()
            : base("K2Database")
        {
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Topic> Topics { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostComment> Comments { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<PostFile> PostFiles { get; set; }


        public override async Task<int> SaveChangesAsync()
        {
            foreach (var entity in ChangeTracker.Entries<BaseItem>().Where(e => e.State == EntityState.Modified))
            {
                entity.Entity.UpdatedOn = DateTime.Now;
            }
            foreach (var entity in ChangeTracker.Entries<BaseItem>().Where(e => e.State == EntityState.Added))
            {
                entity.Entity.CreatedOn = entity.Entity.UpdatedOn = DateTime.Now;
            }
            try
            {
                return await base.SaveChangesAsync();
            }
            catch (DbEntityValidationException ex)
            {
                //var errors =
                //    ex.EntityValidationErrors
                //    .Where(e => !e.IsValid)
                //        .Select(e =>e.Entry.Entity.GetType().Name + " - Errors:" + string.Join(", " + e.ValidationErrors.Select(v => string.Format("{0}: {1}", v.PropertyName, v.ErrorMessage))));
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
