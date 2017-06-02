using System.Text;
using System.IO;
using System.Diagnostics;

namespace StringToFile
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder constructor = new StringBuilder();
            constructor.AppendLine("Hola");
            constructor.AppendLine("Mundo!");

            string pathTxt = @".\miArchivo.txt";
            File.WriteAllText(pathTxt, constructor.ToString());

            //Lo muestro en el notepad
            Process.Start("notepad.exe", pathTxt);
        }
    }
}