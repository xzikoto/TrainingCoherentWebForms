using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsTrainingSecondTask.Core.Entities;

namespace WebFormsTrainingSecondTask.Infrastructure.Configs
{
    internal class CategoryConfig : EntityTypeConfiguration<Category>
    {
        public void Configure()
        {
            ToTable("Category", "dbo");
            HasKey(x => x.Id);
            Property(x => x.Id).HasColumnName("Id");
            Property(x => x.Name).HasColumnName("Name");
            HasRequired(x => x.Tasks).WithMany().HasForeignKey(x => x.Id);

        }
    }
}
