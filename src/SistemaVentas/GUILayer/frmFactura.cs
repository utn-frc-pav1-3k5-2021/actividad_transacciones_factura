using SistemaVentas.BusinessLayer;
using SistemaVentas.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SistemaVentas.GUILayer
{
    public partial class frmFactura : Form
    {
        private readonly FacturaService facturaService;
        private readonly TipoFacturaService tipoFacturaService;
        private readonly ClienteService clienteService;
        private readonly ProductoService productoService;

        //BindinList es un tipo de lista vinculada, cuando se agrega o quita un detalle la grilla se actualiza 
        private readonly BindingList<FacturaDetalle> listaFacturaDetalle;

        public frmFactura()
        {
            InitializeComponent();

            facturaService = new FacturaService();

            tipoFacturaService = new TipoFacturaService();
            clienteService = new ClienteService();
            productoService = new ProductoService();
            listaFacturaDetalle = new BindingList<FacturaDetalle>();

            dgvDetalle.AutoGenerateColumns = false;

        }

        private void frmFactura_Load(object sender, EventArgs e)
        {
            LlenarCombo(cboCliente, clienteService.ObtenerTodos(), "NombreCliente", "IdCliente");
            LlenarCombo(cboTipoFact, tipoFacturaService.ObtenerTodos(), "IdTipoFactura", "IdTipoFactura");
            LlenarCombo(_cboArticulo, productoService.ObtenerTodos(), "Nombre", "IdProducto");

            dgvDetalle.DataSource = listaFacturaDetalle;
        }

        private void LlenarCombo(ComboBox cbo, Object source, string display, String value)
        {
            cbo.ValueMember = value;
            cbo.DisplayMember = display;
            cbo.DataSource = source;
            cbo.SelectedIndex = -1;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {

        }

        private void _btnAgregar_Click(object sender, EventArgs e)
        {
            int cantidad = 0;

            int.TryParse(_txtCantidad.Text, out cantidad);

            var producto = new Producto();

            listaFacturaDetalle.Add(new FacturaDetalle { 
                NroItem = producto.IdProducto,
                Producto = producto,
                Cantidad = cantidad,
                PrecioUnitario = producto.Precio 
            });

            CalcularTotales();

            InicializarDetalle();
        }

        private void CalcularTotales()
        {
            var subtotal = listaFacturaDetalle.Sum(p => p.Importe);
            txtImporteTotal.Text = subtotal.ToString();

            double descuento = 0;
            double.TryParse(txtDescuento.Text, out descuento);

            var importeTotal = subtotal - subtotal * descuento / 100;
            txtImporteTotal.Text = importeTotal.ToString();


        }

        private void _btnQuitar_Click(object sender, EventArgs e)
        {
            if(dgvDetalle.CurrentRow != null)
            {
                var detalleSelected = (FacturaDetalle)dgvDetalle.CurrentRow.DataBoundItem;

                listaFacturaDetalle.Remove(detalleSelected);
            }
        }

        private void _btnCancelar_Click(object sender, EventArgs e)
        {
            InicializarDetalle();
        }
    }
}
