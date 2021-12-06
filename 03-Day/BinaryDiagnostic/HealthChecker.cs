namespace BinaryDiagnostic
{
    public class HealthChecker
    {
        private Rates _repository;
        private string input;
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
            var gamma = _repository.GetGamma();

            var epsilon = _repository.GetEpsilon();
            var powerConsumption = gamma * epsilon;
            return new HealthCheckerResponse(powerConsumption: powerConsumption);
        }
    }
}