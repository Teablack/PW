using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using System.IO;

namespace Poda.Tablets.DAO
{
    class Serializer
    {
        public static void Serialize<T>(string fileName, List<T> producers)
        {
            using FileStream fs = new(fileName, FileMode.Create);
            BinaryFormatter binaryFormatter = new();
            binaryFormatter.Serialize(fs, producers);
        }

        public static List<T> Deserialize<T>(string fileName)
        {
            using FileStream fs = new(fileName, FileMode.Open);
            BinaryFormatter binaryFormatter = new();
            return (List<T>)binaryFormatter.Deserialize(fs);
        }
    }
}
