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

        private AppContext Context => _context == null ? new AppContext() : _context;

        #region Catalog

        public ITasksRepository TaskRepository => _tasksRepository == null ? new TasksRepository(Context) : _tasksRepository;
        
        public ICategoryRepository CategoryRepository => _categoriesRepository == null ? new CategoryRepository(Context) : _categoriesRepository;

        #endregion

        public UnitOfWork(IOptions<UnitOfWorkOptions> accessor) : this(accessor.Value)
        {
        }

        public UnitOfWork(UnitOfWorkOptions options)
        {
            options.ConnectionString = @"Data Source=BG-NBW-0263\MSSQLSERVER01;Initial Catalog=TasksDB;Integrated Security=True";
            options.CommandTimeout = 200;
        }

        public UnitOfWork()
        {
        }

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
