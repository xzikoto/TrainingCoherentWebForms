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

            if (_unitOfWork.TaskRepository.GetTaskById(taskDTO.Id) != null)
            {
                throw new Exception("This task already exists");
            }

            try
            {
                _unitOfWork.TaskRepository.Add(task);
                _unitOfWork.Commit();
            }
            catch (Exception)
            {
                throw new Exception("There is problem with creating the task");
            }
        }
        
        public void Update(TaskDTO taskDTO)
        {
            var task = _unitOfWork.TaskRepository.Find(t => t.Id == taskDTO.Id);

            if (task == null)
            {
                throw new Exception("Task does not exist");
            }

            var taskNew = taskDTO.ToDomain();

            task.Name = taskNew.Name;
            task.Date = taskNew.Date;
            task.CategoryId = taskNew.CategoryId == Guid.Empty ? taskNew.Category.Id : taskNew.CategoryId;

            try
            {
                _unitOfWork.Commit();
            }
            catch (Exception)
            {
                throw new Exception("There is problem with updating the task");
            }
        }

        public void Delete(Guid id)
        {
            var task = _unitOfWork.TaskRepository.Find(t => t.Id == id);

            try
            {

                _unitOfWork.TaskRepository.Remove(task);
                _unitOfWork.Commit();
            }
            catch (Exception)
            {
                throw new Exception("There is problem with deleting the task");
            }
        }
    }
}
