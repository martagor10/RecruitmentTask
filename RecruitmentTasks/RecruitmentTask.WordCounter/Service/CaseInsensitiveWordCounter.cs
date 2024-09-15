namespace RecruitmentTask.WordCounter.Service;

internal class CaseInsensitiveWordCounter : BasicWordCounter
{
    protected override IEqualityComparer<string> Comparer => StringComparer.CurrentCultureIgnoreCase;
}