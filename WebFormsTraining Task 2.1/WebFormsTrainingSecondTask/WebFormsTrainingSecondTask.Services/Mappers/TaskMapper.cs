using System;
using System.Collections.Generic;
using System.Linq;
using WebFormsTrainingSecondTask.Core.Entities.Tasks;
using WebFormsTrainingSecondTask.Services.DTOModels;

namespace WebFormsTrainingSecondTask.Services.Mappers
{
    public static class TaskMapper
    {
        public static TaskDTO ToDto(this Task task)
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

        public static List<TaskDTO> ToDto(this List<Task> tasks)
        {
            if (tasks == null)
            {
                return new List<TaskDTO>();
            }

            return tasks.Select(t => ToDto(t)).ToList();
        }

        public static Task ToDomain(this TaskDTO task)
        {
            if (task == null)
            {
                return null;
            }

            return new Task
            {
                Id = task.Id,
                CategoryId = task.CategoryId,
                Date = task.Date,
                Name = task.Name
            };
        }

        public static List<Task> ToDomain(this List<TaskDTO> tasks)
        {
            if (tasks == null)
            {
               new List<Task>();
            }

            return tasks.Select(t => ToDomain(t)).ToList();
        }
    }
}
