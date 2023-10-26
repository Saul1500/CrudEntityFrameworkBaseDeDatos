using Guia_Entity_Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

class Program
{
    static void Main()
    {
        using (var contextdb = new ContextDB())
        {
            bool Continuar = true;
            while (Continuar)
            {
                Console.WriteLine("***********************************************");
                Console.WriteLine("");
                Console.WriteLine("BIENVENIDOS AL MENU DEL CRUD DE LA BASE DE DATOS");
                Console.WriteLine("");
                Console.WriteLine("***********************************************");
                Console.WriteLine("");
                Console.WriteLine("1 Insertar Datos");
                Console.WriteLine("");
                Console.WriteLine("2 Actualizar Datos");
                Console.WriteLine("");
                Console.WriteLine("3 Eliminar Datos");
                Console.WriteLine("");

                int op1 = Convert.ToInt32(Console.ReadLine());

                switch (op1)
                {
                    case 1:
                        contextdb.Database.EnsureCreated();

                        Student estudiante = new Student();

                        Console.WriteLine("Ingrese el Nombre: ");
                        estudiante.Nombres = Console.ReadLine();

                        Console.WriteLine("");

                        Console.WriteLine("Ingrese el Apellido: ");
                        estudiante.Apellidos = Console.ReadLine();

                        Console.WriteLine("");

                        Console.WriteLine("Ingrese el Sexo: ");
                        estudiante.Sexo = Console.ReadLine();

                        Console.WriteLine("");

                        Console.WriteLine("Ingrese el Edad: ");
                        estudiante.Edad = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("");

                        contextdb.Add(estudiante);
                        contextdb.SaveChanges();

                        Console.WriteLine("Datos Agregados Correctamente.");
                        Console.WriteLine("");
                        break;

                    case 2:
                        Console.WriteLine("Ingrese el Id del registro que desea modificar");
                        var id = Console.ReadLine();
                        var persona = contextdb.Estudiantes.FirstOrDefault(p => p.Id == Int32.Parse(id));

                        if (persona != null)
                        {
                            Console.WriteLine("");
                            Console.WriteLine("Que opción desea modificar");
                            Console.WriteLine("");
                            Console.WriteLine("1 Nombre");
                            Console.WriteLine("");
                            Console.WriteLine("2 Apellido");
                            Console.WriteLine("");
                            Console.WriteLine("3 Sexo");
                            Console.WriteLine("");
                            Console.WriteLine("4 Edad");

                            int op = Convert.ToInt32(Console.ReadLine());
                            switch (op)
                            {
                                
                                case 1:
                                    Console.WriteLine("");
                                    Console.WriteLine("Ingrese el nuevo nombre: ");
                                    persona.Nombres = Console.ReadLine();
                                    Console.WriteLine("");
                                    Console.WriteLine("Datos Actualizados Correctamente.");
                                    break;
                                case 2:
                                    Console.WriteLine("");
                                    Console.WriteLine("Ingrese el nuevo Apellido: ");                                   
                                    persona.Apellidos = Console.ReadLine();
                                    Console.WriteLine("");
                                    Console.WriteLine("Datos Actualizados Correctamente.");
                                    break;
                                case 3:
                                    Console.WriteLine("");
                                    Console.WriteLine("Ingrese el nuevo Sexo: ");
                                    persona.Sexo = Console.ReadLine();
                                    Console.WriteLine("");
                                    Console.WriteLine("Datos Actualizados Correctamente.");
                                    break;
                                case 4:
                                    Console.WriteLine("");
                                    Console.WriteLine("Ingrese la nueva Edad: ");
                                    if (int.TryParse(Console.ReadLine(), out int nuevaEdad))
                                    {
                                        persona.Edad = nuevaEdad;
                                    }
                                    Console.WriteLine("");
                                    Console.WriteLine("Datos Actualizados Correctamente.");
                                    break;

                            }
                            contextdb.SaveChanges();
                        }
                        else
                        {
                            Console.WriteLine("");
                            Console.WriteLine("Registro no encontrado");
                        }
                        break;
                    case 3:
                        Console.WriteLine("");
                        Console.WriteLine("Ingrese el ID del registro que desea eliminar");
                        var Id = Console.ReadLine();
                        var Persona = contextdb.Estudiantes.SingleOrDefault(x => x.Id == Int32.Parse(Id));
                        if (Persona != null)
                        {
                            contextdb.Estudiantes.Remove(Persona);
                            contextdb.SaveChanges();
                        }
                        Console.WriteLine("");
                        Console.WriteLine("Datos Borrados Correctamente.");
                        break;
                }
                Console.WriteLine("");
                Console.WriteLine("Desea continuar (EN MAYUSCULAS S/N)? Precione S/N");
                var cont = Console.ReadLine();
                if (cont.Equals("N"))
                {
                    Continuar = false;
                }

            }
            Console.WriteLine("");

            Console.WriteLine("LISTADO DE LOS DATOS:");
            Console.WriteLine("");

            foreach (var s in contextdb.Estudiantes)
            {
                Console.WriteLine($"Nombre: {s.Nombres}, Apellido: {s.Apellidos}, Sexo: {s.Sexo}, Edad: {s.Edad}");
            }

        }
    }
}


// ALUMNO:JOSE SAUL SIBRIAN SERRANO
