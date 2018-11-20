using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using System.IO;


namespace Entidades
{
    public class LosHilos : IRespuesta<int> 
    {
        private static int id = 0;
        private List<InfoHilo> misHilos;        

        public LosHilos()
        {
            misHilos = new List<InfoHilo>();
        }

        public string Bitacora
        {
            get
            {
                StreamReader sr = null;
                string texto = "";

                try
                {
                    string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/bitacora.txt";
                    sr = new StreamReader(path);
                    texto = sr.ReadToEnd();
                }
                catch (Exception)
                {
                    throw new Exception();
                }
                finally
                {
                    sr.Close();
                }
                return texto; 
            }

            set
            {
                StreamWriter sw = null;           
                string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/bitacora.txt";

                try
                {
                    sw = new StreamWriter(path, true);
                    sw.Write(value);
                }
                catch (Exception)
                {
                    throw new Exception();
                }
                finally
                {
                    sw.Close();
                }
            }
        }

        public delegate void Hilos(string mensaje);
        public event Hilos AvisoFin;

        public void RespuestaHilo(int id)
        {
            string mensaje = String.Format("Termino el hilo {0}", id);
            this.Bitacora = mensaje;
            this.AvisoFin(mensaje);
        }

        private static LosHilos AgregarHilo(LosHilos hilos)
        {
            id++;
            IRespuesta<int> losHilos = hilos;
            InfoHilo infoHilo = new InfoHilo(id, losHilos);
            hilos.misHilos.Add(infoHilo);
            return hilos; 
        }

        public static LosHilos operator +(LosHilos hilos, int cantidad)
        {
            if (cantidad < 1)
                throw new CantidadInvalidaException();

            else
                for(int i = 0; i < cantidad; i++)
                {
                    LosHilos.AgregarHilo(hilos);
                }

            return hilos; 
        }
    }
}
