using System;
using WebFormsTrainingSecondTask.Services.DTOModels.TaskDTOs;

namespace WebFormsTrainingSecondTask.Services.Contracts
{
    public interface ITaskService
    {
        void Add(TaskDTO taskDTO);
        void Update(TaskDTO taskDTO);
        void Delete(Guid id);
    }
}
