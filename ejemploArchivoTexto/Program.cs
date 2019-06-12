using System;
using System.IO;

namespace ejemploArchivoTexto
{
    class Program
    {
        static void Main(string[] args)
        {
            // En el ejemplo C:\Users\Jonathan\Desktop\source\ es el directorio donde se crearan los archivos de texto
            // NOTA: La \ es un caracter especial, si no se coloca el @ antes de la comilla doble, se debe usar \\ barra doble para representar una sola barra \, por ejemplo:
            // string variable = @"algo\mas algo" -> CORRECTO
            // string variable = "algo\\mas algo" -> CORRECTO
            // string variable = "algo\mas algo"  -> INCORRECTO
            string directorio = @"C:\Users\Jonathan\Desktop\source\";

            
            // Ejemplo #1: Escribir un vector de strings al archivo
            
            // Creo un vector de strings que posee cuatro lineas
            string[] lines = { "linea 11", "linea 22", "linea 31", "linea 42"};
            
            // El método WriteAllLines crea un archivo y escribe la colección de strings en el archivo y lo cierra luego. 
            // No es necesario llamar a los métodos Flush() o Close()
            File.WriteAllLines(directorio + "archivoLineasDeTexto.txt", lines);
            

            // Ejemplo #2: Escribir una cadena de texto al archivo

            string text = "El espiritu más noble agrandece al hombre mas pequeño. ";

            // El método WriteAllText crea un archivo, escribe la cadena string especificada al archivo y lo cierra luego.
            // No es necesario llamar a los métodos Flush() o Close()
            File.WriteAllText(directorio + "archivoConString.txt", text);

            
            // Ejemplo #3: Escribir unicamente algunas lineas del vector de strings al archivo

            // La instrucción using automaticamente vacia el buffer, cierra el stream y llama al método IDisposable.Dispose sobre el objeto stream object
            using (StreamWriter file = new StreamWriter(directorio + "archivoLineasDeTexto2.txt"))
            {
                foreach (string line in lines)
                {
                    // Si no la linea NO contiente el caracter '2', escribe la linea en el archivo
                    if (!line.Contains("2"))
                    {
                        file.WriteLine(line);
                    }
                }
            }
            

            // Ejemplo #4: Anexar nuevo texto a un archivo de texto existente.

            // La instrucción using automaticamente vacia el buffer, cierra el stream y llama al método IDisposable.Dispose sobre el objeto stream object
            using (StreamWriter file = new StreamWriter(directorio + "archivoLineasDeTexto2.txt", true))
            {
                file.WriteLine("última linea");
            }
        }
    }
}
