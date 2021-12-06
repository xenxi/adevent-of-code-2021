namespace BinaryDiagnostic.Tests
{
    public static class HealthCheckerResponseMother
    {
        public static HealthCheckerResponse Create(int powerConsumption, int lifeSupport) 
            => new HealthCheckerResponse(powerConsumption: powerConsumption, lifeSupport: lifeSupport);
    }
}
