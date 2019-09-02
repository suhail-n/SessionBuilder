# SessionBuilder

Session builder is a simple console app which makes use of the commonly used features of .net Date and time APIs. The concepts were based off the Pluralsight Date and times course.

## Requirements

1. Display Author Name
2. Days till birthday
3. Submitted at UTC time and in brackets (Number of days ago)
4. Session description
5. Display if the speaker has more sessions after this or not
6. The time till the next session if any available

## Usage

```sh
dotnet build
dotnet run --project src/SessionBuilder.Client/SessionBuilder.Client.csproj
```

Play around with the load sessions option and look at the `src/SessionBuilder.Core/DataAccess/SessionInMemory.cs` and `src/SessionBuilder.Core/DataAccess/SpeakerInMemory.cs` for the dates and times being loaded within the Sessions screen.
