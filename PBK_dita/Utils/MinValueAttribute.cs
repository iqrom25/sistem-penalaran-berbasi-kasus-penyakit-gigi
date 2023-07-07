using System;
using System.ComponentModel.DataAnnotations;

namespace PBK_dita.Utils
{
    public class MinValueAttribute: ValidationAttribute
    {
        private readonly double _minValue;
        private string _errorMessage;

        public MinValueAttribute(double minValue)
        {
            _minValue = minValue;
        }
        
        public MinValueAttribute(double minValue, string errorMessage)
        {
            _minValue = minValue;
            _errorMessage = errorMessage;
        }
        
        protected override ValidationResult IsValid(
            object value, ValidationContext validationContext)
        {
            var obj = Convert.ToDouble(value);
            
            return obj >= _minValue ? ValidationResult.Success : new ValidationResult(_errorMessage);
        }
    }
}