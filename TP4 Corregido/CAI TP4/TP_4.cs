using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAI_TP4
{
    class TP_4
    {
        static void Main(string[] args)
        {
            string opcion;
            int numero1 = 0;
            int numero2 = 4;

            // MENU PRINCIPAL
            Console.WriteLine("\nINSCRIPCIÓN AL PRIMER LLAMADO PARA EL CICLO PROFESIONAL - FACULTAD DE CIENCIAS ECONÓMICAS - UNIVERSIDAD DE BUENOS AIRES\n\n- MENÚ PRINCIPAL -\n");
            Console.WriteLine("Opción '1': Comenzar la inscripción");
            Console.WriteLine("Opción '2': Consultar estado de inscripción");
            Console.WriteLine("Opción '3': Consultar materias disponibles por carrera");
            Console.WriteLine("Opción '4': Consultar profesor disponible por curso y carrera");
            Console.WriteLine("Opción '0': Finalizar\n");

            do
            {
                Console.Write("Por favor, ingrese una opción del menú principal: ");
                opcion = Console.ReadLine();
                bool esMenuValido = VALIDACION.ValidarMenu(opcion, numero1, numero2);
                if (esMenuValido == false)
                {
                    continue;
                }

                switch (opcion)
                {
                    case "1":
                        CASOS.Case1();
                        break;

                    case "2":
                        CASOS.Case2();
                        break;

                    case "3":
                        CASOS.Case3();
                        break;

                    case "4":
                        CASOS.Case4();
                        break;

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
