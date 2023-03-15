using System;
using System.Collections.Generic;

namespace WebFormsTrainingSecondTask.Services.Exceptions
{
    [Serializable]
    public class EntityExistException : Exception
    {
        public List<string> Errors { get; } = new List<string>();

        public EntityExistException(string message) : base(message)
        {
        }

        public EntityExistException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
