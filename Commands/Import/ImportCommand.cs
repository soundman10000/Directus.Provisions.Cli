using CommandLine;

namespace Directus.Provisions.Cli;

[Verb("hello", HelpText = "Say hello to someone.")]
public class ImportCommandOptions
{
    [Value(0, MetaName = "name", HelpText = "Name to greet.")]
    public string? Name { get; set; }
}