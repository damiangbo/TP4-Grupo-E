using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_4;

namespace CAI___TP4
{
    class Program
    {
        static void Main(string[] args)
        {
            string opcion;

            // MENU PRINCIPAL
            Console.WriteLine("\nINSCRIPCIÓN AL PRIMER LLAMADO PARA EL CICLO PROFESIONAL - FACULTAD DE CIENCIAS ECONÓMICAS - UNIVERSIDAD DE BUENOS AIRES\n\n- MENÚ PRINCIPAL -\n");
            Console.WriteLine("Opción '1': Comenzar la inscripción");
            Console.WriteLine("Opción '2': Consultar estado de inscripción");
            Console.WriteLine("Opción '3': Consultar materias disponibles");
            Console.WriteLine("Opción '4': Consultar los profesores por curso disponibles");
            Console.WriteLine("Opción '0': Finalizar\n");

            do
            {
                Console.Write("Por favor, ingrese una opción del menú principal: ");
                opcion = Console.ReadLine();
                bool esMenuValido = VALIDACION.ValidarMenu(opcion);
                if (esMenuValido == false)
                {
                    continue;
                }

                switch (opcion)
                {
                    // Solicitud de ingreso de número de Registro
                    case "1":
                        CASOS.Case1();
                        break;

                    // Solicitud de Resumen de Inscripción
                    case "2":
                        CASOS.Case2();
                        break;

                    // Solicitud de lista de materias con sus códigos
                    case "3":
                        CASOS.Case3();
                        break;

                    // Solicitud de lista de profesores por curso
                    case "4":
                        CASOS.Case4();
                        break;

                    // Finalizar
                    case "0":
                        CASOS.Case0();
                        break;

                    default:
                        Console.WriteLine("Opción inválida. Debe ingresar una opción del menú principal.\n");
                        break;
                }
            }
            while (opcion != "0");
        }

    }
}
