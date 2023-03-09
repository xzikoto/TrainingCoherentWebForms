﻿using System;
using System.Collections.Generic;

namespace WebFormsTrainingSecondTask.Core.Exception
{
    [Serializable]
    public class UpdateException : RepositoryException
    {
        public UpdateException(IList<string> errors) : base(
            $"Problem occurred when updating entities. {string.Join(" ", errors)}")
        {
            Errors.AddRange(errors);
        }

        public UpdateException(string message) : base(message)
        {
        }

        public UpdateException(string message, System.Exception innerException) : base(message, innerException)
        {
        }
    }
}
