# SessionBuilder

Session builder is a simple console app which makes use of the commonly used features of .net Date and time APIs. The concepts were based off the Pluralsight Date and times course.

## Usage

```sh
dotnet build
dotnet run --project src/SessionBuilder.Client/SessionBuilder.Client.csproj
```

Play around with the load sessions option and look at the `src/SessionBuilder.Core/DataAccess/SessionInMemoryDao.cs` and `src/SessionBuilder.Core/DataAccess/SpeakerInMemoryDao.cs` for the dates and times being loaded within the Sessions screen.
