using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; //Agregar la libreria

namespace DeTextoUno
{
    class DeTextoUno
    {

        //Atributos
        String nombre;
        decimal sueldo;
        Int16 edad;
        String telefono;
        Int16 ciclo, cuantos;

        public void EscribirDatos()
        {
            Int16 ciclo, cuantos;

            StreamWriter registro;
            registro = new StreamWriter("C://VS2015//U_1//archivosGenerados//Agenda.txt", true);
            Console.WriteLine("Cuantas veces?");
            cuantos = Convert.ToInt16(Console.ReadLine());

            for (ciclo = 0; ciclo < cuantos; ciclo++)
            {

                Console.WriteLine("Nombre");
                nombre = Convert.ToString(Console.ReadLine());

                Console.WriteLine("Sueldo?");
                sueldo = Convert.ToDecimal(Console.ReadLine());

                Console.WriteLine("Edad?");
                edad = Convert.ToInt16(Console.ReadLine());

                Console.WriteLine("Telefono?");
                telefono = Convert.ToString(Console.ReadLine());

                //GRABAR LOS DATOS
                registro.WriteLine(nombre);
                registro.WriteLine(sueldo);
                registro.WriteLine(edad);
                registro.WriteLine(telefono);

            }

            registro.Close();
        }

        public void EscribeBinario()
        {
            Int16 ciclo, cuantos;

            Stream registro;
            registro = File.Open("C://VS2015//U_1//archivosGenerados//Agenda.bin", FileMode.Append,FileAccess.Write);
            BinaryWriter NIA = new BinaryWriter(registro); //Conexion con el archivo binario intermedio
            Console.WriteLine("Cuantas veces?");
            cuantos = Convert.ToInt16(Console.ReadLine());

            for (ciclo = 0; ciclo < cuantos; ciclo++)
            {

                Console.WriteLine("Nombre");
                nombre = Convert.ToString(Console.ReadLine());

                Console.WriteLine("Sueldo?");
                sueldo = Convert.ToDecimal(Console.ReadLine());

                Console.WriteLine("Edad?");
                edad = Convert.ToInt16(Console.ReadLine());

                Console.WriteLine("Telefono?");
                telefono = Convert.ToString(Console.ReadLine());

                //GRABAR LOS DATOS
                NIA.Write(nombre);
                NIA.Write(sueldo);
                NIA.Write(edad);
                NIA.Write(telefono);

            }

            registro.Close();
        }

        public void LeerDatos()
        {
          
            StreamReader registro;
            registro = new StreamReader("C://VS2015//U_1//archivosGenerados//Agenda.txt");

            do
            {
                Console.WriteLine("El dato leido");
                Console.WriteLine(registro.ReadLine());
                Console.ReadLine();

            } while (!(registro.EndOfStream));

            registro.Close();
        }


        public void LeerBinario()
        {

            Stream registro;
            registro = File.Open("C://VS2015//U_1//archivosGenerados//Agenda.bin", FileMode.Open, FileAccess.Read);
            BinaryReader NIA = new BinaryReader(registro); //Conexion con el archivo binario intermedio
           

            do
            {
                nombre = NIA.ReadString();
                Console.WriteLine("Nombre:{0}",nombre);


                sueldo = NIA.ReadDecimal();
                Console.WriteLine("Sueldo:{0}", sueldo);


                edad = NIA.ReadInt16();
                Console.WriteLine("Edad:{0}", edad);


                telefono = NIA.ReadString();
                Console.WriteLine("Telefono:{0}", telefono);
                Console.ReadLine();


            } while (NIA.PeekChar()!=-1);

            registro.Close();
        }


        static void Main(string[] args)
        {

            DeTextoUno obj = new DeTextoUno();
            //Ejecute lectura

            // obj.EscribirDatos();
            // obj.LeerDatos();
            //obj.EscribeBinario();
            obj.LeerBinario();

            Console.ReadLine();
        }

       
    }
}
