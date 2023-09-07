using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace MovieClassLibrary
{
    public class DataSerializerDeserializer
    {
        public static void BinarySerializer(List<Movie> data, string filePath)
        {
            using (FileStream fileStream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fileStream, data);
            }
        }

        public static List<Movie> BinaryDeserialize(string filePath)
        {
            List<Movie> movie = new List<Movie>();
            using (FileStream fileStream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Read))
            {
                if (fileStream.Length > 0)
                {
                    BinaryFormatter binaryFormatter = new BinaryFormatter();
                    movie = binaryFormatter.Deserialize(fileStream) as List<Movie>;
                }

            }
            return movie;
        }
    }
}
