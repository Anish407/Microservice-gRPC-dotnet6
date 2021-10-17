
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using ProductGrpc.Protos.ServerStream;
using System.Text.Json;
using ProductGrpc.Models.ServerStream.POCO;

namespace ProductGrpc.Services.Products;
public class InfoService: InfoServerStream.InfoServerStreamBase
{

    public override async Task GetAllInfo(Empty request, IServerStreamWriter<Info> responseStream, ServerCallContext context)
    {
        using var reader = new StreamReader("./data/data.json");
        var infoJsonString = await reader.ReadToEndAsync();
        DataModel items = JsonSerializer.Deserialize<DataModel>(infoJsonString);

        for (int i = 0; i < 10; i++)
        {
            var resp = new Info
            {
                Recordinginfo = new Protos.ServerStream.Recordinginfo
                {
                    DeviceModel = items.recordingInfo.deviceModel,
                    Manufacturer = items.recordingInfo.manufacturer,
                    Os = items.recordingInfo.os,
                    OsVersion = items.recordingInfo.os,
                    RecorderVersion = items.recordingInfo.recorderVersion,
                },
                OptionalNotes = items.optionalNotes,
            };
           
            //cannot assign directly as arrays are readonly
            resp.Gpsdata.AddRange(items.gpsData.Select(i=> new Protos.ServerStream.Gpsdata() { 
              AccuracyInMeters=i.accuracyInMeters,
              Latitude=i.latitude,
              Longitude=i.longitude,
              Timestamp=i.timestamp
            }));

            var sensor = new SensorData();
            var quaternion = items.sensorData.SelectMany(i => i?.quaternion ?? new float[0]);
            sensor.Quaternion.AddRange(quaternion);
            sensor.Acceleration.AddRange(items.sensorData.SelectMany(i=> i?.acceleration ?? new float[0]));
            sensor.AltitudeData.AddRange(items.sensorData.SelectMany(i => i?.altitudeData ?? new float[0]));

            resp.SensorData.Add(sensor);


            await responseStream.WriteAsync(resp); 
        }
    }

}
