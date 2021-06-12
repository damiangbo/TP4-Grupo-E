using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAI_TP4
{
    class INSCRIPCIONES
    {
        // Copiar ruta donde se ubique el archivo "INSCRIPCIONES" - Verificar tener los permisos de lectura y edición
        public static string rutaInscripcion = @"C:\Users\marin\Desktop\INSCRIPCIONES.csv";
        public static string rutaAlumnos = @"C:\Users\marin\Documents\ALUMNOS.csv";

        public static void MostrarAlumno(string registro, ref string nombre)
        {
            Int32.TryParse(registro, out int codigo);
            string[] filasAlumno = System.IO.File.ReadAllLines(rutaAlumnos);
            string nombreDeAlumno = "";

            foreach (string fila in filasAlumno)
            {
                string[] columna = fila.Split(';');

                Int32.TryParse(columna[0], out int registroArchivo);

                if (codigo == registroArchivo)
                {
                    nombreDeAlumno = $"{columna[1]}";
                }
            }
            nombre = nombreDeAlumno;
        }

        public static bool CarreraEnArchivoIgual(string registro, string opcionCarrera)
        {
            Int32.TryParse(registro, out int codigo);
            string[] filas = System.IO.File.ReadAllLines(rutaAlumnos);

            foreach (string fila in filas)
            {
                string[] columna = fila.Split(';');

                Int32.TryParse(columna[0], out int registroArchivo);
                string carreraEnArchivo = $"{columna[2]}";

                if ((codigo == registroArchivo) && (opcionCarrera != carreraEnArchivo))
                {
                    Console.WriteLine($"El registro {codigo} ya se encuentra inscripto en la Facultad para una carrera diferente a la seleccionada." +
                        $"\nPor favor ingrese la carrera en la que se inscribió en la Facultad. Recuerde que su carrera es la '{carreraEnArchivo}'." +
                        "\nDe querer cambiar de carrera, por favor contáctese con el Centro de Estudiantes de la Facultad.\n");
                    return false;
                }
            }
            return true;
        }

        public static void ParaTodasLasCarreras(string registroIng, string rutaMaterias, string rutaCursos)
        {
            bool esCorrectoUltimas4;
            string lista = "";
            string cursosYprofesores = "";

            do
            {
                Console.WriteLine("¿Está en las últimas 4 materias? S/N");
                string ultimas4 = Console.ReadLine().ToUpper();
                esCorrectoUltimas4 = VALIDACION.ValidarOpcion(ultimas4);
                if (!esCorrectoUltimas4)
                {
                    continue;
                }
                if (ultimas4 == "S")
                {
                    bool esRegistroValidoCantidad = CantInscripPorReg(registroIng, 4);
                    bool esOpcionValidaSegunArchivo = Ultimas4EnArchivoIgual(registroIng, ultimas4);
                    bool esMateriaValida;
                    bool esMateriaDuplicada;

                    if (!esOpcionValidaSegunArchivo)
                    {
                        esCorrectoUltimas4 = false;
                        continue;
                    }
                    if (!esRegistroValidoCantidad)
                    {
                        break;
                    }
                    do
                    {
                        Console.WriteLine("\n Seleccione una materia de la siguiente lista:");
                        ListaDeMateriasSegunCarrera(registroIng, VALIDACION.Carrera, ref lista);
                        Console.WriteLine(lista);
                        Console.Write("Ingrese Código de Materia: ");
                        string codigoMateria = Console.ReadLine();
                        esMateriaValida = VALIDACION.ValidarMateria(codigoMateria);
                        esMateriaDuplicada = InscripcionMateriaDuplicada(VALIDACION.Registro, VALIDACION.Carrera, VALIDACION.Materia);
                        if (!esMateriaValida)
                        {
                            continue;
                        }
                        if (!esMateriaDuplicada)
                        {
                            esMateriaValida = false;
                            continue;
                        }
                        Console.WriteLine("Código de materia válido.\n");
                        bool esCursoValido;
                        do
                        {
                            Console.WriteLine($"La materia '{codigoMateria}' tiene los cursos y profesores:");
                            CursosPorMateriaElegida(rutaCursos, codigoMateria, ref cursosYprofesores);
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
                            GuardarInscripcion(VALIDACION.Registro, VALIDACION.Carrera, VALIDACION.Opcion, VALIDACION.Materia, VALIDACION.Curso);
                            Console.WriteLine(" INSCRIPCIÓN REGISTRO: " + VALIDACION.Registro + "\n CARRERA: " + VALIDACION.Carrera + "\n EN LAS ÚLTIMAS 4 MATERIAS: " + VALIDACION.Opcion +
                                "\n MATERIA: " + VALIDACION.Materia + "\n CURSO: " + VALIDACION.Curso +
                                "\n \n >>ATENCION<< " +
                                "\n *Se validarán los datos ingresados. Recuerde que un dato mal ingresado, dara de baja la inscripción." +
                                "\n *Recuerde que puede inscribirse en hasta 4 materias. Si aún le falta completar el proceso, ingrese nuevamente la opción '1'." +
                                "\n *Si ya completó el cupo de materias o no desea inscribirse en otra adicional, por favor finalice ingresando la opción '0'.\n");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("La inscripción no se ha confirmado. Vuelva a seleccionar una opción del menú principal para continuar.\n");
                            break;
                        }

                    } while (!esMateriaValida);
                }
                if (ultimas4 == "N")
                {
                    bool esRegistroValidoCantidad = CantInscripPorReg(registroIng, 3);
                    bool esOpcionValidaSegunArchivo = Ultimas4EnArchivoIgual(registroIng, ultimas4);
                    bool esMateriaValida;
                    bool esMateriaDuplicada;

                    if (!esOpcionValidaSegunArchivo)
                    {
                        esCorrectoUltimas4 = false;
                        continue;
                    }
                    if (!esRegistroValidoCantidad)
                    {
                        break;
                    }
                    do
                    {
                        Console.WriteLine("\n Seleccione una materia de la siguiente lista:");
                        ListaDeMateriasSegunCarrera(registroIng, VALIDACION.Carrera, ref lista);
                        Console.WriteLine(lista);
                        Console.Write("Ingrese Código de Materia: ");
                        string codigoMateria = Console.ReadLine();
                        esMateriaValida = VALIDACION.ValidarMateria(codigoMateria);
                        esMateriaDuplicada = InscripcionMateriaDuplicada(VALIDACION.Registro, VALIDACION.Carrera, VALIDACION.Materia);
                        if (!esMateriaValida)
                        {
                            continue;
                        }
                        if (!esMateriaDuplicada)
                        {
                            esMateriaValida = false;
                            continue;
                        }
                        //CONTADOR
                        if ((VALIDACION.Carrera == 1) && (codigoMateria == "303") && (Correlativas(registroIng) == false))
                        {
                            Console.WriteLine("Código de materia inválido. No es posible solicitar esta inscripción." +
                                "\nAún no tiene la materia 302 aprobada. Y la materia '303' es correlativa a la mencionada.\n");
                            esMateriaValida = false;
                            continue;
                        }
                        //ADMIN
                        if ((VALIDACION.Carrera == 2) && (codigoMateria == "305") && (Correlativas(registroIng) == false))
                        {
                            Console.WriteLine("Código de materia inválido. No es posible solicitar esta inscripción." +
                                "\nAún no tiene alguna/s de las siguientes materias aprobadas: 301 y 304. Y la materia '305' es correlativa a las mencionadas.\n");
                            esMateriaValida = false;
                            continue;
                        }
                        //ECONOMIA
                        if ((VALIDACION.Carrera == 3) && (codigoMateria == "312") && (Correlativas(registroIng) == false))
                        {
                            Console.WriteLine("Código de materia inválido. No es posible solicitar esta inscripción." +
                                "\nAún no tiene alguna/s de las siguientes materias aprobadas: 301, 308 y 310. Y la materia '312' es correlativa a las mencionadas.\n");
                            esMateriaValida = false;
                            continue;
                        }
                        //SISTEMAS
                        if ((VALIDACION.Carrera == 4) && (codigoMateria == "310") && (Correlativas(registroIng) == false))
                        {
                            Console.WriteLine("Código de materia inválido. No es posible solicitar esta inscripción." +
                                "\nAún no tiene alguna/s las siguientes materias aprobadas: 308 y 309. Y la materia '310' es correlativa a las mencionadas.\n");
                            esMateriaValida = false;
                            continue;
                        }
                        //ACTUARIO
                        if ((VALIDACION.Carrera == 5) && (codigoMateria == "312") && (Correlativas(registroIng) == false))
                        {
                            Console.WriteLine("Código de materia inválido. No es posible solicitar esta inscripción." +
                                "\nAún no tiene la materia 308 aprobada. Y la materia '312' es correlativa a la mencionada.\n");
                            esMateriaValida = false;
                            continue;
                        }
                        Console.WriteLine("Código de materia válido.\n");
                        bool esCursoValido;
                        do
                        {
                            Console.WriteLine($"La materia '{codigoMateria}' tiene los cursos y profesores:");
                            CursosPorMateriaElegida(rutaCursos, codigoMateria, ref cursosYprofesores);
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
                            GuardarInscripcion(VALIDACION.Registro, VALIDACION.Carrera, VALIDACION.Opcion, VALIDACION.Materia, VALIDACION.Curso);
                            Console.WriteLine(" INSCRIPCIÓN REGISTRO: " + VALIDACION.Registro + "\n CARRERA: " + VALIDACION.Carrera + "\n EN LAS ÚLTIMAS 4 MATERIAS: " + VALIDACION.Opcion +
                                "\n MATERIA: " + VALIDACION.Materia + "\n CURSO: " + VALIDACION.Curso +
                                "\n \n >>ATENCION<< " +
                                "\n *Se validarán los datos ingresados. Recuerde que un dato mal ingresado, dara de baja la inscripción." +
                                "\n *Recuerde que puede inscribirse en hasta 3 materias. Si aún le falta completar el proceso, ingrese nuevamente la opción '1'." +
                                "\n *Si ya completó el cupo de materias o no desea inscribirse en otra adicional, por favor finalice ingresando la opción '0'.\n");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("La inscripción no se ha confirmado. Vuelva a seleccionar una opción del menú principal para continuar.\n");
                            break;
                        }

                    } while (!esMateriaValida);
                }

            } while (!esCorrectoUltimas4);
        }

        public static bool CantInscripPorReg(string registro, int cant)
        {
            Int32.TryParse(registro, out int codigo);
            string[] filas = System.IO.File.ReadAllLines(rutaInscripcion);
            int cantInscripciones = 0;

            foreach (string fila in filas)
            {
                string[] columna = fila.Split(';');

                Int32.TryParse(columna[0], out int registroArchivo);

                if (codigo == registroArchivo)
                {
                    cantInscripciones++;
                }
            }
            if (cantInscripciones < cant)
            {
                return true;
            }
            else
            {
                Console.WriteLine($"El registro ingresado {codigo}, ya solicitó la inscripción en {cant} materias. No puede solicitar nuevamente la inscripción.\n");
                return false;
            }
        }

        public static bool Ultimas4EnArchivoIgual(string registro, string opcion)
        {
            Int32.TryParse(registro, out int codigo);
            string[] filas = System.IO.File.ReadAllLines(rutaInscripcion);

            foreach (string fila in filas)
            {
                string[] columna = fila.Split(';');

                Int32.TryParse(columna[0], out int registroArchivo);
                string opcionEnArchivo = columna[2];

                if ((codigo == registroArchivo) && (opcion != opcionEnArchivo))
                {
                    Console.WriteLine($"El registro {codigo} ya solicitó previamente la inscripción estableciendo que se encontraba en una instancia opuesta." +
                        $"\nPor favor ingrese la misma opción que había elegido previamente (su selección fue '{opcionEnArchivo}').\n");
                    return false;
                }
            }
            return true;
        }

        public static void ListaDeMateriasSegunCarrera(string registro, int carrera, ref string lista)
        {
            if (carrera == 1)
            {
                ListaDeMateriasConNombre(registro, CASOS.rutaMateriasContador, ref lista);

            }
            if (carrera == 2)
            {
                ListaDeMateriasConNombre(registro, CASOS.rutaMateriasAdmin, ref lista);

            }
            if (carrera == 3)
            {
                ListaDeMateriasConNombre(registro, CASOS.rutaMateriasEconomia, ref lista);

            }
            if (carrera == 4)
            {
                ListaDeMateriasConNombre(registro, CASOS.rutaMateriasSistemas, ref lista);

            }
            if (carrera == 5)
            {
                ListaDeMateriasConNombre(registro, CASOS.rutaMateriasActuario, ref lista);

            }
        }

        public static void ListaDeMateriasConNombre(string registro, string rutaMateriasCarreraElegida, ref string lista)
        {            
            Int32.TryParse(registro, out int codigo);
            string[] filasAlumnos = System.IO.File.ReadAllLines(rutaAlumnos);
            List<int> materiasFaltantes = new List<int>();

            foreach (string fila in filasAlumnos)
            {
                string[] columna = fila.Split(';');
                Int32.TryParse(columna[0], out int registroArchivo);

                if (codigo == registroArchivo)
                {
                    if (!columna.Contains<string>("301"))
                    {
                        materiasFaltantes.Add(301);
                    }
                    if (!columna.Contains<string>("302"))
                    {
                        materiasFaltantes.Add(302);
                    }
                    if (!columna.Contains<string>("303"))
                    {
                        materiasFaltantes.Add(303);
                    }
                    if (!columna.Contains<string>("304"))
                    {
                        materiasFaltantes.Add(304);
                    }
                    if (!columna.Contains<string>("305"))
                    {
                        materiasFaltantes.Add(305);
                    }
                    if (!columna.Contains<string>("306"))
                    {
                        materiasFaltantes.Add(306);
                    }
                    if (!columna.Contains<string>("307"))
                    {
                        materiasFaltantes.Add(307);
                    }
                    if (!columna.Contains<string>("308"))
                    {
                        materiasFaltantes.Add(308);
                    }
                    if (!columna.Contains<string>("309"))
                    {
                        materiasFaltantes.Add(309);
                    }
                    if (!columna.Contains<string>("310"))
                    {
                        materiasFaltantes.Add(310);
                    }
                    if (!columna.Contains<string>("311"))
                    {
                        materiasFaltantes.Add(311);
                    }
                    if (!columna.Contains<string>("312"))
                    {
                        materiasFaltantes.Add(312);
                    }
                }
            }
            
            string[] filasCarrera = System.IO.File.ReadAllLines(rutaMateriasCarreraElegida);
            string mensaje = "";

            foreach (string fila in filasCarrera)
            {
                string[] columna = fila.Split(';');
                Int32.TryParse(columna[0], out int codigoMateriaArchivo);

                for (int indice = 0; indice < materiasFaltantes.Count; indice++)
                {
                    if (materiasFaltantes[indice] == codigoMateriaArchivo)
                    {
                        mensaje += $"Código: {columna[0]} - Materia: {columna[1]}\n";
                    }
                }
            }

            lista = mensaje;
        }

        public static bool InscripcionMateriaDuplicada(int registro, int carrera, int materia)
        {
            string[] filas = System.IO.File.ReadAllLines(rutaInscripcion);
            if (filas[0] == "")
            {
                return true;
            }

            foreach (string fila in filas)
            {
                string[] columna = fila.Split(';');

                Int32.TryParse(columna[0], out int registroArchivo);
                Int32.TryParse(columna[1], out int registroCarrera);
                Int32.TryParse(columna[3], out int registroMateria);

                if ((registro == registroArchivo) && (carrera == registroCarrera) && (materia == registroMateria))
                {
                    Console.WriteLine($"El registro ingresado {registro}, ya solicitó la inscripción en la materia {materia} para la carrera {carrera}.\n");
                    return false;
                }
            }
            return true;
        }

        public static bool Correlativas(string registro)
        {
            Int32.TryParse(registro, out int codigo);
            string[] filasAlumno = System.IO.File.ReadAllLines(rutaAlumnos);

            foreach (string fila in filasAlumno)
            {
                string[] columna = fila.Split(';');
                Int32.TryParse(columna[0], out int registroArchivo);
                Int32.TryParse(columna[2], out int carreraArchivo);

                //CONTADOR
                if ((codigo == registroArchivo) && (carreraArchivo == 1) && columna.Contains<string>("302"))
                {
                    return true;
                }
                //ADMIN
                if ((codigo == registroArchivo) && (carreraArchivo == 2) && columna.Contains<string>("301") && columna.Contains<string>("304"))
                {
                    return true;
                }
                //ECONOMIA
                if ((codigo == registroArchivo) && (carreraArchivo == 3) && columna.Contains<string>("301") && columna.Contains<string>("308") && columna.Contains<string>("310"))
                {
                    return true;
                }
                //SISTEMAS
                if ((codigo == registroArchivo) && (carreraArchivo == 4) && columna.Contains<string>("308") && columna.Contains<string>("309"))
                {
                    return true;
                }
                //ACTUARIO
                if ((codigo == registroArchivo) && (carreraArchivo == 5) && columna.Contains<string>("308"))
                {
                    return true;
                }
            }
            return false;
        }

        public static void CursosPorMateriaElegida(string ruta, string codigoDeMateria, ref string profesoresYcursos)
        {
            Int32.TryParse(codigoDeMateria, out int codigo);
            string[] filas = System.IO.File.ReadAllLines(ruta);
            string cursoProfes = "";

            foreach (string fila in filas)
            {
                string[] columna = fila.Split(';');
                Int32.TryParse(columna[0], out int registroArchivo);

                if (codigo == registroArchivo)
                {
                    cursoProfes += $"Curso: {columna[1]} - Profesor: {columna[2]}\n";
                }
            }
            profesoresYcursos = cursoProfes;
        }

        public static bool GuardarInscripcion(int Registro, int Carrera, string Opcion, int Materia, int Curso)
        {
            List<string> filas = System.IO.File.ReadAllLines(rutaInscripcion).ToList<string>();
            filas.Add($"{Registro};{Carrera};{Opcion};{Materia};{Curso}");

            System.IO.File.WriteAllLines(rutaInscripcion, filas);
            return true;
        }


        public static bool InscripcionesPorReg(string registro, ref string materiaYcurso)
        {
            Int32.TryParse(registro, out int codigo);
            string[] filas = System.IO.File.ReadAllLines(rutaInscripcion);
            string materiaCurso = "";

            foreach (string fila in filas)
            {
                string[] columna = fila.Split(';');
                Int32.TryParse(columna[0], out int registroArchivo);

                if (codigo == registroArchivo)
                {
                    materiaCurso += $"Carrera: {columna[1]} - Materia: {columna[3]} - Curso: {columna[4]}\n";
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

        public static void MateriasYCodigos(string ruta, ref string materiaYcodigo)
        {
            string[] filas = System.IO.File.ReadAllLines(ruta);
            string materiaCodigo = "";

            foreach (string fila in filas)
            {
                string[] columna = fila.Split(';');

                materiaCodigo += $"Código: {columna[0]} - Materia: {columna[1]}\n";
            }
            materiaYcodigo = materiaCodigo;
        }

        public static void ProfesoresPorCurso(string ruta, ref string profesYcursos)
        {
            string[] filas = System.IO.File.ReadAllLines(ruta);
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
