using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebFormsTrainingSecondTask.Models.Task;
using WebFormsTrainingSecondTask.Services.DTOModels;

namespace WebFormsTrainingSecondTask.Mappers
{
    public static class TaskMapper
    {
        public static TaskModel ToModel(this TaskDTO task)
        {
            if (task == null)
            {
                return null;
            }

            return new TaskModel
            {
                Id = task.Id,
                CategoryId = task.CategoryId,
                Category = task.Category.ToModel(),
                Date = task.Date,
                Name = task.Name
            };
        }

        public static List<TaskModel> ToModel(this List<TaskDTO> tasks)
        {
            if (tasks == null || !tasks.Any())
            {
                return new List<TaskModel>();
            }

            return tasks.Select(t => ToModel(t)).ToList();
        }
        
        public static TaskDTO ToDto(this TaskModel task)
        {
            if (task == null)
            {
                return null;
            }

            return new TaskDTO
            {
                Id = task.Id,
                CategoryId = task.CategoryId,
                Category = task.Category.ToDto(),
                Date = task.Date,
                Name = task.Name
            };
        }

        public static List<TaskDTO> ToDto(this List<TaskModel> tasks)
        {
            if (tasks == null || !tasks.Any())
            {
                return new List<TaskDTO>();
            }

            return tasks.Select(t => ToDto(t)).ToList();
        }
    }
}