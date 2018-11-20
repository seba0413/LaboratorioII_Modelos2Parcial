using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Interfaces;

namespace Entidades
{
    public class InfoHilo
    {
        private int id;
        private IRespuesta<int> callback;
        private static Random randomizer;
        private Thread hilo;

        static InfoHilo()
        {
            randomizer = new Random();
        }

        public InfoHilo(int id, IRespuesta<int> callback)
        {
            this.id = id;
            this.callback = callback;
            hilo = new Thread(Ejecutar);
            hilo.Start();
        }

        private void Ejecutar()
        {
            int tiempo = randomizer.Next(1000, 5000);
            Thread.Sleep(tiempo);
            this.callback.RespuestaHilo(this.id);
            hilo.Abort();
        }
    }
}
