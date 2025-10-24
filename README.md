  Descripción general

El programa permite gestionar un catálogo de software mediante una lista dinámica.
El usuario puede agregar, eliminar, buscar y listar programas, cada uno con un Id, nombre y versión.

  Estructura del código

Clase Software
Define los atributos de cada programa:

Id: identificador numérico autoincremental.

Nombre: nombre del software.

Version: versión del programa.

Clase Program
Contiene la lógica principal del sistema:

List<Software> catalogo: almacena todos los programas.

siguienteId: genera Ids automáticos.

Main(): muestra el menú y gestiona las opciones del usuario.

  Funcionalidades

Agregar programa → solicita nombre y versión, y lo añade al catálogo.

Eliminar programa → elimina un software según su Id.

Buscar programa → muestra coincidencias por nombre (sin distinguir mayúsculas).

Mostrar catálogo completo → lista todos los programas registrados.

Semilla inicial → carga tres programas de ejemplo (Visual Studio, SQL Server, AutoCAD).

  Notas técnicas

Usa List<T> para gestionar los datos en memoria (sin base de datos).

Se valida la entrada del usuario con TryParse y string.IsNullOrWhiteSpace().

El menú se repite hasta que el usuario elige la opción 0 (Salir).
