using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


namespace Practica_12
{
   public class Ejercicio1
    {
        [Serializable]
        public struct Mascota
        {
            public string nombre;
            public string especie;
            public string sexo;
            public int edad;

        }


        static void Main(string[] args)
        {

            Mascota mascota1 = new Mascota();
            FileStream fs;
            BinaryFormatter formatter = new BinaryFormatter();
            const string ARCHIVO = "mascota.bin";
            try
            {

                Console.Write("Nombre: ");
                mascota1.nombre = Console.ReadLine();
                Console.Write("Especie: ");
                mascota1.especie = Console.ReadLine();
                Console.Write("Sexo: ");
                mascota1.sexo = Console.ReadLine();
                Console.Write("Edad: ");
                mascota1.edad = Convert.ToInt32(Console.ReadLine());
                fs = new FileStream(ARCHIVO, FileMode.Create, FileAccess.Write);
                formatter.Serialize(fs, mascota1);
                fs.Close();


            }
            catch (Exception)
            {
                Console.WriteLine("Ocurrio un problema con la serializacion...");
            }
            Console.ReadKey();
        }

    }
}
