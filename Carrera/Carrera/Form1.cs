using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using System.Threading;

namespace Carrera
{
    public partial class Form1 : Form
    {
        private List<Persona> _corredores;
        private List<Thread> _corredoresActivos;
        private bool _hayGanador;

        private void btncargar_Click(object sender, EventArgs e)
        {       
            pgbCarril1.Maximum = 100;           
            pgbCarril1.Minimum = 0;
            pgbCarril2.Maximum = 100;
            pgbCarril2.Minimum = 0;
        }

        public Form1()
        {
            InitializeComponent();
            this._corredores = new List<Persona>();
            this._corredoresActivos = new List<Thread>();
            this._corredores.Add(new Persona("Andrea", 9, Corredor.Carril.Carril_1));
            this._corredores.Add(new Persona("Sebastian", 5, Corredor.Carril.Carril_2));
            this._hayGanador = false;
            label1.Text = _corredores[0].Nombre;
            label2.Text = _corredores[1].Nombre;
        }

        private void LimpiarCarriles()
        {
            this.pgbCarril1.Value = 0;
            this.pgbCarril2.Value = 0;
        }

        public void PersonaCorriendo(int avance, Corredor corredor)
        {
            if (pgbCarril1.InvokeRequired || pgbCarril2.InvokeRequired)
            {
                Persona.CorrenCallBack d = new Persona.CorrenCallBack(this.PersonaCorriendo);
                this.Invoke(d, new object[] { avance, corredor });
            }
            else
            {
                if (corredor.CarrilElegido == 0)
                    this.AnalizarCarrera(pgbCarril1, avance, corredor);
                else
                    this.AnalizarCarrera(pgbCarril2, avance, corredor);
            }         
        }

        public void AnalizarCarrera(ProgressBar carril, int avance, Corredor corredor)
        {
            corredor.VelocidadMaxima = (short)avance;
            int avanceRealizado = carril.Value;
            avanceRealizado += corredor.VelocidadMaxima;
            if (avanceRealizado < carril.Maximum)
                carril.Value = avanceRealizado;
            else
            {
                carril.Value = carril.Maximum;
                _hayGanador = true;
            }               

            if(_hayGanador)
            {
                this.HayGanador(corredor);
            }
        }

        public void HayGanador(Corredor corredor)
        {
            foreach (Thread t in this._corredoresActivos)
                t.Abort();
            Persona p = corredor as Persona;
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/ganadores.txt";
            p.Guardar(path);
            MessageBox.Show(String.Format("Gana el corredor: {0}", p.Nombre));
            this._hayGanador = false; 
        }

        private void btnCorrer_Click(object sender, EventArgs e)
        {
            this.LimpiarCarriles();

            _corredores[0].Corriendo += PersonaCorriendo;
            _corredores[1].Corriendo += PersonaCorriendo;

            Thread t1 = new Thread(_corredores[0].Correr);
            Thread t2 = new Thread(_corredores[1].Correr);

            _corredoresActivos.Add(t1);
            _corredoresActivos.Add(t2);

            foreach (Thread t in this._corredoresActivos)
                t.Start();

        }
    }
}
