using JobApplicationLibrary.Models;

namespace JobApplicationLibrary
{
    public class ApplicationEvaluator
    {
        public ApplicationResult Evaluate(JobApplication form)
        {
            return ApplicationResult.AutoAccepted;
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
