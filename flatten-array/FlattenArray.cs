using System.Collections;

public static class FlattenArray
{
    public static IEnumerable Flatten(IEnumerable input)
    {
        List<object?> result = [];
        foreach (var item in input)
        {
            if (item == null) continue;
            if (item.GetType() == typeof(object[]))
                foreach (var o in Flatten((IEnumerable)item))
                {
                    result.Add(o);
                }
            else result.Add(item);
        }
        return result;
    }
}