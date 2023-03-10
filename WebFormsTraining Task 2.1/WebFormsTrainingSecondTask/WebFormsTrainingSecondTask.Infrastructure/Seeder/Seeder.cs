using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using WebFormsTrainingSecondTask.Core.Entities;
using WebFormsTrainingSecondTask.Core.Entities.Tasks;

namespace WebFormsTrainingSecondTask.Infrastructure.Seeder
{
    public static class Seeder
    {
        private static List<Category> GenerateCategories()
        {
            return new List<Category>()
            {
                new Category {Id = Guid.NewGuid(), Name = "LOW"},
                new Category {Id = Guid.NewGuid(), Name = "HIGH"},
                new Category {Id = Guid.NewGuid(), Name = "MEDIUM"}
            };
        }

        public static List<Task> GenerateTasks()
        {
            var tasksList = new List<Task>();
            var categories = GenerateCategories();

            var taskName = "TaskName";
            var randomDate = new RandomDateTime();

            for (int i = 1; i <= new Random().Next(30); i++)
            {
                var rand = new Random();

                tasksList.Add(new Task()
                {
                    Id = Guid.NewGuid(),
                    Name = $"{taskName} {i}",
                    Category = categories[rand.Next(categories.Count)],
                    Date = randomDate.Next()
                });
            };

            return tasksList;
        }
    }

    class RandomDateTime
    {
        DateTime start;
        Random gen;
        int range;

        public RandomDateTime()
        {
            start = new DateTime(1995, 1, 1);
            gen = new Random();
            range = (DateTime.Today - start).Days;
        }

        public DateTime Next()
        {
            return start.AddDays(gen.Next(range)).AddHours(gen.Next(0, 24)).AddMinutes(gen.Next(0, 60)).AddSeconds(gen.Next(0, 60));
        }
    }
}
