
namespace ProductGrpc.Models.ServerStream;
public class Data
{
    public Sensordata[] sensorData { get; set; }
    public string optionalNotes { get; set; }
    public Gpsdata[] gpsData { get; set; }
    public Beacondata[] beaconData { get; set; }
    public Recordinginfo recordingInfo { get; set; }
}
