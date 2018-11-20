using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Entidades
{
    public class Torneo : IEntradaSalida <bool>
    {
        public const short MAX_EQUIPOS_GRUPO = 4;
        private List<Grupo> grupos;
        private string nombre; 
        
        public Torneo(string nombre)
        {
            this.grupos = new List<Grupo>();
            this.nombre = nombre;
        }

        public delegate void Resultados(Grupo grupo);
        public event Resultados eventoResultados;

        public List<Grupo> Grupos
        {
            get
            {
                return this.grupos;
            }

            set
            {
                this.grupos = value; 
            }
        }

        public bool Guardar()
        {
            bool todoOk = false;

            XmlTextWriter writer = null;
            XmlSerializer ser;

            try
            {
                foreach (Grupo g in this.grupos)
                {
                    writer = new XmlTextWriter(String.Format("grupo-{0}.xml", g.NombreGrupo.ToString()), Encoding.ASCII);
                    ser = new XmlSerializer(typeof(Grupo));
                    ser.Serialize(writer, g);
                }
                todoOk = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                writer.Close();
            }
            return todoOk;
        }

        public bool Leer()
        {
            bool todoOk = false;
            bool encuentra = false; 
            string[] letrasGrupos = {"A", "B", "C", "D", "E", "F", "G", "H"};
            XmlTextReader reader = null;
            XmlSerializer ser;
            Grupo grupo;

            if (this.grupos.Count != 8)
            {
                for (int i = 0; i < letrasGrupos.Length; i++)
                {
                    foreach (Grupo g in this.grupos)
                    {
                        if (letrasGrupos[i] == g.NombreGrupo.ToString())
                        {
                            encuentra = true;
                            break;
                        }
                    }

                    if (!encuentra)
                    {
                        todoOk = false; 
                        try
                        {
                            reader = new XmlTextReader(String.Format("grupo-{0}.xml", letrasGrupos[i]));
                            ser = new XmlSerializer(typeof(Grupo));
                            grupo = (Grupo)ser.Deserialize(reader);
                            this.grupos.Add(grupo);
                            todoOk = true;

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        finally
                        {
                            reader.Close();
                        }
                    }
                }
            }
            else
                todoOk = true; 

            return todoOk;

        }

        public void SimularGrupos()
        {
            foreach (Grupo grupo in this.grupos)
            {
                grupo.Simular();
                eventoResultados(grupo);
            }

        }
                
    }
}
