namespace BinaryDiagnostic
{
    public class HealthCheckerResponse
    {
        public int PowerConsumption { get; }
        public int LifeSupport { get; }

        public HealthCheckerResponse(int powerConsumption, int lifeSupport)
        {
            PowerConsumption = powerConsumption;
            LifeSupport = lifeSupport;
        }
    }
}
