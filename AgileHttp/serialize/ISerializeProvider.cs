namespace AgileHttp.serialize
{
    public interface ISerializeProvider
    {
        T Deserialize<T>(string content);
        string Serialize(object obj);
    }
}