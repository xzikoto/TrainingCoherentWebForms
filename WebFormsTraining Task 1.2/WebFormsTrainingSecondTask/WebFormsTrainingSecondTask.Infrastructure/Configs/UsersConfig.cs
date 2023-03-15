using System.Data.Entity.ModelConfiguration;
using WebFormsTrainingSecondTask.Core.Entities.Users;

namespace WebFormsTrainingSecondTask.Infrastructure.Configs
{
    internal sealed class UsersConfig : EntityTypeConfiguration<User>
    {
        public void Configure()
        {
            ToTable("Users", "dbo");
            HasKey(x => x.Id);
            Property(x => x.Id).HasColumnName("Id");
            Property(x => x.Name).HasColumnName("Name");
            Property(x => x.Age).HasColumnName("Age");

            HasRequired(x => x.Gender).WithMany(x => x.Users).HasForeignKey(x => x.GenderId);
        }
    }
}
