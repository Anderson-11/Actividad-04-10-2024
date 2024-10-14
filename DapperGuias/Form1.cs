using AccesoDatos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DapperDemo
{
    public partial class Form1 : Form
    {
        //Instancia de la clase CustomerRepository
        ProductoRepository productoRep = new ProductoRepository();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnObtenerTodos_Click(object sender, EventArgs e)
        {
            LoadDataGridViewProductos();
        }

        private void LoadDataGridViewProductos()
        {
            var productos = productoRep.ObtenerTodo();
            dgvProductos.DataSource = productos;
        }

        private Productos CreateProducts()
        {
            var nuevo = new Productos
            {
                IdProducto = txtBuscarId.Text,
                Nombre = txtNombre.Text,
                Precio = decimal.Parse(txtPrecio.Text),
                Stock = int.Parse(txtStock.Text),
                Descripcion = txtDescripcion.Text,
                Marca   = txtMarca.Text,
                Proveedor = txtProveedor.Text
            };
            return nuevo;

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            var producto_id = txtBuscarId.Text;
            var product_for_id = productoRep.GetById(producto_id);


            dgvProductos.DataSource = new List<Productos> { product_for_id };

            if (product_for_id != null)
            {
                LoadFormProducto(product_for_id);
                
            }
        }

        private void LoadFormProducto(Productos product_for_id)
        {
            txtNombre.Text = product_for_id.Nombre;
            txtPrecio.Text = product_for_id.Precio.ToString();
            txtStock.Text = product_for_id.Stock.ToString();
            txtDescripcion.Text = product_for_id.Descripcion;
            txtMarca.Text = product_for_id.Marca;
            txtProveedor.Text = product_for_id.Proveedor;
        }

        private void btnActualizarProducto_Click(object sender, EventArgs e)
        {
            var productsUpdate = CreateProducts();
            var actualizados = productoRep.UpdateProducts(productsUpdate);
            var products = productoRep.GetById(productsUpdate.IdProducto);
            dgvProductos.DataSource = new List<Productos> { products };

            MessageBox.Show($"filas actualizadas {actualizados} , {productsUpdate.IdProducto}");
            Limpiar();
        }

        private void Limpiar() {
            txtBuscarId.Text = "";
            txtNombre.Text = "";
            txtPrecio.Text = "";
            txtStock.Text = "";
            txtDescripcion.Text = "";
            txtMarca.Text = "";
            txtProveedor.Text = "";
        }
    }
}
