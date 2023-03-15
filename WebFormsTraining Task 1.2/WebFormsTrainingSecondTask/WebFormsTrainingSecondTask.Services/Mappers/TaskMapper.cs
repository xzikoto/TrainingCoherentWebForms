using System;
using System.Collections.Generic;
using System.Linq;
using WebFormsTrainingSecondTask.Services.DTOModels.TaskDTOs;
using WebFormsTrainingSecondTask.Core.Entities.Questions;

namespace WebFormsTrainingSecondTask.Services.Mappers
{
    public static class TaskMapper
    {
        public static TaskDTO ToDto(this Question task)
        {
            if (task == null)
            {
                return null;
            }

            return new TaskDTO
            {
                Id = task.Id,
                CategoryId = task.CategoryId,
                Date = task.Date,
                Name = task.Name
            };
        }

        public static List<TaskDTO> ToDto(this List<Question> tasks)
        {
            if (tasks == null)
            {
                return new List<TaskDTO>();
            }

            return tasks.Select(t => ToDto(t)).ToList();
        }

        public static Question ToDomain(this TaskDTO task)
        {
            if (task == null)
            {
                return null;
            }

            return new Question
            {
                Id = task.Id,
                CategoryId = task.CategoryId,
                Date = task.Date,
                Name = task.Name
            };
        }

        public static List<Question> ToDomain(this List<TaskDTO> tasks)
        {
            if (tasks == null)
            {
               new List<Question>();
            }

            return tasks.Select(t => ToDomain(t)).ToList();
        }
    }
}
