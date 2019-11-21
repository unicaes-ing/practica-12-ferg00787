using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

using System.Threading.Tasks;

namespace Practica_12
{
    class Ejercicio3
    {
        class Program
        {
            [Serializable]
            #region structura
            public struct alumno
            {
                //carnet nombre carrera cum
                public string carnet;
                public string nombre;
                public string carrera;
                private decimal cum;
                public void serCum(decimal cum)
                {
                    if (cum > 0)
                    {
                        this.cum = cum;
                    }
                }
                public decimal getCum()
                {
                    return cum;
                }
            }
            #endregion
            #region Creacion Stram Bin
            private static Dictionary<string, alumno> dAlumnos = new Dictionary<string, alumno>();
            private static BinaryFormatter formatter = new BinaryFormatter();
            private const string N_ARCH = "alumnos.bin";
            #endregion
            #region saver
            public static bool gDiccionario(Dictionary<string, alumno> dAlumnos)
            {
                try
                {
                    FileStream fs = new FileStream(N_ARCH, FileMode.Create, FileAccess.Write);
                    formatter.Serialize(fs, dAlumnos);
                    fs.Close();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            #endregion
            #region reader
            public static bool leerDiccionario()
            {
                try
                {
                    FileStream fs = new FileStream(N_ARCH, FileMode.Open, FileAccess.Read);
                    dAlumnos = (Dictionary<string, alumno>)formatter.Deserialize(fs);
                    fs.Close();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            #endregion
            public void ejer3()
            {
                if (File.Exists(N_ARCH))
                {
                    leerDiccionario();
                }
                else
                {
                    gDiccionario(dAlumnos);
                }
            }


            static void Main(string[] args)
            {

                int op;
                do
                {
                    Console.Clear();
                    Console.WriteLine("===== MENU =====");
                    Console.WriteLine(" 1. Agregar alumno.");
                    Console.WriteLine(" 2. Mostrar alumnos.");
                    Console.WriteLine(" 3. Buscar alumno.");
                    Console.WriteLine(" 4. Editar alumno");
                    Console.WriteLine(" 5. Eliminar alumno");
                    Console.WriteLine(" 6. Salir");
                    Console.WriteLine("======================");

                    op = Convert.ToInt32(Console.ReadLine());

                    switch (op)
                    {
                        case 1:
                            //Agregar
                            #region Opccion1
                            Console.Clear();
                            Console.WriteLine("===== AGREGAR =====");
                            alumno alumn = new alumno();
                            do
                            {
                                Console.WriteLine("Carnet: ");
                                alumn.carnet = Console.ReadLine();
                                if (dAlumnos.ContainsKey(alumn.carnet))
                                {
                                    Console.WriteLine("El carnet: {0} ya existe...", alumn.carnet);
                                }
                            } while (dAlumnos.ContainsKey(alumn.carnet));
                            Console.WriteLine("Nombre: ");
                            alumn.nombre = Console.ReadLine();
                            Console.WriteLine("Carrera: ");
                            alumn.carrera = Console.ReadLine();
                            Console.WriteLine("CUM: ");
                            alumn.serCum(Convert.ToDecimal(Console.ReadLine()));
                            dAlumnos.Add(alumn.carnet, alumn);
                            gDiccionario(dAlumnos);
                            Console.WriteLine("Los datos se almacenaron correctamente");
                            Console.WriteLine("Presione <ENTER> para continuar.");
                            Console.ReadKey();
                            #endregion
                            break;

                        case 2:
                            //Mostrar
                            #region Opccion 2
                            Console.Clear();
                            try
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Datos de los alumnos.");
                                Console.WriteLine();
                                Console.ResetColor();
                                Console.WriteLine("{0,-10}    {1,-10}   {2,5}    {3,8}", "Carnet", "Nombre", "Carrera", "CUM");
                                Console.WriteLine("==========================================================================");
                                leerDiccionario();
                                foreach (KeyValuePair<string, alumno> alumnoG in dAlumnos)
                                {
                                    alumno alumns = alumnoG.Value;
                                    Console.WriteLine("{0,-10}    {1,-10}    {2,5}    {3,8}",
                                    alumns.carnet, alumns.nombre, alumns.carrera, alumns.getCum());
                                }
                                Console.WriteLine("=========================================================================");
                                Console.WriteLine(" Presione <ENTER> para continuar.");
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                                throw;
                            }
                            Console.ReadKey();
                            #endregion
                            break;

                        case 3:
                            //Buscar
                            #region Opccion 3
                            Console.Clear();
                            string carnetBusc;
                            Console.WriteLine("Ingrese el carnet del alumno que desea buscar:");
                            carnetBusc = Console.ReadLine();
                            if (dAlumnos.ContainsKey(carnetBusc))
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine(" ALUMNO ENCONTRADO");
                                Console.ResetColor();
                                Console.WriteLine("{0,3}    {1,-10}   {2,5}    {3,8}", "Carnet", "Nombre", "Carrera", "CUM");
                                Console.WriteLine("=========================================================================");
                                leerDiccionario();
                                Console.WriteLine("{0,3}    {1,-10}    {2,5}    {3,8}",
                                    dAlumnos[carnetBusc].carnet, dAlumnos[carnetBusc].nombre, dAlumnos[carnetBusc].carrera, dAlumnos[carnetBusc].getCum());
                            }
                            else
                            {
                                Console.WriteLine("El carnet: " + carnetBusc + " no esta registrado.");
                            }
                            Console.WriteLine(" Presione <ENTER> para continuar.");
                            Console.ReadKey();
                            #endregion
                            break;

                        case 4:
                            //Modificar
                            #region Opccion 4
                            Console.Clear();
                            string cMod;
                            Console.WriteLine("Ingrese el carnet del alumno que desea modificar:");
                            cMod = Console.ReadLine();
                            if (dAlumnos.ContainsKey(cMod))
                            {
                                Console.WriteLine("===== MODIFICAR =====");
                                dAlumnos.Remove(cMod);
                                alumno alumnN = new alumno();
                                do
                                {
                                    Console.WriteLine("Carnet: ");
                                    alumnN.carnet = Console.ReadLine();
                                    if (dAlumnos.ContainsKey(alumnN.carnet))
                                    {
                                        Console.WriteLine("El carnet: {0} ya existe...", alumnN.carnet);
                                    }
                                } while (dAlumnos.ContainsKey(alumnN.carnet));
                                Console.WriteLine("Nombre: ");
                                alumnN.nombre = Console.ReadLine();
                                Console.WriteLine("Carrera: ");
                                alumnN.carrera = Console.ReadLine();
                                Console.WriteLine("CUM: ");
                                alumnN.serCum(Convert.ToDecimal(Console.ReadLine()));
                                dAlumnos.Add(alumnN.carnet, alumnN);
                                gDiccionario(dAlumnos);
                                Console.WriteLine(" Datos almacenados Correctamente");
                                Console.WriteLine(" Presione <ENTER> para continuar.");
                                Console.ReadKey();
                            }
                            else
                            {
                                Console.WriteLine("El carnet: " + cMod + " no esta registrado.");
                            }
                            #endregion
                            break;
                        case 5:
                            //Eliminar
                            #region Opccion 5
                            Console.Clear();
                            string cElim;
                            Console.WriteLine("Ingrese el carnet del alumno que desea eliminar: ");
                            cElim = Console.ReadLine();
                            if (dAlumnos.ContainsKey(cElim))
                            {
                                dAlumnos.Remove(cElim);
                            }
                            gDiccionario(dAlumnos);
                            #endregion
                            break;
                    }
                } while (op != 6);

            }

        }
    }
}
