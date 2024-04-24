namespace JobApplicationLibrary.Services
{
    public class IdentityValidator : IIdentityValidator
    {
        public bool isValid(string identityNumber)
        {
            return true;
        }
    }
}
