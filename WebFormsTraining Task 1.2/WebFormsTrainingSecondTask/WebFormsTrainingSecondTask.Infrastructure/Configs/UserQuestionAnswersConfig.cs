using System.Data.Entity.ModelConfiguration;
using WebFormsTrainingSecondTask.Core.Entities;
using WebFormsTrainingSecondTask.Core.Entities.Users;

namespace WebFormsTrainingSecondTask.Infrastructure.Configs
{
    internal sealed class UserQuestionAnswersConfig : EntityTypeConfiguration<UserQuestionAnswer>
    {
        public void Configure()
        {
            ToTable("UserQuestionAnswers", "dbo");
            HasKey(x => x.Id);
            Property(x => x.Id).HasColumnName("Id");
            Property(x => x.Gender).HasColumnName("Gender");
            Property(x => x.IsCorrect).HasColumnName("IsCorrect");
            Property(x => x.Age).HasColumnName("Age");
        }
    }
}
