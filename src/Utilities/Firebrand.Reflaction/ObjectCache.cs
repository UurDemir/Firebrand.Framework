namespace Firebrand.Reflaction;

/// <summary>
/// Provides a cache for objects created through reflection.
/// </summary>
public static class ObjectCache
{
    private static readonly Dictionary<Type, object> cache = new();

    /// <summary>
    /// Retrieves an instance of the specified type from the cache, or creates a new instance and adds it to the cache.
    /// </summary>
    /// <typeparam name="T">The type of the instance to retrieve or create.</typeparam>
    /// <returns>The cached instance, or a new instance of the specified type if one is not found in the cache.</returns>
    public static T GetOrCreateInstance<T>()
    {
        if (cache.TryGetValue(typeof(T), out var obj))
            return (T)obj;

        var createdObject = Activator.CreateInstance<T>();
        cache[typeof(T)] = createdObject!;

        return createdObject;
    }
}
