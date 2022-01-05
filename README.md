# VRChat Photo Grouping

C# Scripts for grouping VRChat Photos by Date and Time.

## Requirements

You need to have one of the following packages installed:

- LINQPad - https://linqpad.com/
- .NET CLI - https://dotnet.microsoft.com/download/dotnet-core/
  - dotnet-script - `dotnet tool install -g dotnet-script`

## Usage

### LINQPad Users

1. Copy and Paste `runner.linq` into your LINQPad Script.
2. Configure the script to use (see configuration section).
3. Run the script.

### Windows Users

1. Copy and Paste `runner.csx` into your directory.
2. Configure the script to use (see configuration section).
3. Run the script with `dotnet script runner.csx`.

## Configuration

You can configure the script to use the following settings:

```csharp
// source directory full path for storing VRChat photos
// Example: C:\Users\Natsuneko\Pictures\VRChat\
var source = @"";

// destination directory full path for storing VRChat photos
// Example: C:\Users\OneDrive\Pictures\VRChat\
var dest = @"";

// grouping format, recommended to use `{yyyy}-{MM}`
// Example: {yyyy}-{MM}, {yyyy}-{MM}-{dd}, or you want to group by ...
var grouping = "{yyyy}-{MM}";

// dry run, if true, the script will not move the photos
// Example: true
var dryRun = true;
```

## License

MIT by [@6jz](https://twitter.com/6jz)
