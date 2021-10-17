
namespace ProductGrpc.Models.ServerStream;
public class Gpsdata
{
    public float timestamp { get; set; }
    public float latitude { get; set; }
    public float accuracyInMeters { get; set; }
    public float longitude { get; set; }
}
