//////////////////////////////////////////////////////////////////////
// ARGUMENTS
//////////////////////////////////////////////////////////////////////

var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");

//////////////////////////////////////////////////////////////////////
// PREPARATION
//////////////////////////////////////////////////////////////////////

// Define directories.
var buildDir = Directory("./src/HallsByra.BitsAndBytes/bin") + Directory(configuration);
var nugetDir = "./nuget";

//////////////////////////////////////////////////////////////////////
// GLOBALS
//////////////////////////////////////////////////////////////////////
GitVersion gitVersion = null;

//////////////////////////////////////////////////////////////////////
// TASKS
//////////////////////////////////////////////////////////////////////

Task("Clean")
    .Does(() =>
{
    CleanDirectory(buildDir);
});

Task("Restore-NuGet-Packages")
    .IsDependentOn("Clean")
    .Does(() =>
{
    NuGetRestore("./src/HallsByra.BitsAndBytes.sln");
});

Task("Build")
    .IsDependentOn("Restore-NuGet-Packages")
    .Does(() =>
{
    if(IsRunningOnWindows())
    {
      // Use MSBuild
      MSBuild("./src/HallsByra.BitsAndBytes.sln", settings =>
        settings.SetConfiguration(configuration));
    }
    else
    {
      // Use XBuild
      XBuild("./src/Example.sln", settings =>
        settings.SetConfiguration(configuration));
    }
});

Task("Run-Unit-Tests")
    .IsDependentOn("Build")
    .Does(() =>
{
    XUnit2("./src/**/bin/" + configuration + "/*.Tests.dll", new XUnit2Settings {
        });
});


Task("Get-GitVersion")
    .Does(() =>
{
   gitVersion =  GitVersion();
});

Task("Pack-NuGet")
    .IsDependentOn("Get-GitVersion")
    //.IsDependentOn("Build")
    .Does(() =>
{
    var settings = new NuGetPackSettings() {
        Version = gitVersion.NuGetVersion,
        OutputDirectory = nugetDir,
        Properties = new Dictionary<string, string> {
            { "Configuration", "Release" }  
        }
    };
    
    NuGetPack("./src/HallsByra.BitsAndBytes/HallsByra.BitsAndBytes.csproj", settings);
});

Task("Publish-NuGet")
    .IsDependentOn("Pack-NuGet")
    .Does(() =>
{
    var package = nugetDir + "/HallsByra.BitsAndBytes." + gitVersion.NuGetVersion + ".nupkg";    
    NuGetPush(package, new NuGetPushSettings()); 
});


//////////////////////////////////////////////////////////////////////
// TASK TARGETS
//////////////////////////////////////////////////////////////////////

Task("Default")
    .IsDependentOn("Run-Unit-Tests");

//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////

RunTarget(target);
