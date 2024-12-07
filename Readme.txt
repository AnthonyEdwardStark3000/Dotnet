There are three ways for reading values from configuration file (appsettings.json)
Refer Program.cs for more.

And for reading values from appsettings in controller we should Inject IConfiguration interface in our controller.


For creating and managing the secrets

dotnet user-secrets init
dotnet user-secrets set key value
dotnet user-secrets list 