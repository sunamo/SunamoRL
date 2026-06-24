namespace SunamoRL.RL;

public class ResourceLoaderRL
{
    public string GetString(string key) => Translate.FromKey(key);
}
