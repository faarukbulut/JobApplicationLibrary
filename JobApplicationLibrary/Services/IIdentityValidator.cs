namespace JobApplicationLibrary.Services
{
    public interface IIdentityValidator
    {
        bool isValid(string identityNumber);
    }
}
