<Query Kind="Statements" />

// Configurations
//
// source   - source directory full path
// dest     - destination directory full path
// grouping - grouping format (e.g. {yyyy}-{MM}-{dd})
//            you can use placeholder such as date and time format strings in {}
//            in addition, the following values can be used:
// dryRun   - enable previews

var source   = @"";
var dest     = @"";
var grouping = "{yyyy}-{MM}";
var dryRun   = true;

// Program
//
// DO NOT CHANGE ANYTHING BELOW
string ReplaceFormatString(string str, dynamic obj)
{
    var date   = new DateTime(obj.Year, obj.Month, obj.Day, obj.Hour, obj.Minute, obj.Second, obj.MillSecond, DateTimeKind.Local);
    var format = new Regex(@"\{(?<format>.*?)\}", RegexOptions.Compiled);

    foreach (Match f in format.Matches(str))
        str = str.Replace(f.Value, date.ToString(f.Groups["format"].ToString()));

    return str;
}

var files   = Directory.GetFiles(source);
var pattern = new Regex(@"VRChat_(?<width>\d+)x(?<height>\d+)_(?<year>\d{4})-(?<month>\d{2})-(?<day>\d{2})_(?<hour>\d{2})-(?<minute>\d{2})-(?<second>\d{2})\.(?<millsecond>\d{2,}).*", RegexOptions.Compiled);

foreach (var file in files)
{
    var name = Path.GetFileNameWithoutExtension(file);
    var ext  = Path.GetExtension(file);

    if (!pattern.IsMatch(file))
    {
        Console.WriteLine($"[WARN] invalid filename format -> {name}{ext}");
        continue;
    }

    var match  = pattern.Match(name);
    var values = new {
       Height     = int.Parse(match.Groups["height"].ToString()),
       Width      = int.Parse(match.Groups["width"].ToString()),
       Year       = int.Parse(match.Groups["year"].ToString()),
       Month      = int.Parse(match.Groups["month"].ToString()),
       Day        = int.Parse(match.Groups["day"].ToString()),
       Hour       = int.Parse(match.Groups["hour"].ToString()),
       Minute     = int.Parse(match.Groups["minute"].ToString()),
       Second     = int.Parse(match.Groups["second"].ToString()),
       MillSecond = int.Parse(match.Groups["millsecond"].ToString()),
    };

    var group       = ReplaceFormatString(grouping, values);
    var destination = Path.Combine(dest, group);

    if (!Directory.Exists(destination))
        Directory.CreateDirectory(destination);

    var path = Path.Combine(destination, $"{name}{ext}");

    if (dryRun)
        Console.WriteLine($"{file} will moved to {path}");
    else
        File.Move(file, path);
}
