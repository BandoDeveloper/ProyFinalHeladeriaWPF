using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace ProyFinalHeladeriaWPF
{
    internal class Cliente
    {
        public string CodCliente { get; set; }
        public string Direccion { get; set; }
        public int CantComp { get; set; }
        private List<Compra> clienteCompras = new List<Compra>();
        //CONSTRUCTORES
        public Cliente()
        {
            CodCliente = "No definido";
            Direccion = "No definido";
            CantComp = 0;
        }
        public Cliente(string cod, string direc, int CantCompras, string nom, string ape, int tel, int ci) //: base(nom, ape, tel, ci)
        {
            CodCliente = cod;
            Direccion = direc;
            CantComp = CantCompras;
        }
        //FUNCIONALIDAD
        public void verDatos()
        {
            Console.WriteLine("* * * LOS DATOS DE ESTE CLIENTE SON * * *");
            Console.WriteLine("EL CODIGO DEL CLIENTE ES " + CodCliente);
            //base.verDatos();
            Console.WriteLine("SU DIRECCION ES " + Direccion);
            Console.WriteLine("REALIZO LAS SIGUIENTES COMPRAS");
            Console.WriteLine("LAS COMPRAS SON ");
            foreach (Compra item in clienteCompras)
            {
                item.verDatos();
            }
        }
        public void leerDatos()
        {
            Console.WriteLine("* * * INGRESE LOS SIGUIENTES DATOS DEL CLIENTE * * *");
            Console.WriteLine("CODIGO DE CLIENTE");
            CodCliente = Console.ReadLine();
            //base.leerDatos();
            Console.WriteLine("LA DIRECCION DEL CLIENTE ES");
            Direccion = Console.ReadLine();
            Console.WriteLine("LA CANTIDAD DE COMPRAS DEL CLIENTE");
            CantComp = int.Parse(Console.ReadLine());
            for (int i = 0; i < CantComp; i++)
            {
                Compra comp = new Compra();
                clienteCompras.Add(comp);
                clienteCompras[i].leerDatos();
            }
        }
        public void agregaCompra(Compra nuevCompra)
        {
            clienteCompras.Add(nuevCompra);
        }
    }
}
