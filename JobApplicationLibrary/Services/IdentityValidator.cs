namespace JobApplicationLibrary.Services
{
    public class IdentityValidator : IIdentityValidator
    {
        public string Country => "USA";

        public bool IsValid(string identityNumber)
        {
            return true;
        }
    }
}
