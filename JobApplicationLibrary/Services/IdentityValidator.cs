namespace JobApplicationLibrary.Services
{
    public class IdentityValidator : IIdentityValidator
    {
        public string Country => "USA";

        public ValidationMode ValidationMode { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool IsValid(string identityNumber)
        {
            return true;
        }
    }
}
