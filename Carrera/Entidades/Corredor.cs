using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Corredor
    {
        public enum Carril
        {
            Carril_1,
            Carril_2
        }

        protected static Random avance;
        protected Carril carrilElejido;
        private short velocidadMax; 

        static Corredor()
        {
            avance = new Random();
        }

        protected Corredor(short velocidadMaxima, Carril carril)
        {
            this.VelocidadMaxima = velocidadMaxima;
            this.carrilElejido = carril;
        }

        public short VelocidadMaxima
        {
            get
            {
                return this.velocidadMax;
            }

            set
            {
                if (value > 10)
                    velocidadMax = 10;
                else
                    velocidadMax = value; 
            }
        }

        public Carril CarrilElegido
        {
            get
            {
                return this.carrilElejido;
            }
        }

        public abstract void Correr();

        public virtual void Guardar(string path)
        {
            throw new NotImplementedException();
        }


    }
}
