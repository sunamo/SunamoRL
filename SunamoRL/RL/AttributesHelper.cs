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

    /// <summary>
    /// Returns the field values for the captions without throwing: a field is found by the Name of its DataMember attribute, then through the name mapping, then by its own name; an unknown caption or a null value gives an empty string.
    /// </summary>
    /// <param name="source">The instance the values are read from.</param>
    /// <param name="fields">The fields of the instance.</param>
    /// <param name="captions">The captions; an empty caption gives an empty string.</param>
    /// <param name="nameMapping">Optional mapping from a caption to a field name.</param>
    /// <returns>One value per caption, in the order of the captions.</returns>
    public static List<object> DataMemberOrEmpty(object source, List<FieldInfo> fields, List<string> captions, Dictionary<string, string>? nameMapping = null)
    {
        var result = new List<object>();
        foreach (var caption in captions)
        {
            if (string.IsNullOrEmpty(caption))
            {
                result.Add(string.Empty);
                continue;
            }

            var field = fields.FirstOrDefault(candidate => candidate.GetCustomAttribute<DataMemberAttribute>()?.Name == caption);
            if (field == null && nameMapping != null && nameMapping.TryGetValue(caption, out var fieldName))
            {
                field = fields.FirstOrDefault(candidate => candidate.Name == fieldName);
            }

            if (field == null && nameMapping == null)
            {
                field = fields.FirstOrDefault(candidate => candidate.Name == caption);
            }

            result.Add(field?.GetValue(source) ?? string.Empty);
        }

        return result;
    }
}
