namespace SunamoRL.RL;

/// <summary>
/// Represents the attributes helper type.
/// </summary>
public class AttributesHelper
{
    /// <summary>
    /// Data member.
    /// </summary>
    /// <param name="source">The source.</param>
    /// <param name="fields">The fields.</param>
    /// <param name="basic">The basic.</param>
    /// <param name="nameMapping">The name mapping.</param>
    /// <returns>The data member result.</returns>
    public static List<object> DataMember(object source, List<FieldInfo> fields, List<string> basic, Dictionary<string, string> nameMapping)
    {
        var result = new List<object>();
        foreach (var item in basic)
        {
            if (item == string.Empty)
            {
                result.Add(string.Empty);
            }
            else
            {
                var fieldName = item;
                if (nameMapping != null)
                {
                    fieldName = nameMapping[item];
                }
                result.Add(fields.Where(field => field.Name == fieldName).First().GetValue(source)!);
            }
        }
        return result;
    }
}
