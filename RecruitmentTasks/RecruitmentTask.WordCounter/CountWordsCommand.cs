using System.CommandLine;

namespace RecruitmentTask.WordCounter;

public class CountWordsCommand : Command
{
    public CountWordsCommand() : base("count-words",
        "Analyse the content of text files and count the occurrences of unique words")
    {
        AddAlias("cw");
        AddArgument(new Argument<string[]>("files", "List of file paths to be analysed"));
        AddOption(new Option<bool>(["--case-insensitive", "-i"],
            "If specified, words will be compared using case-insensitive comparison method"));
    }
}