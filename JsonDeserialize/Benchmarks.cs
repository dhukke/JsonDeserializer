using BenchmarkDotNet.Attributes;

namespace JsonDeserialize;

[MemoryDiagnoser(true)]
public class Benchmarks
{
    [Benchmark]
    public List<MyObject> Stream()
    {
        var deserializer = new Deserializer();
        return deserializer.Deserialize();
    }
}
