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

            var oxygen = _repository.GetOxygenGenerator();
            var co2 = _repository.GetCo2Scrubber();
            var lifeSupport = oxygen * co2;

            return new HealthCheckerResponse(powerConsumption: powerConsumption, lifeSupport: lifeSupport);
        }
    }
}