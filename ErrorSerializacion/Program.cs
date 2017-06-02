using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ErrorSerializacion
{
    public class Program
    {
        private static string rutaArchivoXML = @".\Resumendecuenta.xml";

        static void Main(string[] args)
        {
            GenerarXML();

            ObtenerXML();
            Console.ReadKey();
        }

        public static void ObtenerXML()
        {
            try
            {
                Console.WriteLine("***** ObtenerXML:");

                Resumen resumen = new Resumen();

                XmlSerializer serializador = new XmlSerializer(typeof(Resumen));
                FileStream archivo = new FileStream(rutaArchivoXML, FileMode.Open, FileAccess.Read);

                resumen = (Resumen)serializador.Deserialize(archivo);

                archivo.Close();

                if (resumen != null && resumen.Listado != null && resumen.Listado.Count > 0)
                {
                    Console.WriteLine(resumen.Listado[0].Cadena + " - " + resumen.Listado[0].Flotante);
                }
                else
                {
                    Console.WriteLine("resumen vacio o nulo.");
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.ToString());
            }
        }

        public static void GenerarXML()
        {
            try
            {
                Console.WriteLine("***** GenerarXML:");
                Resumen resumen = new Resumen();
                Cuenta cuenta = new Cuenta("una cuenta", float.Parse("2")); //creo una cuenta con sus respectivos valores.
                resumen.Listado.Add(cuenta);

                FileStream archivo = new FileStream(rutaArchivoXML, FileMode.Create, FileAccess.Write); //creo un archivo xml.

                XmlSerializer serializable = new XmlSerializer(typeof(Resumen)); //creo el serializador.
                serializable.Serialize(archivo, resumen); //serializo

                archivo.Close(); //cierro el xml

                //Muestro mensaje de creacion exitosa y capturo la seleccion.
                Console.WriteLine("Cuenta guardada exitosamente!");
            }
            catch (Exception exc)
            {
                Console.WriteLine("Error: " + exc.ToString());
            }
        }
    }

    [Serializable]
    public class Resumen
    {
        private List<Cuenta> _listado;

        public List<Cuenta> Listado
        {
            get
            {
                return _listado;
            }
            set
            {
                _listado = value;
            }
        }

        public Resumen()
        {
            this._listado = new List<Cuenta>();
        }
    }

    [Serializable]
    public class Cuenta
    {

        public string Cadena { get; set; }
        public float Flotante { get; set; }

        public Cuenta()
        {
            this.Cadena = string.Empty;
            this.Flotante = 0f;
        }

        public Cuenta(string p1, float p2)
        {
            // TODO: Complete member initialization
            this.Cadena = p1;
            this.Flotante = p2;
        }
    }
}
