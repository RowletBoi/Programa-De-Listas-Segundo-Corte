using System;
using System.Collections.Generic;

namespace CatalogoSoftwareU
{
    //Clase "Software" representa un programa del catálogo
    //    Atributos pedidos: Id, Nombre y Version
    class Software
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = "";
        public string Version { get; set; } = "";
    }
    // Los atributos usan { get; set; } para permitir lectura y escritura.

    class Program
    {
        // Lista dinámica: aquí se guardan todos los programas
        static List<Software> catalogo = new List<Software>();

        // Contador simple para Ids autoincrementables (evita pedir Id manualmente)
        static int siguienteId = 1;

        static void Main()
        {
            // (Opcional) Semilla para tener datos de ejemplo al iniciar
            Semilla();

            int opcion;
            do
            {
                MostrarMenu();
                // Si falla ponemos -1 para que no se cierre el programa por un error de formato
                if (!int.TryParse(Console.ReadLine(), out opcion)) opcion = -1;

                switch (opcion)
                {
                    case 1: 
                        AgregarPrograma();
                        break;
                    case 2: 
                        EliminarPorId(); 
                        break;
                    case 3: 
                        BuscarPorNombre(); 
                        break;
                    case 4: 
                        ListarTodo();
                        break;
                    case 0:
                        Console.WriteLine("Saliendo..."); 
                        break;
                    default: 
                        Console.WriteLine("Opción inválida.");
                        break;
                }

                Console.WriteLine(); 
            } while (opcion != 0);
        }

        // Muestra el menú principal
        static void MostrarMenu()
        {
            Console.WriteLine("=== CATÁLOGO DE SOFTWARE UNIVERSITARIO ===");
            Console.WriteLine("1) Agregar programa");
            Console.WriteLine("2) Eliminar programa (por Id)");
            Console.WriteLine("3) Buscar programa (por nombre)");
            Console.WriteLine("4) Mostrar catálogo completo");
            Console.WriteLine("0) Salir");
            Console.Write("Elija una opción: ");
        }

        // Agregar un programa nuevo al catálogo
        static void AgregarPrograma()
        {
            Console.Write("Nombre del software: ");
            //'??' reemplaza null por ""(cadena vacía) para evitar errores y que el programa no se cierre.
            string nombre = (Console.ReadLine() ?? "").Trim();

            if (string.IsNullOrWhiteSpace(nombre))
            {
                Console.WriteLine("El nombre no puede estar vacío.");
                return;
            }

            Console.Write("Versión (ej: 2022, 17, v1.0): ");
            string version = (Console.ReadLine() ?? "").Trim();

            if (string.IsNullOrWhiteSpace(version))
            {
                Console.WriteLine("La versión no puede estar vacía.");
                return;
            }

            // Creamos el objeto y lo agregamos a la lista
            var nuevo = new Software
            {
                Id = siguienteId++,
                Nombre = nombre,
                Version = version
            };

            catalogo.Add(nuevo);
            Console.WriteLine($"Agregado: Id={nuevo.Id}, {nuevo.Nombre} {nuevo.Version}");
        }

        // Eliminar un programa por su Id (forma simple de "eliminar versiones obsoletas")
        // Aquí se asume que el usuario decide cuál entrada ya no debe estar.
        static void EliminarPorId()
        {
            Console.Write("Ingrese el Id a eliminar: ");
            //Se valida que el Id sea un número entero
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Id inválido.");
                return;
            }

            // Buscamos el objeto con ese Id
            Software? encontrado = null;
            foreach (var s in catalogo)
            {
                if (s.Id == id)
                {
                    encontrado = s;
                    break;
                }
            }

            if (encontrado == null)
            {
                Console.WriteLine("No se encontró un programa con ese Id.");
                return;
            }
            //Si se encontro, se elimina de la lista
            catalogo.Remove(encontrado);
            Console.WriteLine($"Eliminado: Id={encontrado.Id}, {encontrado.Nombre} {encontrado.Version}");
        }

        // Buscar por nombre (coincidencia contiene, sin mayúsculas/minúsculas)
        static void BuscarPorNombre()
        {
            Console.Write("Texto a buscar en el nombre: ");
            string buscado = (Console.ReadLine() ?? "").Trim().ToLower();

            if (string.IsNullOrWhiteSpace(buscado))
            {
                Console.WriteLine("Debe ingresar algún texto.");
                return;
            }

            // Recorremos y mostramos coincidencias
            bool hallado = false;
            foreach (var s in catalogo)
            {
                if (s.Nombre.ToLower().Contains(buscado))
                {
                    Console.WriteLine($"Id={s.Id} | {s.Nombre} | Versión {s.Version}");
                    hallado = true;
                }
            }

            if (!hallado) Console.WriteLine("No hay coincidencias.");
        }

        // Mostrar toda la lista
        static void ListarTodo()
        {
            if (catalogo.Count == 0)
            {
                Console.WriteLine("El catálogo está vacío.");
                return;
            }

            Console.WriteLine("=== LISTA COMPLETA ===");
            foreach (var s in catalogo)
            {
                Console.WriteLine($"Id={s.Id} | {s.Nombre} | Versión {s.Version}");
            }
        }

        //Esta funcion carga datos iniciales en la lista
        static void Semilla()
        {
            catalogo.Add(new Software { Id = siguienteId++, Nombre = "Visual Studio", Version = "2022" });
            catalogo.Add(new Software { Id = siguienteId++, Nombre = "SQL Server", Version = "2019" });
            catalogo.Add(new Software { Id = siguienteId++, Nombre = "AutoCAD", Version = "2023" });
        }
    }
}