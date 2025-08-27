using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pr.Cms.BuildingBlock.Core.Exceptions
{
    public class InvalidValueException : BaseException
    {
        public InvalidValueException(string message, string propertyName, object? providedValue)
            : base(CreateMessage(propertyName, providedValue, message))
        {
  
        }

        private static string CreateMessage(string propertyName, object? providedValue, string message)
        {
            var valueText = providedValue?.ToString();
            if (valueText is not null)
            {
                return $"Validation failed for '{propertyName}' with value '{valueText}'. {message}";
            }

            return $"Validation failed for '{propertyName}'. {message}";
        }
    }
}
