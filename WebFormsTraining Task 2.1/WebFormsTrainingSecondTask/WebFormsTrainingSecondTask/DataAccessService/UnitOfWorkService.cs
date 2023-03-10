using System;
using WebFormsTrainingSecondTask.Infrastructure;

namespace WebFormsTrainingSecondTask.DataAccessService
{
    public sealed class UnitOfWorkService
    {
        private static readonly UnitOfWorkOptions _unitOfWorkOptions = new UnitOfWorkOptions();

        private static readonly Lazy<UnitOfWork> lazy =
            new Lazy<UnitOfWork>(() => new UnitOfWork(_unitOfWorkOptions));

        public static UnitOfWork Instance { get { return lazy.Value; } }

        private UnitOfWorkService()
        {
        }
    }
}