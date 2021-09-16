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
        private readonly BindingList<FacturaDetalle> listaFacturaDetalle;
        private readonly FacturaService facturaService;
        private readonly TipoFacturaService tipoFacturaService;
        private readonly ClienteService clienteService;
        private readonly ProductoService productoService;

        public frmFactura()
        {
            InitializeComponent();
            dgvDetalle.AutoGenerateColumns = false;

            facturaService = new FacturaService();

            tipoFacturaService = new TipoFacturaService();
            clienteService = new ClienteService();
            productoService = new ProductoService();

            listaFacturaDetalle = new BindingList<FacturaDetalle>();

        }

        private void frmFactura_Load(object sender, EventArgs e)
        {
            InicializarFormulario();

            LlenarCombo(cboTipoFact, tipoFacturaService.ObtenerTodos(), "IdTipoFactura", "IdTipoFactura");
            LlenarCombo(cboCliente, clienteService.ObtenerTodos(), "NombreCliente", "IdCliente");
            LlenarCombo(_cboArticulo, productoService.ObtenerTodos(), "Nombre", "IdProducto");

            dgvDetalle.DataSource = listaFacturaDetalle;

            this.cboCliente.SelectedIndexChanged += new System.EventHandler(this.CboCliente_SelectedIndexChanged);
            this._cboArticulo.SelectedIndexChanged += new System.EventHandler(this._cboArticulo_SelectedIndexChanged);                        
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

        private void _btnAgregar_Click(object sender, EventArgs e)
        {

            int cantidad = 0;
            int.TryParse(_txtCantidad.Text, out cantidad);

            var producto = (Producto)_cboArticulo.SelectedItem;
            listaFacturaDetalle.Add(new FacturaDetalle()
            {
                NroItem = listaFacturaDetalle.Count + 1,
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
            txtSubtotal.Text = subtotal.ToString();

            double descuento = 0;
            double.TryParse(txtDescuento.Text, out descuento);

            var importeTotal = subtotal - subtotal * descuento / 100;
            txtImporteTotal.Text = importeTotal.ToString("C");
        }

        private void BtnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                var factura = new Factura
                {
                    Fecha = dtpFecha.Value,
                    Cliente = (Cliente)cboCliente.SelectedItem,
                    TipoFactura = (TipoFactura)cboTipoFact.SelectedItem,
                    FacturaDetalle = listaFacturaDetalle,
                    SubTotal = double.Parse(txtSubtotal.Text),
                    Descuento = double.Parse(txtDescuento.Text)
                };

                if (facturaService.ValidarDatos(factura))
                {                   
                    facturaService.Crear(factura);

                    MessageBox.Show(string.Concat("La factura nro: ", factura.IdFactura ," se generó correctamente."), "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    InicializarFormulario();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar la factura! " + ex.Message + ex.StackTrace, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private bool ValidarDatos()
        {
            return true;
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            InicializarFormulario();
        }

        private void InicializarFormulario()
        {

            _btnAgregar.Enabled = false;
            txtDescuento.Text = (0).ToString("N2");
            txtNroFact.Text = "1";
            cboTipoFact.SelectedIndex = -1;
            txtNroFact.Text = "";

            cboCliente.SelectedIndex = -1;
            txtDireccion.Text = "";
            txtCUIT.Text = "";

            InicializarDetalle();

            dgvDetalle.DataSource = null;

        }

        private void InicializarDetalle()
        {
            _cboArticulo.SelectedIndex = -1;
            _txtCantidad.Text = "";
            _txtPrecio.Text = 0.ToString("N2");
            _txtImporte.Text = 0.ToString("N2");
        }

        private void _cboArticulo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_cboArticulo.SelectedItem != null)
            {
                var producto = (Producto)_cboArticulo.SelectedItem;
                _txtPrecio.Text = producto.Precio.ToString("C");
                _txtCantidad.Enabled = true;
                int cantidad = 0;
                int.TryParse(_txtCantidad.Text, out cantidad);
                _txtImporte.Text = (producto.Precio * cantidad).ToString("C");
                _btnAgregar.Enabled = true;
            }
            else
            {
                _btnAgregar.Enabled = false;
                _txtCantidad.Enabled = false;
                _txtCantidad.Text = "";
                _txtPrecio.Text = "";
                _txtImporte.Text = "";
            }
        }

        private void _txtCantidad_Leave(object sender, EventArgs e)
        {
            if (_cboArticulo.SelectedItem != null)
            {
                int cantidad = 0;
                int.TryParse(_txtCantidad.Text, out cantidad);
                var producto = (Producto)_cboArticulo.SelectedItem;
                _txtImporte.Text = (producto.Precio * cantidad).ToString("C");
            }
        }

        private void TxtDescuento_Leave(object sender, EventArgs e)
        {
            CalcularTotales();
            double descuento = 0;
            if (double.TryParse(txtDescuento.Text, out descuento))
            {
                txtDescuento.Text = descuento.ToString("N2");
            }
        }

        private void _btnQuitar_Click(object sender, EventArgs e)
        {
            if (dgvDetalle.CurrentRow != null)
            {
                var detalleSeleccionado = (FacturaDetalle)dgvDetalle.CurrentRow.DataBoundItem;
                listaFacturaDetalle.Remove(detalleSeleccionado);
            }
        }

        private void CboCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCliente.SelectedItem != null)
            {
                var cliente = (Cliente)cboCliente.SelectedItem;

                txtDireccion.Text = string.Concat(cliente.DomicilioCalle, cliente.DomicilioNumero);
                txtCUIT.Text = cliente.CUIT;
            }
        }

        private void _btnCancelar_Click(object sender, EventArgs e)
        {
            InicializarDetalle();
        }
    }
}
