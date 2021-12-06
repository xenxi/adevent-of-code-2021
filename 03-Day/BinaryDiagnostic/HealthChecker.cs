namespace BinaryDiagnostic
{
    public class HealthChecker
    {
        private string input;
        private Rates _repository;

        public HealthChecker(string input)
        {
            this.input = input;
        }

        public HealthChecker(Rates repository)
        {
            _repository = repository;
        }

        public HealthCheckerResponse GenerateReport()
        {
            _repository.GetGamma();

            _repository.GetEpsilon();

            return new HealthCheckerResponse(powerConsumption: 1);
        }
    }
}