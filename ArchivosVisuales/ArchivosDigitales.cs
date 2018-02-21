using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO; //Agregar la libreria

namespace ArchivosVisuales
{
    public partial class ArchivosDigitales : Form
    {
        string[] Lineas;
        Int16 cont = 0;
        Boolean termino = false;
        Stream registro;
        BinaryReader NIA;

        public ArchivosDigitales()
        {
            InitializeComponent();
            //LeerDatosBin();
            LeerDatos();
        }


        public void LeerDatos()
        {

            Lineas= File.ReadAllLines("C://VS2015//U_1//archivosGenerados//Agenda.txt");
           
        }

        public void LeerDatosBin()
        {

            registro = File.Open("C://VS2015//U_1//archivosGenerados//Agenda.bin", FileMode.Open, FileAccess.Read);
            NIA = new BinaryReader(registro); //Conexion con el archivo binario intermedio

        }

        public void desplegarDato() {

            if (cont < Lineas.Count())
            {

                txtNombre.Text = Lineas[cont++];
                txtSueldo.Text = Lineas[cont++];
                txtEdad.Text = Lineas[cont++];
                txtTel.Text = Lineas[cont++];

            }
            else {

                MessageBox.Show("Fin del documento");
                btnContinuar.Text = "Reiniciar";
                termino = true;

            }
           

        }

        public void desplegarDatoBinario()
        {

            if (NIA.PeekChar() != -1)
            {

                txtNombre.Text = NIA.ReadString();
                txtSueldo.Text = "" + NIA.ReadDecimal();
                txtEdad.Text = "" + NIA.ReadInt16();
                txtTel.Text = NIA.ReadString();
            }
            else {

                MessageBox.Show("Fin del documento");
                btnContinuar.Text = "Reiniciar";
                termino = true;
                registro.Close();

            }

           


        }

        private void btnContinuar_Click(object sender, EventArgs e)
        {
            if (!termino)
                desplegarDato();
               // desplegarDatoBinario();
            else
                resetear();
        }

        public void resetear() {
            cont = 0;
            txtNombre.Text = "";
            txtSueldo.Text = "";
            txtEdad.Text = "";
            txtTel.Text = "";
            termino = false;
            btnContinuar.Text = "Continuar";
        }
    }
}
