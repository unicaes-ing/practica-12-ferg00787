using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


namespace Practica_12
{
    class Ejercicio2 : Ejercicio1
    {
        static void Main(string[] args)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            const string ARCHIVO = "mascota.bin";
            try
            {
                Ejercicio1.Mascota m1;
                FileStream fs1;
                formatter = new BinaryFormatter();
                if (File.Exists(ARCHIVO))
                {
                    try
                    {
                        fs1 = new FileStream(ARCHIVO, FileMode.Open, FileAccess.Read);
                        m1 = (Ejercicio1.Mascota)formatter.Deserialize(fs1);
                        fs1.Close();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Datos de la mascota");
                        Console.WriteLine("====================");
                        Console.ResetColor();
                        Console.WriteLine("Nombre: {0}", m1.nombre);
                        Console.WriteLine("Especie: {0}", m1.especie);
                        Console.WriteLine("Sexo: {0}", m1.sexo);
                        Console.WriteLine("Edad: {0}", m1.edad);
                        Console.WriteLine("Presione cualquier tecla para salir...");

                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Ocurrio un problema con la serializacion...");
                    }
                }


            }
            catch (Exception)
            {
                Console.WriteLine("Ocurrio un problema con la serializacion...");
            }


        }
    }
}
