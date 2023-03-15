using System;
using System.Collections.Generic;

namespace WebFormsTrainingSecondTask.Core.Exception
{
    [Serializable]
    public class RepositoryException : System.Exception
    {
        public List<string> Errors { get; } = new List<string>();

        public RepositoryException(string message) : base(message)
        {
        }

        public RepositoryException(string message, System.Exception innerException) : base(message, innerException)
        {
        }
    }
}
