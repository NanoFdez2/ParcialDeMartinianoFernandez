using ArrayObjeto.Entidades;
using ArrayRadio.Datos;
using ArrayRadio.Entidades;

namespace SegundoParcial___Tema_Dos
{
    public partial class frmPrincipal : Form
    {
        private repositorioDeObjeto repo;
        private List<Radio> lista;
        int intValor;
        public frmPrincipal()
        {
            InitializeComponent();
            repo = new repositorioDeObjeto();
            ActualizarCantidadRegistros();
        }

        private void ActualizarCantidadRegistros()
        {
            if (intValor > 0)
            {
                txtCantidad.Text = repo.GetCantidad(intValor).ToString();
            }
            else
            {
                txtCantidad.Text = repo.GetCantidad().ToString();
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tsbActualizar_Click(object sender, EventArgs e)
        //Doble click en actualizar para actualizar la cantidad de registros en caso de haber filtrado.
        {
            lista = repo.GetLista();
            MostrarDatosEnGrilla();
            ActualizarCantidadRegistros();
            intValor = 0;
            tsbFiltrar.BackColor = SystemColors.Control;
        }

        private void MostrarDatosEnGrilla()
        {
            dgvDatos.Rows.Clear();
            foreach (var objeto in lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, objeto);
                AgregarFila(r);
            }
        }

        private void AgregarFila(DataGridViewRow r)
        {
            dgvDatos.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, Radio objeto)
        {
            r.Cells[colUno.Index].Value = objeto.GetRadio();
            r.Cells[colTres.Index].Value = objeto.TipoDeBorde;
            r.Cells[colDos.Index].Value = objeto.ColorRelleno;
            r.Cells[colCinco.Index].Value = objeto.GetVolumen();
            r.Cells[colCuatro.Index].Value = objeto.GetArea();

            r.Tag = objeto;
        }

        private DataGridViewRow ConstruirFila()
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(dgvDatos);
            return r;
        }

        private void tsbBorrar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }
            DialogResult dr = MessageBox.Show("¿Desea borrar el objeto?", "Confirmar baja", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.No)
            {
                return;
            }
            var filaSeleccionada = dgvDatos.SelectedRows[0];
            Radio objeto = filaSeleccionada.Tag as Radio;
            repo.Borrar(objeto);
            txtCantidad.Text = repo.GetCantidad().ToString();
            QuitarFila(filaSeleccionada);
        }

        private void QuitarFila(DataGridViewRow r)
        {
            dgvDatos.Rows.Remove(r);
            MessageBox.Show("Registro borrado.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }
            var filaSeleccionada = dgvDatos.SelectedRows[0];

            Radio objeto = (Radio)filaSeleccionada.Tag;
            int ladoAnterior = objeto.GetRadio();
            frmObjeto frm = new frmObjeto() { Text = "Editar objeto" };
            frm.SetObjeto(objeto);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }
            objeto = frm.GetObjeto();
            repo.Editar(ladoAnterior, objeto);
            SetearFila(filaSeleccionada, objeto);
            MessageBox.Show("Registro editado.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void tsbFiltrar_Click(object sender, EventArgs e)
        {
            var stringValor = Microsoft.VisualBasic.Interaction.InputBox("Ingrese el valor a filtrar",
     "Filtrar por mayor o igual",
     "0", 400, 400);
            if (!int.TryParse(stringValor, out intValor))
            {
                return;
            }
            if (intValor <= 0)
            {
                return;
            }
            lista = repo.Filtrar(intValor);
            tsbFiltrar.BackColor = Color.Violet;
            MostrarDatosEnGrilla();
            ActualizarCantidadRegistros();
            MessageBox.Show("¡Filtro aplicadísimo!");
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            if (repo.GetCantidad() > 0)
            {
                lista = repo.GetLista();
                MostrarDatosEnGrilla();
            }
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            frmObjeto frm = new frmObjeto() { Text = "Agregar objeto." };
            DialogResult dr = frm.ShowDialog();
            if (dr != DialogResult.OK)
            {
                return;
            }
            Radio objeto = frm.GetObjeto();
            repo.Agregar(objeto);
            txtCantidad.Text = repo.GetCantidad().ToString();
            DataGridViewRow r = ConstruirFila();
            SetearFila(r, objeto);
            AgregarFila(r);

            MessageBox.Show("Objeto agregado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void tsbSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tsbOrdenas_Click(object sender, EventArgs e)
        {

        }

        private void ascendenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lista = repo.OrdenarAsc();
            MostrarDatosEnGrilla();
            ActualizarCantidadRegistros();
        }

        private void descendenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lista = repo.OrdenarDesc();
            MostrarDatosEnGrilla();
            ActualizarCantidadRegistros();
        }
    }
}