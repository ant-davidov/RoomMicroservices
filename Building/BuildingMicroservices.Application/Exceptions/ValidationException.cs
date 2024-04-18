using FluentValidation.Results;

namespace BuildingMicroservices.Application.Exceptions
{
    public class ValidationException : Exception
    {
        public List<string> Errors { get; set; } = new();
        public ValidationException(ValidationResult validationResult)
        {
            Errors = validationResult.Errors
                        .Select(er => er.ErrorMessage)
                        .ToList();
        }
        public ValidationException(string text)
        {
            Errors.Add(text);
        }

    }
}
