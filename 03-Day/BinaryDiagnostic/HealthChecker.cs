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
            var powerConsumption = CalculePowerConsumption();
            var lifeSupport = CalculeLifeSupport();

            return new HealthCheckerResponse(powerConsumption: powerConsumption, lifeSupport: lifeSupport);
        }

        private int CalculeLifeSupport()
        {
            var oxygen = _repository.GetOxygenGenerator();
            var co2 = _repository.GetCo2Scrubber();
            var lifeSupport = oxygen * co2;
            return lifeSupport;
        }

        private int CalculePowerConsumption()
        {
            var gamma = _repository.GetGamma();
            var epsilon = _repository.GetEpsilon();
            var powerConsumption = gamma * epsilon;
            return powerConsumption;
        }
    }
}