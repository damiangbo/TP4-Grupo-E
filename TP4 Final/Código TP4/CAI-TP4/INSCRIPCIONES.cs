using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_4;

namespace CAI___TP4
{
    class INSCRIPCIONES
    {
        // Copiar ruta donde se ubique el archivo "INSCRIPCIONES" - Verificar tener los permisos de lectura y edición
        public static string rutaInscripcion = @"C:\Users\marin\Documents\INSCRIPCIONES.csv";
        public static string rutaMaterias = @"C:\Users\marin\Documents\MATERIAS.csv";
        public static string rutaCursos = @"C:\Users\marin\Documents\CURSOS.csv";
        public static string rutaAlumnos = @"C:\Users\marin\Documents\ALUMNOS.csv";       

        // Guardar inscripción
        public static bool GuardarInscripcion(int Registro, string Opcion, int Materia, int Curso)
        {
            List<string> filas = System.IO.File.ReadAllLines(rutaInscripcion).ToList<string>();
            filas.Add($"{Registro};{Opcion};{Materia};{Curso}");

            System.IO.File.WriteAllLines(rutaInscripcion, filas);
            return true;
        }

        // Ingreso de materia en la que el alumno ya se encuentra inscripto
        public static bool InscripcionMateriaDuplicada(int registro, int materia)
        {
            string[] filas = System.IO.File.ReadAllLines(rutaInscripcion);
            if (filas[0] == "")
            {
                return true;
            }

            foreach (string fila in filas)
            {
                string[] columna = fila.Split(';');

                int RegistroArchivo;
                int RegistroMateria;

                Int32.TryParse(columna[0], out RegistroArchivo);
                Int32.TryParse(columna[2], out RegistroMateria);
               
                if ((registro == RegistroArchivo) && (materia == RegistroMateria) )
                {
                    Console.WriteLine($"El registro ingresado ya se encuentra inscripto en esta materia.\n");
                    return false;
                }
            }

            return true;
        }

        // Cantidad de inscripciones por alumno: posibilidad de inscribirse en hasta 3 materias
        public static bool CantInscripPorReg(string Registro, int cant)
        {
            int codigo;
            bool IngresoCorrecto = Int32.TryParse(Registro, out codigo);                                       
            string[] filas = System.IO.File.ReadAllLines(rutaInscripcion);
            int cantInscripciones = 0;

            foreach (string fila in filas)
            {
                string[] columna = fila.Split(';');
                int RegistroArchivo;

                Int32.TryParse(columna[0], out RegistroArchivo);

                if (codigo == RegistroArchivo)
                {
                    cantInscripciones = cantInscripciones + 1;
                }
            }
            if (cantInscripciones < cant)
            {
                return true;
            }
            else
            {               
                Console.WriteLine($"El registro ingresado ya se encuentra inscripto a 3 materias.\n");
                return false;
            }
        }

        //Resumen de inscripción según registro ingresado
        public static bool InscripcionesPorReg(string registro, ref string materiaYcurso)
        {
            int codigo;
            bool IngresoCorrecto = Int32.TryParse(registro, out codigo);
            string[] filas = System.IO.File.ReadAllLines(rutaInscripcion);
            string materiaCurso = "";

            foreach (string fila in filas)
            {
                string[] columna = fila.Split(';');
                int RegistroArchivo;

                Int32.TryParse(columna[0], out RegistroArchivo);

                if (codigo == RegistroArchivo)
                {
                    materiaCurso += $"Materia: {columna[2]} - Curso: {columna[3]}\n";
                }
            }
            if (materiaCurso != "")
            {
                materiaYcurso = materiaCurso;
                return true;
            }
            else
            {
                return false;
            }
        }

        // Mostrar las materias disponibles
        public static void MateriasYCodigos(ref string materiaYcodigo)
        {
            string[] filas = System.IO.File.ReadAllLines(rutaMaterias);
            string materiaCodigo = "";

            foreach (string fila in filas)
            {
                string[] columna = fila.Split(';');

                materiaCodigo += $"Codigo: {columna[0]} - Materia: {columna[1]}\n";
            }
            materiaYcodigo = materiaCodigo;
        }

        // Mostrar profesores por curso según la materia elegida
        public static void CursosPorMateriaElegida(string codigoDeMateria, ref string profesoresYcursos)
        {
            int codigo;
            bool IngresoCorrecto = Int32.TryParse(codigoDeMateria, out codigo);
            string[] filas = System.IO.File.ReadAllLines(rutaCursos);
            string cursoProfes = "";

            foreach (string fila in filas)
            {
                string[] columna = fila.Split(';');
                int RegistroArchivo;

                Int32.TryParse(columna[0], out RegistroArchivo);

                if (codigo == RegistroArchivo)
                {
                    cursoProfes += $"Curso: {columna[1]} - Profesor: {columna[2]}\n";
                }
            }
            profesoresYcursos = cursoProfes;
        }

        // Buscar el nombre del alumno según el número de registro
        public static void MostrarAlumno(string registro, ref string nombre)
        {
            int codigo;
            bool IngresoCorrecto = Int32.TryParse(registro, out codigo);
            string[] filasAlumno = System.IO.File.ReadAllLines(rutaAlumnos);
            string nombreDeAlumno = "";

            foreach (string fila in filasAlumno)
            {
                string[] columna = fila.Split(';');
                int RegistroArchivo;

                Int32.TryParse(columna[0], out RegistroArchivo);

                if (codigo == RegistroArchivo)
                {
                    nombreDeAlumno = $"{columna[1]}";
                }
            }
            nombre = nombreDeAlumno;
        }

        // Mostrar profesores por materia y curso
        public static void ProfesoresPorCurso(ref string profesYcursos)
        {
            string[] filas = System.IO.File.ReadAllLines(rutaCursos);
            string profeCurso = "";

            foreach (string fila in filas)
            {
                string[] columna = fila.Split(';');

                profeCurso += $"Materia: {columna[0]} - Curso: {columna[1]} - Profesor: {columna[2]}\n";
            }
            profesYcursos = profeCurso;
        }

    }
}

        


