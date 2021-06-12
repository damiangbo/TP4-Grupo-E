using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAI_TP4
{
    class VALIDACION
    {
        public static int Registro = 0;
        public static int Carrera = 0;
        public static string Opcion = "";
        public static int Materia = 0;
        public static int Curso = 0;

        public static bool ValidarMenu(string opcionMenu, int numero1, int numero2)
        {
            // Validación tipo de dato de opción
            if (!int.TryParse(opcionMenu, out int opcionValidada))
            {
                Console.WriteLine($"La opción ingresada '{opcionMenu}', es inválida. No ha ingresado un número.\n");
                return false;
            }
            // Validación de rango de opción
            else if (opcionValidada < numero1 || opcionValidada > numero2)
            {
                Console.WriteLine($"El número de opción ingresado '{opcionValidada}', es inválido. Debe ingresar un número que se encuentre en el menú.\n");
                return false;
            }
            return true;
        }

        public static bool ValidarRegistro(string codigoRegistro)
        {
            // Validación de tipo de dato
            bool IngresoCorrecto = Int32.TryParse(codigoRegistro, out int codigo);

            if (!IngresoCorrecto)
            {
                Console.WriteLine($"El registro ingresado '{codigoRegistro}', es incorrecto. Debe ingresar un número.\n");
                return false;
            }
            // Validación de rango
            int i = 10000;
            int j = 10025;
            bool estaEnElRango = codigo >= i && codigo <= j;

            if (!estaEnElRango)
            {
                Console.WriteLine($"El número de registro ingresado '{codigo}', no está dentro del rango válido. \nRecuerde que su registro debe estar entre {i} y {j}.\n");
                return false;
            }
            Registro = codigo;
            return true;
        }

        public static bool ValidarOpcion(string ultimas4Materias)
        {
            if (ultimas4Materias == "S" || ultimas4Materias == "N")
            {
                Opcion = ultimas4Materias;
                return true;
            }
            else
            {
                Console.WriteLine($"La opción ingresada '{ultimas4Materias}', es inválida (no es un caracter válido). Debe ingresar 'S' o 'N'.\n");
                return false;
            }
        }

        public static bool ValidarMateria(string codigoMateria)
        {
            // Validación de tipo de dato
            bool IngresoCorrecto = Int32.TryParse(codigoMateria, out int codigo);
            int p = 301;
            int r = 312;

            if (!IngresoCorrecto)
            {
                Console.WriteLine($"El código de materia ingresado '{codigoMateria}', es incorrecto. Debe ingresar un número.\n");
                return false;

            }

            // Validación de rango
            bool estaEnElRango = codigo >= p && codigo <= r;

            if (!estaEnElRango)
            {
                Console.WriteLine($"El código de materia ingresado '{codigo}', no está en un rango válido. \nRecuerde que el código de materia debe estar entre {p} y {r}.\n");
                return false;
            }

            Materia = codigo;
            return true;
        }

        public static bool ValidarCurso(string codigoCurso)
        {
            // Validación de tipo de dato
            bool IngresoCorrecto = Int32.TryParse(codigoCurso, out int codigo);
            int x = 1;
            int y = 2;

            if (!IngresoCorrecto)
            {
                Console.WriteLine($"El código de curso ingresado '{codigoCurso}', es incorrecto. Debe ingresar un número.\n");
                return false;

            }

            // Validación de rango
            bool estaEnElRango = codigo >= x && codigo <= y;

            if (!estaEnElRango)
            {
                Console.WriteLine($"El código de curso ingresado '{codigo}', no está dentro del rango válido. Recuerde que el código de curso debe ser '{x}' o '{y}'.\n");
                return false;
            }

            Curso = codigo;
            return true;
        }
    }
}
