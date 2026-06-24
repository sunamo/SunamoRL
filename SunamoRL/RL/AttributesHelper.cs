namespace SunamoRL.RL;

public class AttributesHelper
{
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
