1. Install the following Nuget packages
    a. Grpc.Net.Client
    b. Google.Protobuf
    c. Grpc.Tools

2.  Paste the Protobuf file from the server class into the proto folder  and right click on the proto file and change the gRPC stud
classes option to ClientOnly. This will create the client classes needed to communicate with the server upon building the app

3. Rebuild the app and click on show hidden files then check the obj folder to find the grpc classes.
