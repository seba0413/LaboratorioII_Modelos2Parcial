using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Threading;

namespace _20180626_SP_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Torneo t = new Torneo("Rusia 2018");
            Console.Title = "Copa Mundial Rusia 2018";
            Grupo grupoA = new Grupo(Letras.A, Torneo.MAX_EQUIPOS_GRUPO);
            Grupo grupoB = new Grupo(Letras.B, Torneo.MAX_EQUIPOS_GRUPO);
            Grupo grupoC = new Grupo(Letras.C, Torneo.MAX_EQUIPOS_GRUPO);
            Grupo grupoD = new Grupo(Letras.D, Torneo.MAX_EQUIPOS_GRUPO);
            grupoA.Leer();
            grupoB.Leer();
            grupoC.Leer();
            grupoD.Leer();
            t.Grupos.Add(grupoA);
            t.Grupos.Add(grupoB);
            t.Grupos.Add(grupoC);
            t.Grupos.Add(grupoD);

            t.eventoResultados += ImprimirResultados;

            // Agregar Thread
            Thread hilo1 = new Thread(t.SimularGrupos);
            hilo1.Start();

            // **************
            t.Guardar();

            Console.WriteLine("Presione una tecla para continuar...");
            Console.ReadKey();
            Console.Clear();

            Torneo t2 = new Torneo("Superliga 2018");
            t2.Leer();

            Thread hilo2 = new Thread(t2.SimularGrupos);
            hilo2.Start();

            Console.ReadKey();


        }

        public static void ImprimirResultados(Grupo grupo)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine();
            sb.AppendFormat("Grupo: {0}\nCantidad Maxima de equipos: {1}\n", grupo.NombreGrupo, grupo.CantidadMaxima);
            sb.AppendLine("EQUIPOS DEL GRUPO");
            foreach (Equipo equipo in grupo.Equipos)
            {
                sb.AppendLine(equipo.ToString());
            }
            Console.Write(sb.ToString());
        }


    }
}
