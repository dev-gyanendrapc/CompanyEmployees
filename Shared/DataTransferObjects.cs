using System.ComponentModel.DataAnnotations;

namespace Shared
{
    public class DataTransferObjects
    {
        // company dto
        public record CompanyDto
        {
            public Guid Id { get; init; }
            public string? Name { get; init; }
            public string? FullAddress { get; init; }
        };
        public record CompanyForCreationDto: CompanyForManipulateDto;

        public record CompanyForUpdateDto: CompanyForManipulateDto;

        public abstract record CompanyForManipulateDto
        {
            [Required(ErrorMessage ="Company name is a required field.")]
            [MaxLength(100, ErrorMessage ="Maximum length for the Name is 100 characters.")]
            public string? Name { get; init; }
            [Required(ErrorMessage ="Company address is a required field.")]
            [MaxLength(100, ErrorMessage = "Maximum length for the Address is 100 characters.")]
            public string? Address { get; init; }
            [Required(ErrorMessage ="Company country is a required field.")]
            [MaxLength(100, ErrorMessage = "Maximum length for the Country is 100 characters.")]
            public string? Country { get; init; }
            IEnumerable<EmployeeForCreationDto?> Employees { get; init; }
        }

        // employee dto
        public record EmployeeDto(Guid Id, string Name, int Age, string Position);
        public record EmployeeForCreationDto: EmployeeForManipulationDto;
        public record EmployeeForUpdateDto: EmployeeForManipulationDto;
       
        public abstract record EmployeeForManipulationDto
        {
            [Required(ErrorMessage = "Employee name is a required field.")]
            [MaxLength(30, ErrorMessage = "Maximum length for the Name is 30 characters.")]
            public string? Name { get; init; }
            [Range(18, int.MaxValue, ErrorMessage = "Age is required and it can't be lower  than 18")]
            public int Age { get; init; }
            [Required(ErrorMessage = "Position is a required field.")]
            [MaxLength(20, ErrorMessage = "Maximum length for the Position is 20 characters.")]
            public string? Position { get; init; }
        }
    }
}
