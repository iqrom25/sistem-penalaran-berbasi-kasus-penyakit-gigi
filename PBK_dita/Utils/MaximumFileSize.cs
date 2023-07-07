using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace PBK_dita.Utils
{
    public class MaximumFileSize : ValidationAttribute
    {
        private readonly int _maxFileSize;
        public MaximumFileSize(int maxFileSize)
        {
            _maxFileSize = maxFileSize;
        }

        protected override ValidationResult IsValid(
            object value, ValidationContext validationContext)
        {
            var file = value as IFormFile;
            if (file is null) return ValidationResult.Success;
            
            return file.Length > _maxFileSize ? new ValidationResult(GetErrorMessage(file.FileName)) : ValidationResult.Success;
        }

        public string GetErrorMessage(string name)
        {
            return $"{name}'s size is out of range.Maximum allowed file size is { _maxFileSize} bytes.";
        }
    }
}