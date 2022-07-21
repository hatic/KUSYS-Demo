using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRoles
{
    public class StudentValidator:AbstractValidator<Student>
    {
        public StudentValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("The First Name field is required.");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("The Last Name field is required.");
            RuleFor(x => x.BirthDate).NotEmpty().WithMessage("The Birthdate field is required.");
            RuleFor(x => x.BirthDate).LessThan(DateTime.Now.Date).GreaterThan(DateTime.Now.Date.AddYears(-100)).WithMessage("Birthdate is not valid");
            RuleFor(x => x.CourseId).NotEmpty().WithMessage("The Course field is required.");

        }
    }
}
