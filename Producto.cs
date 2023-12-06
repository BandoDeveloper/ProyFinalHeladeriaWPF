using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyFinalHeladeriaWPF
{
    internal class Producto
    {
        //PROPIEDADES
        public string CodProducto { get; set; }
        public string NombreProd { get; set; }
        public int Precio { get; set; }
        //CONSTRUCTORES
        public Producto()
        {
            CodProducto = "0";
            NombreProd = "No definido";
            Precio = 0;
        }
        public Producto(string codPro, string nom, int pre)
        {
            CodProducto = codPro;
            NombreProd = nom;
            Precio = pre;
        }
        //FUNCIONALIDAD
        public void verDatos()
        {
            Console.WriteLine("EL CODIGO DEL PRODUCTO ES: " + CodProducto);
            Console.WriteLine("EL NOMBRE DEL PRODUCTO ES: " + NombreProd);
            Console.WriteLine("EL PRECIO DEL PRODUCTO ES: " + Precio);
        }
        public void leerDatos()
        {
            Console.WriteLine("EL CODIGO DEL PRODUCTO ES:");
            CodProducto = Console.ReadLine();
            Console.WriteLine("EL NOMBRE DEL PRODUCTO ES:");
            NombreProd = Console.ReadLine();
            Console.WriteLine("EL PRECIO DEL PRODUCTO ES:");
            Precio = int.Parse(Console.ReadLine());
            Console.WriteLine("LA FECHA DE ELABORACION ES:");
        }
    }
}
