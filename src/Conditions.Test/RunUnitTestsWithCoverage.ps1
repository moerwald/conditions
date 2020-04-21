
dotnet test --collect:"XPlat Code Coverage" --configuration RELEASE

coverlet .\bin\Release\netcoreapp3.1\Mwd.Conditions.Test.dll --target "dotnet" --targetargs "test --configuration RELEASE Conditions.Test.csproj --no-build"
