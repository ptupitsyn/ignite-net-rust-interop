using System.Runtime.InteropServices;
using Apache.Ignite.Core;
using Apache.Ignite.Core.Client;
using Apache.Ignite.Core.Client.Cache;
using Apache.Ignite.Core.Log;

public static class Exports
{
    private static readonly Lazy<IIgniteClient> Client = new(
        () => Ignition.StartClient(new IgniteClientConfiguration("127.0.0.1:10800")
        {
            Logger = new ConsoleLogger
            {
                MinLevel = LogLevel.Trace
            }
        }));

    [UnmanagedCallersOnly(EntryPoint = "CachePut")]
    public static void CachePut(int key, int val) => Cache.Put(key, val);

    [UnmanagedCallersOnly(EntryPoint = "CacheGet")]
    public static int CacheGet(int key) => Cache.Get(key);

    private static ICacheClient<int, int> Cache => Client.Value.GetOrCreateCache<int, int>("c");
}
