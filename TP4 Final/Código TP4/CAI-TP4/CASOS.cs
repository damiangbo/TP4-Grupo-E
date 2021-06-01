using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_4;

namespace CAI___TP4
{
    class CASOS
    {
        public static void Case1()
        {
            string nombreAlumno = "";
            string lista = "";
            string cursosYprofesores = "";

            bool esRegistroValido;
            do
            {
                Console.Write("Ingrese su número de registro: ");
                string registroIng = Console.ReadLine();
                esRegistroValido = VALIDACION.ValidarRegistro(registroIng);
                if (esRegistroValido)
                {
                    Console.WriteLine("Número de registro válido.");
                    INSCRIPCIONES.MostrarAlumno(registroIng, ref nombreAlumno);
                    Console.WriteLine($"Hola {nombreAlumno}!\n");
                    bool esCorrectoUltimas4;
                    do
                    {
                        Console.WriteLine("¿Está en las últimas 4 materias? S/N");
                        string ultimas4 = Console.ReadLine().ToUpper();
                        esCorrectoUltimas4 = VALIDACION.ValidarOpcion(ultimas4);
                        if (esCorrectoUltimas4)
                        {
                            bool esRegistroValidoCantidad = INSCRIPCIONES.CantInscripPorReg(registroIng, 3);
                            do
                            {
                                if (esRegistroValidoCantidad)
                                {
                                    bool esMateriaValida;
                                    bool InscripcionMateriaDuplicada;
                                    do
                                    {
                                        Console.WriteLine("\n Seleccione una materia de la siguiente lista:");
                                        INSCRIPCIONES.MateriasYCodigos(ref lista);
                                        Console.WriteLine(lista);
                                        Console.Write("Ingrese Código de Materia: ");
                                        string codigoMateria = Console.ReadLine();
                                        esMateriaValida = VALIDACION.ValidarMateria(codigoMateria);
                                        InscripcionMateriaDuplicada = INSCRIPCIONES.InscripcionMateriaDuplicada(VALIDACION.Registro, VALIDACION.Materia);

                                        if (esMateriaValida && InscripcionMateriaDuplicada)
                                        {
                                            Console.WriteLine("Código de materia válido.\n");
                                            bool esCursoValido;
                                            do
                                            {
                                                Console.WriteLine($"La materia '{codigoMateria}' tiene los cursos y profesores:");
                                                INSCRIPCIONES.CursosPorMateriaElegida(codigoMateria, ref cursosYprofesores);
                                                Console.WriteLine($"{cursosYprofesores}");
                                                Console.Write("Ingrese código de curso: ");
                                                esCursoValido = VALIDACION.ValidarCurso(Console.ReadLine());
                                            }
                                            while (!esCursoValido);
                                            Console.WriteLine("Código de curso validado.");
                                            Console.WriteLine("\nSi desea confirmar la inscripción, por favor ingrese la letra 'S'. Sino, ingrese otro caracter.");
                                            string tecla = Console.ReadLine().ToUpper();

                                            if (tecla == "S")
                                            {
                                                bool InscripcionExitosa = INSCRIPCIONES.GuardarInscripcion(VALIDACION.Registro, VALIDACION.Opcion, VALIDACION.Materia, VALIDACION.Curso);
                                                Console.WriteLine(" INSCRIPCIÓN REGISTRO: " + VALIDACION.Registro + " - " + "\n EN LAS ÚLTIMAS 4 MATERIAS: " + VALIDACION.Opcion + " - " +
                                                    "\n MATERIA: " + VALIDACION.Materia + " - " + "CURSO: " + VALIDACION.Curso +
                                                    "\n \n >>ATENCION<< " +
                                                    "\n *Se validarán los datos ingresados. Recordá que un dato mal ingresado, dara de baja la inscripción." +
                                                    "\n *Recuerde que puede inscribirse en hasta 3 materias. Si aún le falta completar el proceso, ingrese nuevamente la opción '1'." +
                                                    "\n *Si ya completó el cupo de materias o no desea inscribirse en otra adicional, por favor finalice ingresando la opción '0'.\n");
                                                break;
                                            }
                                            else
                                            {
                                                Console.WriteLine("La inscripción no se ha confirmado. Vuelva a seleccionar una opción del menú principal para continuar.\n");
                                                break;
                                            }
                                        }
                                    } while (!esMateriaValida || !InscripcionMateriaDuplicada);
                                }
                                else
                                {
                                    break;
                                }
                            } while (!esRegistroValidoCantidad);
                        }
                    } while (!esCorrectoUltimas4);
                }
            } while (!esRegistroValido);
        }

        public static void Case2()
        {
            string registroIng = null;
            bool esRegistroValido = false;
            bool estaInscripto;
            do
            {
                Console.WriteLine("Ingrese un número de registro para obtener el estado actual de inscripción: ");
                registroIng = Console.ReadLine();
                esRegistroValido = VALIDACION.ValidarRegistro(registroIng);

                if (esRegistroValido)
                {
                    string materiasYcursos = "";
                    estaInscripto = INSCRIPCIONES.InscripcionesPorReg(registroIng, ref materiasYcursos);
                    if (estaInscripto)
                    {
                        Console.WriteLine($"El registro '{registroIng}' está inscripto en: \n{materiasYcursos}");
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"El registro '{registroIng}' no está inscripto en ninguna materia.");
                        break;
                    }
                }
            } while (!esRegistroValido);
        }

        public static void Case3()
        {
            string lista = "";

            INSCRIPCIONES.MateriasYCodigos(ref lista);
            Console.WriteLine("\nListado de materias disponibles: \n");
            Console.WriteLine(lista);
            Console.WriteLine("Para el plan de materias ingrese a 'www.economicas.uba.ar/carreras/sistemas/'.\n");
        }

        public static void Case4()
        {
            string lista = "";

            INSCRIPCIONES.ProfesoresPorCurso(ref lista);
            Console.WriteLine("\nListado de profesores por materia y curso: \n");
            Console.WriteLine(lista);
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
