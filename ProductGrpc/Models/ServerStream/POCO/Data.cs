
namespace ProductGrpc.Models.ServerStream.POCO;
public class DataModel
{
    public Sensordata[] sensorData { get; set; }
    public string optionalNotes { get; set; }
    public Gpsdata[] gpsData { get; set; }
    public Beacondata[] beaconData { get; set; }
    public Recordinginfo recordingInfo { get; set; }
}
