using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAI_TP4
{
    class CASOS
    {
        public static string rutaCursosSistemas = @"C:\Users\marin\Documents\CURSOSSISTEMAS.csv";
        public static string rutaCursosContador = @"C:\Users\marin\Documents\CURSOSCONTADOR.csv";
        public static string rutaCursosAdmin = @"C:\Users\marin\Documents\CURSOSADMIN.csv";
        public static string rutaCursosEconomia = @"C:\Users\marin\Documents\CURSOSECONOMIA.csv";
        public static string rutaCursosActuario = @"C:\Users\marin\Documents\CURSOSACTUARIO.csv";

        public static string rutaMateriasSistemas = @"C:\Users\marin\Documents\MATERIASSISTEMAS.csv";
        public static string rutaMateriasContador = @"C:\Users\marin\Documents\MATERIASCONTADOR.csv";
        public static string rutaMateriasAdmin = @"C:\Users\marin\Documents\MATERIASADMIN.csv";
        public static string rutaMateriasEconomia = @"C:\Users\marin\Documents\MATERIASECONOMIA.csv";
        public static string rutaMateriasActuario = @"C:\Users\marin\Documents\MATERIASACTUARIO.csv";

        public static void Case1()
        {
            string nombreAlumno = "";
            int numero1 = 1;
            int numero2 = 5;
            bool esRegistroValido;
            bool opcionCarreraValida;

            do
            {
                Console.Write("Ingrese su número de registro: ");
                string registroIng = Console.ReadLine();
                esRegistroValido = VALIDACION.ValidarRegistro(registroIng);
                if (!esRegistroValido)
                {
                    continue;
                }
                Console.WriteLine("Número de registro válido.");
                INSCRIPCIONES.MostrarAlumno(registroIng, ref nombreAlumno);
                Console.WriteLine($"Hola {nombreAlumno}!\n");
                do
                {
                    Console.WriteLine("Seleccione un número correspondiente a su carrera para inscribirse: ");
                    Console.WriteLine("'1' Contador Público");
                    Console.WriteLine("'2' Lic. Administación");
                    Console.WriteLine("'3' Lic. Economía");
                    Console.WriteLine("'4' Lic. Sistemas");
                    Console.WriteLine("'5' Actuario");
                    string opcionCarrera = Console.ReadLine();
                    opcionCarreraValida = VALIDACION.ValidarMenu(opcionCarrera, numero1, numero2);
                    if (opcionCarreraValida == false)
                    {
                        continue;
                    }
                    if (INSCRIPCIONES.CarreraEnArchivoIgual(registroIng, opcionCarrera) == false)
                    {
                        opcionCarreraValida = false;
                        continue;
                    }
                    else
                    {
                        if (opcionCarrera == "1")
                        {
                            VALIDACION.Carrera = 1;
                            INSCRIPCIONES.ParaTodasLasCarreras(registroIng, rutaMateriasContador, rutaCursosContador);
                        }
                        if (opcionCarrera == "2")
                        {
                            VALIDACION.Carrera = 2;
                            INSCRIPCIONES.ParaTodasLasCarreras(registroIng, rutaMateriasAdmin, rutaCursosAdmin);
                        }
                        if (opcionCarrera == "3")
                        {
                            VALIDACION.Carrera = 3;
                            INSCRIPCIONES.ParaTodasLasCarreras(registroIng, rutaMateriasEconomia, rutaCursosEconomia);
                        }
                        if (opcionCarrera == "4")
                        {
                            VALIDACION.Carrera = 4;
                            INSCRIPCIONES.ParaTodasLasCarreras(registroIng, rutaMateriasSistemas, rutaCursosSistemas);
                        }
                        if (opcionCarrera == "5")
                        {
                            VALIDACION.Carrera = 5;
                            INSCRIPCIONES.ParaTodasLasCarreras(registroIng, rutaMateriasActuario, rutaCursosActuario);
                        }
                    }
                } while (!opcionCarreraValida);

            } while (!esRegistroValido);
        }

        public static void Case2()
        {
            bool estaInscripto;
            bool esRegistroValido;
            do
            {
                Console.WriteLine("Ingrese un número de registro para obtener el estado actual de inscripción: ");
                string registroIng = Console.ReadLine();
                esRegistroValido = VALIDACION.ValidarRegistro(registroIng);
                if (!esRegistroValido)
                {
                    continue;
                }

                string materiasYcursos = "";
                estaInscripto = INSCRIPCIONES.InscripcionesPorReg(registroIng, ref materiasYcursos);
                if (estaInscripto)
                {
                    Console.WriteLine($"El registro '{registroIng}' solicitó la inscripción en: \n{materiasYcursos}" +
                        $"\nRecuerde que el código de carrera corresponde a lo siguiente: \n '1' Contador Público\n '2' Lic. Administación\n '3' Lic. Economía\n '4' Lic. Sistemas\n '5' Actuario\n");
                    break;
                }
                if (!estaInscripto)
                {
                    Console.WriteLine($"El registro '{registroIng}' no solicitó la inscripción en ninguna materia.\n");
                    break;
                }

            } while (!esRegistroValido);
        }

        public static void Case3()
        {
            string lista = "";
            int numero1 = 1;
            int numero2 = 5;
            bool opcionCarreraValida;

            do
            {
                Console.WriteLine("Seleccione un número correspondiente a la carrera para consultar las materias disponibles:  ");
                Console.WriteLine("'1' Contador Público");
                Console.WriteLine("'2' Lic. Administación");
                Console.WriteLine("'3' Lic. Economía");
                Console.WriteLine("'4' Lic. Sistemas");
                Console.WriteLine("'5' Actuario");
                string opcionCarrera = Console.ReadLine();
                opcionCarreraValida = VALIDACION.ValidarMenu(opcionCarrera, numero1, numero2);
                if (!opcionCarreraValida)
                {
                    continue;
                }
                else
                {
                    if (opcionCarrera == "1")
                    {
                        INSCRIPCIONES.MateriasYCodigos(rutaMateriasContador, ref lista);
                        Console.WriteLine("\nListado de materias disponibles de la carrera de Contador Público: \n");
                        Console.WriteLine(lista);
                        Console.WriteLine("Para el plan de materias ingrese a 'www.economicas.uba.ar/carreras/sistemas/'.\n");
                    }
                    if (opcionCarrera == "2")
                    {
                        INSCRIPCIONES.MateriasYCodigos(rutaMateriasAdmin, ref lista);
                        Console.WriteLine("\nListado de materias disponibles de la carrera de Administración: \n");
                        Console.WriteLine(lista);
                        Console.WriteLine("Para el plan de materias ingrese a 'www.economicas.uba.ar/carreras/sistemas/'.\n");
                    }
                    if (opcionCarrera == "3")
                    {
                        INSCRIPCIONES.MateriasYCodigos(rutaMateriasEconomia, ref lista);
                        Console.WriteLine("\nListado de materias disponibles de la carrera de Economía: \n");
                        Console.WriteLine(lista);
                        Console.WriteLine("Para el plan de materias ingrese a 'www.economicas.uba.ar/carreras/sistemas/'.\n");
                    }
                    if (opcionCarrera == "4")
                    {
                        INSCRIPCIONES.MateriasYCodigos(rutaMateriasSistemas, ref lista);
                        Console.WriteLine("\nListado de materias disponibles de la carrera de Sistemas: \n");
                        Console.WriteLine(lista);
                        Console.WriteLine("Para el plan de materias ingrese a 'www.economicas.uba.ar/carreras/sistemas/'.\n");
                    }
                    if (opcionCarrera == "5")
                    {
                        INSCRIPCIONES.MateriasYCodigos(rutaMateriasActuario, ref lista);
                        Console.WriteLine("\nListado de materias disponibles de la carrera de Actuario: \n");
                        Console.WriteLine(lista);
                        Console.WriteLine("Para el plan de materias ingrese a 'www.economicas.uba.ar/carreras/sistemas/'.\n");
                    }
                }
            } while (!opcionCarreraValida);

        }

        public static void Case4()
        {
            string lista = "";
            int numero1 = 1;
            int numero2 = 5;
            bool opcionCarreraValida;

            do
            {
                Console.WriteLine("Seleccione un número correspondiente a la carrera para consultar los profesores por curso disponibles:  ");
                Console.WriteLine("'1' Contador Público");
                Console.WriteLine("'2' Lic. Administación");
                Console.WriteLine("'3' Lic. Economía");
                Console.WriteLine("'4' Lic. Sistemas");
                Console.WriteLine("'5' Actuario");
                string opcionCarrera = Console.ReadLine();
                opcionCarreraValida = VALIDACION.ValidarMenu(opcionCarrera, numero1, numero2);
                if (!opcionCarreraValida)
                {
                    continue;
                }
                else
                {
                    if (opcionCarrera == "1")
                    {
                        INSCRIPCIONES.ProfesoresPorCurso(rutaCursosContador, ref lista);
                        Console.WriteLine("\nListado de profesores por materia y curso de la carrera de Contador Público: \n");
                        Console.WriteLine(lista);
                    }
                    if (opcionCarrera == "2")
                    {
                        INSCRIPCIONES.ProfesoresPorCurso(rutaCursosAdmin, ref lista);
                        Console.WriteLine("\nListado de profesores por materia y curso de la carrera de Administración: \n");
                        Console.WriteLine(lista);
                    }
                    if (opcionCarrera == "3")
                    {
                        INSCRIPCIONES.ProfesoresPorCurso(rutaCursosEconomia, ref lista);
                        Console.WriteLine("\nListado de profesores por materia y curso de la carrera de Economía: \n");
                        Console.WriteLine(lista);
                    }
                    if (opcionCarrera == "4")
                    {
                        INSCRIPCIONES.ProfesoresPorCurso(rutaCursosSistemas, ref lista);
                        Console.WriteLine("\nListado de profesores por materia y curso de la carrera de Sistemas: \n");
                        Console.WriteLine(lista);
                    }
                    if (opcionCarrera == "5")
                    {
                        INSCRIPCIONES.ProfesoresPorCurso(rutaCursosActuario, ref lista);
                        Console.WriteLine("\nListado de profesores por materia y curso de la carrera de Actuario: \n");
                        Console.WriteLine(lista);
                    }
                }
            } while (!opcionCarreraValida);
        }

        public static void Case0()
        {
            Console.WriteLine("\n \n       Muchas gracias por utilizar el sistema de inscripción de la FCE - UBA." +
                               "\n                     Te esperamos para la próxima inscripción!" +
                                "\n\n                      >Presione una tecla para salir<");
            Console.ReadKey();
        }

    }
}
