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

namespace Programacion22017
{
    public partial class Form1 : Form
    {
        LosHilos hilos; 

        public Form1()
        {
            InitializeComponent();
            hilos = new LosHilos();
        }

        public void MostrarMensajeFin(string mensaje)
        {
            MessageBox.Show(mensaje);  
        }

        private void btnLanzar_Click(object sender, EventArgs e)
        {
            try
            {
                hilos.AvisoFin += MostrarMensajeFin;
                hilos = hilos + 3;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }            
        }

        private void btnBitacora_Click(object sender, EventArgs e)
        {
            MessageBox.Show(hilos.Bitacora);
        }
    }
}
