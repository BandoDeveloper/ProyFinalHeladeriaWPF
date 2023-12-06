using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyFinalHeladeriaWPF
{
    internal class Empleado:Persona
    {
        //PROPIEDADES
        public int CodEmpleado { get; set; }
        public int Sueldo { get; set; }
        public bool Horario { get; set; }
        //CONSTRUCTORES
        public Empleado() : base()
        {
            CodEmpleado = 0;
            Sueldo = 0;
            Horario = true;
        }
        public Empleado(int cod, int sueldo, bool hor, string nom, string ape, int tel, int ci) : base(nom, ape, tel, ci)
        {
            CodEmpleado = cod;
            Sueldo = sueldo;
            Horario = hor;
        }
        //FUNCIONALIDAD
        public override void verDatos()
        {
            Console.WriteLine("EL CODIGO DEL EMPLEADO ES " + CodEmpleado);
            base.verDatos();
            Console.WriteLine("SU SUELDO ES DE " + Sueldo);
            if (Horario)
            {
                Console.WriteLine("SU HORARIO ES DIURNO");
            }
            else
            {
                Console.WriteLine("SU HORARIO ES TARDIO");
            }
        }
    }
}
