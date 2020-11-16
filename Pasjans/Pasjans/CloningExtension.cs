using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Pasjans
{
    public static class CloningExtension
    {
        public static T Clone<T>(this T obj)
        {
            using var memoryStream = new MemoryStream();
            var formatter = new BinaryFormatter();
            formatter.Serialize(memoryStream, obj);
            memoryStream.Position = 0;

            return (T) formatter.Deserialize(memoryStream);
        }
    }
}