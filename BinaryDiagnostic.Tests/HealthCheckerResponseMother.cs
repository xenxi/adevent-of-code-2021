namespace BinaryDiagnostic.Tests
{
    public static class HealthCheckerResponseMother
    {
        public static HealthCheckerResponse Create(int powerConsumption) 
            => new HealthCheckerResponse(powerConsumption: powerConsumption);
    }
}
