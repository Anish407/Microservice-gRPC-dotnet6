
namespace ProductGrpc.Models.ServerStream;
public class Sensordata
{
    public float[] quaternion { get; set; }
    public string[] magneticField { get; set; }
    public float[] acceleration { get; set; }
    public string dataType { get; set; }
    public float[] rotationRate { get; set; }
    public float timestamp { get; set; }
    public float[] altitudeData { get; set; }
}
