namespace SunamoRL._sunamo.SunamoCollectionsGeneric;

// Must be here because SunamoValues cannot inherit from SunamoCollectionGeneric (cycle detected).
internal class CAGConsts
{
    internal static List<T> ToList<T>(params T[] values)
    {
        return values.ToList();
    }
}
