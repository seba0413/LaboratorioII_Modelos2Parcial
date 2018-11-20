using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

namespace Entidades
{
    public class Persona : Corredor
    {
        private string nombre;

        public Persona(string nombre, short velocidadMax, Carril carril):base(velocidadMax, carril)
        {
            this.nombre = nombre; 
        }

        public string Nombre
        {
            get
            {
                return this.nombre;
            }
        }

        public delegate void CorrenCallBack(int avance, Corredor corredor);
        public event CorrenCallBack Corriendo;

        public override void Correr()
        {
            while (true)
            {
                this.VelocidadMaxima = (short) Corredor.avance.Next(1, 10);
                this.Corriendo((int) this.VelocidadMaxima, this);
                Thread.Sleep(1000);
            }
        }

        public override void Guardar(string path)
        {
            StreamWriter sw = null;
            try
            {
                sw = new StreamWriter(path, true);
                sw.WriteLine(this.nombre);
            }
            catch (Exception e)
            {
                throw new NoSeGuardoException(e.Message);
            }
            finally
            {
                sw.Close();
            }
        }

        public override string ToString()
        {
            string texto = String.Format("{0} en carril {1} a una velocidad maxima de {2}\n", this.nombre, this.carrilElejido, this.VelocidadMaxima);
            return texto; 
        }
    }
}
