﻿using System;
using System.Collections.Generic;
using WebFormsTrainingSecondTask.Core.Entities;
using WebFormsTrainingSecondTask.Core.Entities.Questions;

namespace WebFormsTrainingSecondTask.Infrastructure.Seeder
{
    public static class Seeder
    {
        private static List<QuestionOption> GenerateCategories()
        {
            return new List<QuestionOption>()
            {
                new QuestionOption {Id = Guid.NewGuid(), Name = "LOW"},
                new QuestionOption {Id = Guid.NewGuid(), Name = "HIGH"},
                new QuestionOption {Id = Guid.NewGuid(), Name = "MEDIUM"}
            };
        }

        public static List<Question> GenerateTasks()
        {
            var tasksList = new List<Question>();
            var categories = GenerateCategories();

            var taskName = "TaskName";
            var randomDate = new RandomDateTime();
            var rand = new Random();

            for (int i = 1; i <= new Random().Next(20,30); i++)
            {

                tasksList.Add(new Question()
                {
                    Id = Guid.NewGuid(),
                    Name = $"{taskName} {i}",
                    //Category = categories[rand.Next(categories.Count)],
                    //Date = randomDate.Next()
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
