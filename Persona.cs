using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyFinalHeladeriaWPF
{
    internal class Persona
    {

        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public int Telefono { get; set; }
        public int Carnet { get; set; }
        public Persona()
        {
            Nombre = "No definido";
            Apellidos = "No definido";
            Telefono = 0;
            Carnet = 0;
        }
        public Persona(string nom, string ape, int tel, int ci)
        {
            Nombre = nom;
            Apellidos = ape;
            Telefono = tel;
            Carnet = ci;
        }
        public virtual void verDatos()
        {
            Console.WriteLine("SU NOMBRE ES " + Nombre);
            Console.WriteLine("SUS APELLIDOS SON " + Apellidos);
            Console.WriteLine("SU TELEFONO ES " + Telefono);
            Console.WriteLine("SU CARNET ES " + Carnet);
        }
        public virtual void leerDatos()
        {
            Console.WriteLine("INGRESE EL NOMBRE");
            Nombre = Console.ReadLine();
            Console.WriteLine("INGRESE LOS APELLIDOS");
            Apellidos = Console.ReadLine();
            Console.WriteLine("INGRESE EL TELEFONO");
            Telefono = int.Parse(Console.ReadLine());
            Console.WriteLine("INGRESE EL CARNET");
            Carnet = int.Parse(Console.ReadLine());
        }
    }
}
