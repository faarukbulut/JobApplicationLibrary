using JobApplicationLibrary.Models;

namespace JobApplicationLibrary.Services
{
    public interface IIdentityValidator
    {
        bool IsValid(string identityNumber);
        string Country { get; }
        public ValidationMode ValidationMode { get; set; }
    }

    public enum ValidationMode
    {
        None,
        Quick,
        Detailed
    }

}
