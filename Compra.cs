using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyFinalHeladeriaWPF
{
    internal class Compra
    {

        public string CodCompra { get; set; }
        public int PrecTotal { get; set; }
        public bool FormaPago { get; set; } //true Se usa para tarjetas y false para efectivo
        public int CantProductos { get; set; }

        //AGREGACION
        public List<Producto> productos = new List<Producto>();
        //COMPOSICION
        public Empleado EncVent { get; set; }
        //CONSTRUCTORES
        public Compra()
        {
            CodCompra = "N/A";
            PrecTotal = 0;
            FormaPago = false;
            CantProductos = 0;
        }
        public Compra(string cod, int prec, bool pago, int cant, List<Producto> productosComp, Empleado encAct)
        {
            CodCompra = cod;
            PrecTotal = prec;
            FormaPago = pago;
            CantProductos = cant;
            productos = productosComp;
            EncVent = encAct;
        }
        public void verDatos()
        {
            Console.WriteLine("EL CODIGOD DEL COMPRA ES: " + CodCompra);
            Console.WriteLine("EL PRECIO TOTAL ES: " + PrecTotal);
            Console.Write("LA FORMA DE PAGO ES: ");
            if (FormaPago)
            {
                Console.WriteLine("POR TARJETA");
            }
            Console.WriteLine("PRESENCIAL");
            EncVent.verDatos();
        }
        public void leerDatos()
        {
            int forma;
            Console.WriteLine("EL CODIGOD DEL COMPRA ES: ");
            CodCompra = Console.ReadLine();
            Console.WriteLine("EL PRECIO TOTAL ES: ");
            PrecTotal = int.Parse(Console.ReadLine());
            Console.WriteLine("INGRESE LA FORMA DE PAGO: ");
            Console.WriteLine("1.TARJETA ");
            Console.WriteLine("2.EFECTIVO ");
            forma = int.Parse(Console.ReadLine());
            switch (forma)
            {
                case 1:
                    FormaPago = true;
                    break;
                case 2:
                    FormaPago = false;
                    break;
            }
            Console.WriteLine("LA CANTIDAD DE PRODUCTOS ES: ");
            CantProductos = int.Parse(Console.ReadLine());
            for (int i = 0; i < CantProductos; i++)
            {
                Producto prodAux = new Producto();
                prodAux.leerDatos();
                productos.Add(prodAux);
            }
            EncVent.leerDatos();
        }
    }
}
