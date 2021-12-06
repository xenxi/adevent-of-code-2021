namespace BinaryDiagnostic
{
    public class HealthCheckerResponse
    {
        public int PowerConsumption { get; }

        public HealthCheckerResponse(int powerConsumption)
        {
            PowerConsumption = powerConsumption;
        }
    }
}
