namespace SunamoRL._sunamo.SunamoStringJoin;

internal class SHJoin
{
    internal static string JoinFromIndex(int startIndex, object delimiter, IList parts)
    {
        var delimiterText = delimiter.ToString()!;
        var stringBuilder = new StringBuilder();
        int index = 0;
        foreach (var item in parts)
        {
            if (index >= startIndex)
            {
                stringBuilder.Append(item + delimiterText);
            }
            index++;
        }
        var result = stringBuilder.ToString();
        return result.Substring(0, result.Length - 1);
    }
}
