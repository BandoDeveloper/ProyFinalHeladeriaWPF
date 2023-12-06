using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;

namespace ProyFinalHeladeriaWPF
{
    /// <summary>
    /// Interaction logic for Ventas.xaml
    /// </summary>
    public partial class Ventas : Window
    {
        List<Producto> productos = new List<Producto>();
        List<Producto> productosSelec = new List<Producto>();
        List<Cliente> clientes = new List<Cliente>();
        public Ventas()
        {
            InitializeComponent(); 
            string[] prodDoc = { "" };
            string[] clientDoc = { "" };
            prodDoc = File.ReadAllLines("C://TextosVisualStudio/productos.txt");
            clientDoc = File.ReadAllLines("C://TextosVisualStudio/clientes.txt");
            int i = 2;       
            while (i < prodDoc.Length)
            {
                string[] tmp = { prodDoc[i - 2], prodDoc[i - 1], prodDoc[i] };
                agregarProducto(tmp);
                i = i + 3;
            };
            i = 6;
            while (i < clientDoc.Length)
            {
                string[] tmp = { prodDoc[i - 6], prodDoc[i - 5], prodDoc[i - 4], prodDoc[i - 3], prodDoc[i - 2], prodDoc[i - 1], prodDoc[i] };
                agregarCliente(tmp);
                i = i + 7;
            };
            foreach (var item in productos)
            {
                ComboBoxItem nuevoItem = new ComboBoxItem();
                nuevoItem.Content = item.NombreProd;

                // Agrega el ComboBoxItem al ComboBox
                menuDesplegable.Items.Add(nuevoItem);
            }
        }
        //AGREGAR LOS PRODUCTOS DEL ARCHIVO DE TEXTO
        public void agregarProducto(string[] tmp)
        {
            Producto producto = new Producto
            {
                CodProducto = tmp[0],
                NombreProd = tmp[1],
                Precio = int.Parse(tmp[2])
            };
            productos.Add(producto);
        }
        //AGREGAR LOS CLIENTES DEL ARCHIVO DE TEXTO
        public void agregarCliente(string[] tmp)
        {
            Cliente cl = new Cliente
            (
                tmp[0],
                tmp[1],
                int.Parse(tmp[2]),
                tmp[3],
                tmp[4],
                int.Parse(tmp[5]),
                int.Parse(tmp[6])
            );
            DataContext = cl;
            clientes.Add(cl);
        }
        private void menuDesplegable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //DEFINIMOS LA VARIABLE PARA CALCULAR EL PRECIO TOTAL
            int precioTotal = 0;
            //ESTA VARIABLE NOS DARA COMO RESULTADO LA OPCION QUE HAYAMOS SELECCIONADO DEL COMBOBOX
            string opcionSeleccionada = "";
            opcionSeleccionada = ((ComboBoxItem)menuDesplegable.SelectedItem).Content.ToString();
            //RECORREMOS TODA LA LISTA DE PRODUCTOS
            foreach (Producto item in productos)
            {
                //VERIFICAMOS SI EL OBJETO DE LA LISTA ES IGUAL AL SELECCIONADO
                //Y LO AGREGAMOS A LA LISTA DE PRODUCTOS SELECCIONADOS
                if (opcionSeleccionada == item.NombreProd)
                {
                    productosSelec.Add(item);
                }
            }
            //CONTAMOS TODOS LOS ELEMENTOS EN LA LISTA PARA CALCULAR EL PRECIO TOTAL
            for (int i = 0; i < productosSelec.Count; i++)
            {
                //ELIMINAMOS EL CAMPO TOTAL ANTERIOR PARA NO TENER CAMPOS "TOTAL" REPETIDOS
                if (productosSelec[i].CodProducto == "Total")
                {
                    productosSelec.RemoveAt(i);
                }
                //SUMAMOS EL PRECIO AL TOTAL
                precioTotal += productosSelec[i].Precio;
            }
            //HACEMOS TRAMPA Y NOS APROVECHAMOS DE LOS CAMPOS DE PRODUCTO PARA CREAR EL PRECIO TOTAL :)
            Producto precTotal = new Producto("Total", "", precioTotal);
            //AGREGAMOS EL CAMPO TOTAL AL FINAL DE LA LISTA
            productosSelec.Add(precTotal);
            //LIMPIAMOS LOS ITEMS PARA ACTUALIZARLOS
            CompraHelados.ItemsSource = null;
            //LLENAMOS EL DATAGRID CON LA LISTA DE PRODUCTOS SELECCIONADOS
            CompraHelados.ItemsSource = productosSelec;
        }

        private void agregarCompra_Click(object sender, RoutedEventArgs e)
        {
            bool text = false;
            bool soloCarnet = false;
            bool valid = false;
            string nom = boxNombre.Text;
            string ape = boxApellido.Text;
            string cod = boxCodigo.Text;
            string dir = boxDireccion.Text;
            if (nom != "" && ape != "" && cod != "" && dir != ""&& boxTelefono.Text != "")
            {
                text = true;
            }
            else
            {
                if (boxCarnet.Text != "")
                {
                    soloCarnet = true;
                }
                MessageBox.Show("LLENE TODOS LOS CAMPOS PRIMERO");
            }
            int car;
            int telf;
            if (text)
            {
                try
                {
                    car = int.Parse(boxCarnet.Text);
                    if (car > 100000 && car < 99999999)
                    {
                        valid = true;
                    }
                    else
                    {
                        MessageBox.Show("INGRESE UN CARNET VALIDO");
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("INGRESE NUMEROS EN EL CAMPO CARNET NO TEXTO");
                }
                if (soloCarnet)
                {

                }
                else
                {
                    try
                    {
                        telf = int.Parse(boxTelefono.Text);
                        if (telf > 10000000 && telf < 99999999)
                        {
                            valid = true;
                        }
                        else
                        {
                            MessageBox.Show("INGRESE UN TELEFONO VALIDO");
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("INGRESE NUMEROS EN EL CAMPO TELEFONO NO TEXTO");
                    }
                }
            }
        }
    }
}
