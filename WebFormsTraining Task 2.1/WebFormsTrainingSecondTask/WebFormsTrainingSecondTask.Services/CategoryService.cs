using System;
using WebFormsTrainingSecondTask.Infrastructure.Core;
using WebFormsTrainingSecondTask.Services.Contracts;
using WebFormsTrainingSecondTask.Services.DTOModels;
using WebFormsTrainingSecondTask.Services.Mappers;

namespace WebFormsTrainingSecondTask.Services
{
    public class TaskService : ITaskService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TaskService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(TaskDTO taskDTO)
        {
            var task = TaskMapper.ToDomain(taskDTO);

            _unitOfWork.TaskRepository.Add(task);
            _unitOfWork.Commit();
        }
        
        public void Update(TaskDTO taskDTO)
        {
            var taskOld = _unitOfWork.TaskRepository.Find(t => t.Id == taskDTO.Id);
            var taskNew = taskDTO.ToDomain();

            taskOld.Name = taskNew.Name;
            taskNew.Date = taskOld.Date;
            taskNew.CategoryId = taskOld.CategoryId;
            taskNew.Category = taskOld.Category;

            _unitOfWork.Commit();
        }

        public void Delete(Guid id)
        {
            var task = _unitOfWork.TaskRepository.Find(t => t.Id == id);
            
            _unitOfWork.TaskRepository.Remove(task);
            _unitOfWork.Commit();
        }
    }
}
