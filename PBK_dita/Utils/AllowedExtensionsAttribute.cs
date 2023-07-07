using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace PBK_dita.Utils
{
    public class AllowedExtensionsAttribute : ValidationAttribute
    {
        private readonly string[] _extensions;
        public AllowedExtensionsAttribute(string[] extensions)
        {
            _extensions = extensions.Select(s => s.ToLowerInvariant()).ToArray();
        }

        protected override ValidationResult IsValid(
            object value, ValidationContext validationContext)
        {
            var file = value as IFormFile;
            
            if (file is null) return ValidationResult.Success;
            
            var extension = Path.GetExtension(file.FileName).ToLowerInvariant();
            extension = extension[1..];
            
            return (string.IsNullOrEmpty(extension) || !_extensions.Contains(extension)) ? new ValidationResult(GetErrorMessage(extension)) : ValidationResult.Success;
        }

        public static string GetErrorMessage(string name)
        {
            return $"{name} extension is not allowed!";
        }
    }
}