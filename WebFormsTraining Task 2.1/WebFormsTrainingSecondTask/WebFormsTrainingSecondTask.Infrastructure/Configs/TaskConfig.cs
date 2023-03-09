using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using WebFormsTrainingSecondTask.Core.Entities.Tasks;

namespace WebFormsTrainingSecondTask.Infrastructure.Configs
{
    internal sealed class TaskConfig : EntityTypeConfiguration<Task>
    {
        public void Configure()
        {
            ToTable("TasksTable", "dbo");
            HasKey(x => x.Id);
            Property(x => x.Id).HasColumnName("Id");
            //Property(x => x.Name).HasColumnName("Name");
            ////Property(x => x.Date).HasColumnName("Date");
            //Property(x => x.Category).HasColumnName("category");
        }
    }
}
