using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_4;

namespace TP_4
{
    class VALIDACION
    {
        public static int Registro = 0;
        public static string Opcion = "";
        public static int Materia = 0;
        public static int Curso = 0;

        // Validaciones del menu principal:
        public static bool ValidarMenu(string opcionMenu)
        {
            bool estaBien = true;
            int opcionValidada;
            int k = 0;
            int m = 4;

            // Validación tipo de dato de opción
            if (!int.TryParse(opcionMenu, out opcionValidada))
            {
                Console.WriteLine("Opción inválida. No ha ingresado un número.\n");
                estaBien = false;
            }
            // Validación de rango de opción
            else if (opcionValidada < k || opcionValidada > m)
            {
                Console.WriteLine("Opción inválida. Debe ingresar una opción del menú principal.\n");
                estaBien = false;
            }
            return estaBien;

        }

        // Validaciones de las últimas 4 materias
        public static bool ValidarOpcion(string ultimas4Materias)
        {
            if(ultimas4Materias == "S" || ultimas4Materias == "N")
            {
                Opcion = ultimas4Materias;
                return true;
            }
            else
            {
                Console.WriteLine("No es un caracter válido.");
                return false;
            }
        }

        // Validaciones de número de Registro
        public static bool ValidarRegistro(string codigoRegistro)
        {
            // Validación de tipo de dato
            int codigo;
            bool IngresoCorrecto = Int32.TryParse(codigoRegistro, out codigo);

            if (!IngresoCorrecto)
            {
                Console.WriteLine($"El registro ingresado '{codigoRegistro}', es incorrecto. \n");
                return false;

            }

            // Validación de rango
            int i = 10000;
            int j = 10025;
            bool estaEnElRango = codigo >= i && codigo <= j;

            if (!estaEnElRango)
            {
                Console.WriteLine($"El número de registro ingresado '{codigo}', no está dentro del rango válido. \nRecuerde que su registro debe estar entre {i} y {j}. \n");
                return false;
            }

            Registro = codigo;
            return true;
        }
            
        // Validaciones de código Materia
        public static bool ValidarMateria(string codigoMateria)
        {
            // Validación de tipo de dato
            int codigo;
            bool IngresoCorrecto = Int32.TryParse(codigoMateria, out codigo);
            int p = 301;
            int r = 312;

            if (!IngresoCorrecto)
            {
                Console.WriteLine($"El código de materia ingresado '{codigoMateria}', es incorrecto. Debe ingresar un numero.\n");
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
        
        // Validaciones de código de Curso
        public static bool ValidarCurso(string codigoCurso)
        {
            // Validación de tipo de dato
            int codigo;
            bool IngresoCorrecto = Int32.TryParse(codigoCurso, out codigo);
            int x = 1;
            int y = 2;

            if (!IngresoCorrecto)
            {
                Console.WriteLine($"El código de curso ingresado '{codigoCurso}', es incorrecto. Debe ingresar un numero.\n");
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

