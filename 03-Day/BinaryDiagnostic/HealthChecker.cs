namespace BinaryDiagnostic
{
    public class HealthChecker
    {
        private Rates _repository;
        public HealthChecker(Rates repository)
        {
            _repository = repository;
        }

        public HealthCheckerResponse GenerateReport()
        {
            var gamma = _repository.GetGamma();
            var epsilon = _repository.GetEpsilon();
            var powerConsumption = gamma * epsilon;

            _repository.GetOxygenGenerator();

            return new HealthCheckerResponse(powerConsumption: powerConsumption, lifeSupport: 0);
        }
    }
}