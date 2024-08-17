using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public abstract record CompanyForManipulateDto
    {
        [Required(ErrorMessage = "Company name is a required field.")]
        [MaxLength(100, ErrorMessage = "Maximum length for the Name is 100 characters.")]
        public string? Name { get; init; }
        [Required(ErrorMessage = "Company address is a required field.")]
        [MaxLength(100, ErrorMessage = "Maximum length for the Address is 100 characters.")]
        public string? Address { get; init; }
        [Required(ErrorMessage = "Company country is a required field.")]
        [MaxLength(100, ErrorMessage = "Maximum length for the Country is 100 characters.")]
        public string? Country { get; init; }
        IEnumerable<EmployeeForCreationDto?> Employees { get; init; }
    }
}
