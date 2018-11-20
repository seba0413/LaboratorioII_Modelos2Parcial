using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Excepciones;

namespace Entidades
{
    public class SerializarXML<T> : IArchivos<T>
    {
        public bool Guardar(string rutaArchivo, T objeto)
        {
            bool todoOk = false; 
            XmlTextWriter writer = null;
            XmlSerializer ser;

            try
            {
                writer = new XmlTextWriter(rutaArchivo, Encoding.ASCII);
                ser = new XmlSerializer(typeof(T));
                ser.Serialize(writer, objeto);
                todoOk = true;
            }
            catch (Exception)
            {
                throw new ErrorArchivoException("Error al serializar el objeto");
            }
            finally
            {
                writer.Close();
            }
            return todoOk;
        }

        public T Leer(string rutaArchivo)
        {
            T objeto;
            XmlTextReader reader = null;
            XmlSerializer ser;

            try
            {
                reader = new XmlTextReader(rutaArchivo);
                ser = new XmlSerializer(typeof(T));
                objeto = (T)ser.Deserialize(reader);
            }
            catch (Exception)
            {
                throw new ErrorArchivoException("Error al deserializar el archivo");
            }
            finally
            {
                reader.Close();
            }
            return objeto;
        }
    }
}
