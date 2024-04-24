using JobApplicationLibrary.Models;
using JobApplicationLibrary.Services;

namespace JobApplicationLibrary
{
    public class ApplicationEvaluator
    {
        private const int minAge = 18;
        private const int autoAcceptedYearOfExperience = 15;
        private List<string> techStackList = new() { "C#", "Microservice", "OOP", "Net Core" };
        private readonly IIdentityValidator _identityValidator;

        public ApplicationEvaluator(IIdentityValidator identityValidator)
        {
            _identityValidator = identityValidator;
        }

        public ApplicationResult Evaluate(JobApplication form)
        {
            if(form.Applicant == null)
            {
                throw new ArgumentNullException();
            }

            if(form.Applicant.Age < minAge)
            {
                return ApplicationResult.AutoRejected;
            }

            _identityValidator.ValidationMode = form.Applicant.Age > 50 ? ValidationMode.Detailed : ValidationMode.Quick;

            if(_identityValidator.Country != "TURKIYE")
            {
                return ApplicationResult.TransferredToCTO;
            }

            var validIdentity = _identityValidator.IsValid(form.Applicant.IdentityNumber);

            if (!validIdentity)
            {
                return ApplicationResult.TransferredToHR;
            }

            var sr = GetTechStackSimilarityRate(form.TechStackList);

            if(sr < 25)
            {
                return ApplicationResult.AutoRejected;
            }
            else if(sr == 100 && form.YearsOfExperience >= autoAcceptedYearOfExperience){
                return ApplicationResult.AutoAccepted;
            }


            return ApplicationResult.TransferredToLead;
        }

        private int GetTechStackSimilarityRate(List<string> techStacks)
        {
            var matchedCount = techStacks.Where(x => techStackList.Contains(x, StringComparer.OrdinalIgnoreCase)).Count();
            return matchedCount / techStackList.Count * 100;
        }

    }

    public enum ApplicationResult
    {
        AutoRejected,
        TransferredToHR,
        TransferredToLead,
        TransferredToCTO,
        AutoAccepted
    }

}
