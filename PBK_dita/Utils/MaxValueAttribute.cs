using System;
using System.ComponentModel.DataAnnotations;

namespace PBK_dita.Utils
{
    public class MaxValueAttribute: ValidationAttribute
    {
        private readonly double _maxValue;
        private string _errorMessage;

        public MaxValueAttribute(double maxValue)
        {
            _maxValue = maxValue;
            _errorMessage = $"Maximum value is {_maxValue}";
        }

        public MaxValueAttribute(double maxValue, string errorMessage)
        {
            _maxValue = maxValue;
            _errorMessage = errorMessage;
        }
        
        protected override ValidationResult IsValid(
            object value, ValidationContext validationContext)
        {
            var obj = Convert.ToDouble(value);
            
            return obj <= _maxValue ? ValidationResult.Success : new ValidationResult(_errorMessage);
        }
    }
}