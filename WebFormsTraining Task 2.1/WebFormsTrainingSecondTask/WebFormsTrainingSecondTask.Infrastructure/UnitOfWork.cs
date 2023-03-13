using Microsoft.Extensions.Options;
using System;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using WebFormsTrainingSecondTask.Core.Exception;
using WebFormsTrainingSecondTask.Core.Tasks;
using WebFormsTrainingSecondTask.Infrastructure.Core;
using WebFormsTrainingSecondTask.Infrastructure.Repositories;

namespace WebFormsTrainingSecondTask.Infrastructure
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private AppContext _context;

        private TasksRepository _tasksRepository;
        private CategoryRepository _categoriesRepository;

        private AppContext Context
        {
            get
            {
                if (_context == null)
                {
                    return _context = new AppContext();
                }
                return _context;
            }
        }

        #region Catalog

        public ITasksRepository TaskRepository
        {
            get
            {
                if (_tasksRepository == null)
                {
                    return _tasksRepository = new TasksRepository(Context);
                }

                return _tasksRepository;
            }
        }

        public ICategoryRepository CategoryRepository
        {
            get
            {
                if (_categoriesRepository == null)
                {
                    return _categoriesRepository = new CategoryRepository(Context);
                }

                return _categoriesRepository;
            }
        }

        #endregion

        public void Commit()
        {
            if (Context == null)
            {
                return;
            }

            if (_isDisposed)
            {
                throw new ObjectDisposedException("UnitOfWork");
            }

            try
            {
                Context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new ConcurrencyException(ex.Entries.Select(x => x.Entity.ToString()));
            }
            catch (DbUpdateException ex)
            {
                throw new System.Data.Entity.Core.UpdateException(ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new RepositoryException("Commit error.", ex);
            }
        }

        private bool _isDisposed;

        public void Dispose()
        {
            if (_context == null)
            {
                return;
            }

            if (!_isDisposed)
            {
                _context.Dispose();
            }

            _isDisposed = true;
        }
    }
}
