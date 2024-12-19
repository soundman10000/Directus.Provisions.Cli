using CommandLine;

namespace Directus.Provisions.Cli;

[Verb("add", HelpText = "Add two numbers.")]
internal class ExportCommand
{
    [Value(0, MetaName = "a", HelpText = "First number to add.")]
    public int A { get; set; }

    [Value(1, MetaName = "b", HelpText = "Second number to add.")]
    public int B { get; set; }
}