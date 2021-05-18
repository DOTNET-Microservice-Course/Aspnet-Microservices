using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Exceptions
{
    public class ValidationException : ApplicationException
    {
        public ValidationException()
            : base("One or more validations failures have occured.")
        {
            Errors = new Dictionary<string, string[]>();
        }

        public ValidationException(IEnumerable<ValidationFailure> failiures)
            : this()
        {
            Errors = failiures
                .GroupBy(e => e.PropertyName, e => e.ErrorMessage)
                .ToDictionary(failiureGroup => failiureGroup.Key, failiureGroup => failiureGroup.ToArray());
        }

        public IDictionary<string, string[]> Errors { get; }
    }
}
