using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AmateurRadioNewsline
{
    static class Serialization
    {
        public static String SerializeToString<T>(this T obj) where T : notnull
        {
            using (StringWriter textWriter = new StringWriter())
            {
                new XmlSerializer(obj.GetType()).Serialize(textWriter, obj);
                return textWriter.ToString();
            }
        }
        public static T? Deserialize<T>(this String s)
        {
            try
            {
                using (StringReader textReader = new StringReader(s))
                    if (new XmlSerializer(typeof(T)).Deserialize(textReader) is T result)
                        return result;
            }
            catch { }
            return default(T);
        }

    }
}
