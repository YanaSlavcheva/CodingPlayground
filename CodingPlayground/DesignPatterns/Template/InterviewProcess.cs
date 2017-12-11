namespace DesignPatterns.Template
{
    public abstract class InterviewProcess
    {
        public void InitiateInterviewProcess()
        {
            HrInterview();
            TechnicalInterview();
            DiscussionWithCto();
        }

        private void HrInterview()
        {
            System.Console.WriteLine("Conducted HrInterview");
        }

        public abstract void TechnicalInterview();

        private void DiscussionWithCto()
        {
            System.Console.WriteLine("Conducted DiscussionWithCto");
        }
    }
}
