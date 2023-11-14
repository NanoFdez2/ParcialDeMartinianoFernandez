using ArrayObjeto.Entidades;
using ArrayRadio.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Authentication.ExtendedProtection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SegundoParcial___Tema_Dos
{
    public partial class frmObjeto : Form
    {
        public frmObjeto()
        {
            InitializeComponent();
        }

        private Radio objeto;
        public Radio GetObjeto()
        {
            return objeto;
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (validarDatos())
            {
                if (objeto == null)
                {
                    objeto = new Radio();
                }

                objeto.SetRadio(int.Parse(txtCaractUno.Text)); ;
                objeto.ColorRelleno = (ColorRelleno)cboCaractCuatro.SelectedItem;
                objeto.TipoDeBorde = (TipoDeBorde)cboCaractCinco.SelectedItem;
                DialogResult = DialogResult.OK;
            }
        }
        private bool validarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (!int.TryParse(txtCaractUno.Text, out int lado))
            {
                valido = false;
                errorProvider1.SetError(txtCaractUno, "Nro. mal ingresado.");
            }
            else if (lado <= 0)
            {
                valido = false;
                errorProvider1.SetError(txtCaractUno, "Valor del lado menor a cero.");
            }
            return valido;
        }
        public void SetObjeto(Radio? objeto)
        {
            this.objeto = objeto;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            CargarDatosComboColorRelleno();
            CrearBotonesOpcionBordes();
            if (objeto != null)
            {
                txtCaractUno.Text = objeto.GetRadio().ToString();
            }
        }

        private void CrearBotonesOpcionBordes()
        {
            var listaBordes = Enum.GetValues(typeof(TipoDeBorde)).Cast<TipoDeBorde>().ToList();
            cboCaractCinco.DataSource = listaBordes;
            cboCaractCinco.SelectedIndex = 0;
        }

        private void CargarDatosComboColorRelleno()
        {
            var listaColores = Enum.GetValues(typeof(ColorRelleno)).Cast<ColorRelleno>().ToList();
            cboCaractCuatro.DataSource = listaColores;
            cboCaractCuatro.SelectedIndex = 0;
        }

        private void cboCaractCuatro_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
