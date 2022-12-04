using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dominio;
using negocio;


namespace pantallas
{
    public partial class frmInicio : Form
    {
        private List<Articulo> listaArticulo;
        private List<Marca> listaMarca;
        private List<Categoria> listaCategoria;
        public frmInicio()
        {
            InitializeComponent();
        }
        private void frmInicio_Load(object sender, EventArgs e)
        {
            try
            {
                cargar();
                llenarCombos();
                txtFiltro.MaxLength = 100;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }
        private void dgvListaArticulos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvListaArticulos.CurrentRow != null)
            {

                try
                {
                    Articulo seleccionado = (Articulo)dgvListaArticulos.CurrentRow.DataBoundItem;
                    cargarImagen(seleccionado.UrlImagen);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                
            }
        }
        private void cboCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                marcaYcategoria();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void cboMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                marcaYcategoria();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void cboCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFiltro.Text = "";
            string campo = cboCampo.SelectedItem.ToString();
            switch (campo)
            {
                case "Nombre":
                    cboCriterio.Items.Clear();
                    cboCriterio.Items.Add("Contiene");
                    cboCriterio.Items.Add("Comienza con");
                    cboCriterio.Items.Add("Termina con");
                    break;
                case "Precio":
                    cboCriterio.Items.Clear();
                    cboCriterio.Items.Add("De menor a mayor");
                    cboCriterio.Items.Add("De mayor a menor");
                    cboCriterio.Items.Add("Por debajo de");
                    cboCriterio.Items.Add("Por encima de");
                    cboCriterio.Items.Add("Exactamente");
                    break;
                case "Código":
                    cboCriterio.Items.Clear();
                    cboCriterio.Items.Add("Código exacto");
                    cboCriterio.Items.Add("Contiene");
                    cboCriterio.Items.Add("Comienza con");
                    cboCriterio.Items.Add("Termina con");
                    break;
                default:
                    cboCriterio.Items.Clear();
                    cboCriterio.Items.Add("Contiene");
                    cboCriterio.Items.Add("Comienza con");
                    cboCriterio.Items.Add("Termina con");
                    break;
            }
        }
        private void btnFiltro_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (validadFiltro())
                    return;
                string campo = cboCampo.SelectedItem.ToString();
                string criterio = cboCriterio.SelectedItem.ToString();
                string filtro = txtFiltro.Text;
                string marca = cboMarca.SelectedItem.ToString();
                string categoria = cboCategoria.SelectedItem.ToString();
                ArticuloNegocio negocio = new ArticuloNegocio();
                dgvListaArticulos.DataSource = null;
                dgvListaArticulos.DataSource = negocio.filtrar(filtro, campo, criterio, marca, categoria);
                if (btnDetalles.Text == "VER DETALLES")
                    ocultarColumnas();
                else
                {
                    ocultarColumnas();
                    mostrarColumnas();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
        private void btnCambiarFiltro_Click(object sender, EventArgs e)
        {
            try
            {
                Point buscar = new Point(68, 154);
                if (btnCambiarFiltro.Text == "Volvér al filtro rápido")
                {
                    btnCambiarFiltro.Text = "Volvér al filtro avanzado";
                    txtFiltro.Location = buscar;
                    cboCriterio.Visible = false;
                    btnFiltro.Visible = false;
                    lblCriterio.Visible = false;
                    lblFiltroText.Location = new Point(12, 157);
                    cboCampo.Items.Add("Todos los campos");
                    cboCampo.SelectedItem = "Todos los campos";
                }
                else
                {
                    btnCambiarFiltro.Text = "Volvér al filtro rápido";
                    cboCriterio.Visible = true;
                    btnFiltro.Visible = true;
                    lblCriterio.Visible = true;
                    txtFiltro.Location = new Point(68, 181);
                    lblFiltroText.Location = new Point(9, 184);
                    cboCampo.Items.Remove("Todos los campos");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
            
        }
        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            if (btnCambiarFiltro.Text != "Volver al filtro rápido")
            {
                try
                {
                    if (validarFiltroRapido())
                        filtrarRapidoHelp();
                    else if (txtFiltro.Text == "")
                        marcaYcategoria();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
        private void agregarUnArticuloToolStripMenu_Click(object sender, EventArgs e)
        {
            frmAgregar agregar = new frmAgregar();
            try
            {
                agregar.ShowDialog();
                cargar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void btnDetalles_Click(object sender, EventArgs e)
        {
            if (btnDetalles.Text == "VER DETALLES")
            {
                mostrarColumnas();
                dgvListaArticulos.Size = new Size(617, 166);
                dgvListaArticulos.Location = new Point(12, 236);
                pbxArticulo.Size = new Size(200, 201);
                btnDetalles.Text = "OCULTAR DETALLES";

            }
            else
            {
                ocultarColumnas();
                pbxArticulo.Size = new Size(200, 369);
                pbxArticulo.Location = new Point(429, 27);
                dgvListaArticulos.Size = new Size(169, 338);
                dgvListaArticulos.Location = new Point(243, 87);
                btnDetalles.Text = "VER DETALLES";
            }
        }
        private void modificarUnArticuloToolStripMenu_Click(object sender, EventArgs e)
        {
            try
            {
                if (validarSeleccionado())
                {
                    MessageBox.Show("Debés seleccionar un artículo antes de poder modificarlo... Por favor, realiza la búsqueda indicada y selecciona uno.", "Sin selección para modificar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Articulo seleccionado = (Articulo)dgvListaArticulos.CurrentRow.DataBoundItem;
                frmAgregar modificar = new frmAgregar(seleccionado);
                modificar.ShowDialog();
                cargar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void eliminarArtículoToolStripMenu_Click(object sender, EventArgs e)
        {
            try
            {
                if (!(validarSeleccionado()))
                {
                    DialogResult resultado = MessageBox.Show("¿Estas seguro de que quieres eliminar el artículo seleccionado? No habrá vuelta atrás", "Eliminación permanente", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if(resultado == DialogResult.Yes)
                    {
                        ArticuloNegocio negocio = new ArticuloNegocio();
                        Articulo seleccionado = (Articulo)dgvListaArticulos.CurrentRow.DataBoundItem;
                        negocio.eliminarArticulo(seleccionado);
                        cargar();
                    }
                }
                else
                {
                    MessageBox.Show("Debés seleccionar un artículo antes de poder eliminar uno... Por favor, realiza la búsqueda indicada.", "Sin selección para eliminar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void verDetallesDeEsteProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!(validarSeleccionado()))
                {
                    Articulo seleccionado = (Articulo)dgvListaArticulos.CurrentRow.DataBoundItem;
                    frmDetalle frm = new frmDetalle(seleccionado);
                    frm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Debés seleccionar un artículo antes de poder ver sus detalles... Por favor, realiza la búsqueda indicada.", "Sin selección para detallar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        //HELPER-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------                                                                            
        private void cargarImagen(string url)
        {
            try
            {
                pbxArticulo.Load(url);
            }
            catch
            {
                pbxArticulo.Load("https://img.freepik.com/vector-premium/icono-marco-fotos-foto-vacia-blanco-vector-sobre-fondo-transparente-aislado-eps-10_399089-1290.jpg");
            }
        }
        private void ocultarColumnas()
        {
            dgvListaArticulos.Columns["UrlImagen"].Visible = false;
            dgvListaArticulos.Columns["Id"].Visible = false;
            dgvListaArticulos.Columns["Codigo"].Visible = false;
            dgvListaArticulos.Columns["Precio"].Visible = false;
            dgvListaArticulos.Columns["Descripcion"].Visible = false;
            dgvListaArticulos.Columns["Marca"].Visible = false;
            dgvListaArticulos.Columns["Categoria"].Visible = false;
        }
        private void llenarCombos()
        {
            MarcaNegocio negocio = new MarcaNegocio();
            CategoriaNegocio negocioCategoria = new CategoriaNegocio();
            try
            {
                listaMarca = negocio.listar();
                Marca todas = new Marca();
                todas.Id = 0;
                todas.Descripcion = "Todas las marcas";
                listaMarca.Add(todas);
                cboMarca.ValueMember = "Id";
                cboMarca.DisplayMember = "Descripcion";
                cboMarca.DataSource = listaMarca;
                cboMarca.SelectedValue = 0;

                listaCategoria = negocioCategoria.listar();
                Categoria todasC = new Categoria();
                todasC.Id = 0;
                todasC.Descripcion = "Todas las categorías";
                listaCategoria.Add(todasC);
                cboCategoria.ValueMember = "Id";
                cboCategoria.DisplayMember = "Descripcion";
                cboCategoria.DataSource = listaCategoria;
                cboCategoria.SelectedValue = 0;

                cboCampo.Items.Add("Nombre");
                cboCampo.Items.Add("Precio");
                cboCampo.Items.Add("Código");
                cboCampo.Items.Add("Descripción");
                cboCampo.Items.Add("Todos los campos");
                cboCampo.SelectedIndex = 4;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void cargar()
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            try
            {
                listaArticulo = negocio.listarArticulos();
                dgvListaArticulos.DataSource = null;
                dgvListaArticulos.DataSource = listaArticulo;
                Articulo primer = listaArticulo[0];
                cargarImagen(primer.UrlImagen);
                if (btnDetalles.Text == "VER DETALLES")
                    ocultarColumnas();
                else
                {
                    ocultarColumnas();
                    mostrarColumnas();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public bool validadFiltro()
        {
            if (cboCampo.SelectedIndex < 0)
            {
                MessageBox.Show("Debes elegir un campo para filtrar.");
                return true;
            }
            if (cboCriterio.SelectedIndex < 0)
            {
                MessageBox.Show("Debes elegir un criterio para filtrar.");
                return true;
            }
            if (cboCampo.SelectedItem.ToString() == "Precio")
            {

                if (!(validadSoloNum(txtFiltro.Text)))
                {
                    MessageBox.Show("Solo números, para filtrar por precio.");
                    return true;
                }
            }
            return false;
        }
        public bool validadSoloNum(string cadena)
        {
            foreach (char caracter in cadena)
            {
                if (!char.IsNumber(caracter))
                    return false;
            }
            return true;
        }
        public void filtrarRapidoHelp()
        {
            List<Articulo> listaFiltrada = null;
            try
            {
                string filtro = txtFiltro.Text;
                string campo = cboCampo.SelectedItem.ToString();
                string marca = cboMarca.SelectedItem.ToString();
                string categoria = cboCategoria.SelectedItem.ToString();
                switch (campo)
                {
                    case "Nombre":
                        if (marca == "Todas las marcas" && categoria == "Todas las categorías")
                            listaFiltrada = listaArticulo.FindAll(x => x.Nombre.ToUpper().Contains(filtro.ToUpper()));
                        else if (marca == "Todas las marcas" && categoria != "Todas las categorías")
                            listaFiltrada = listaArticulo.FindAll(x => x.Nombre.ToUpper().Contains(filtro.ToUpper()) && x.Categoria.Descripcion == categoria);
                        else if (marca != "Todas las marcas" && categoria != "Todas las categorías")
                            listaFiltrada = listaArticulo.FindAll(x => x.Nombre.ToUpper().Contains(filtro.ToUpper()) && x.Categoria.Descripcion == categoria && x.Marca.Descripcion == marca);
                        else if (marca != "Todas las marcas" && categoria == "Todas las categorías")
                            listaFiltrada = listaArticulo.FindAll(x => x.Nombre.ToUpper().Contains(filtro.ToUpper()) && x.Marca.Descripcion == marca);
                        else
                            listaFiltrada = listaArticulo.FindAll(x => x.Nombre.ToUpper().Contains(filtro.ToUpper()) && x.Marca.Descripcion == marca && x.Categoria.Descripcion == categoria);
                        break;
                    case "Código":
                        if (marca == "Todas las marcas" && categoria == "Todas las categorías")
                            listaFiltrada = listaArticulo.FindAll(x => x.Codigo.ToUpper().Contains(filtro.ToUpper()));
                        else if (marca == "Todas las marcas" && categoria != "Todas las categorías")
                            listaFiltrada = listaArticulo.FindAll(x => x.Codigo.ToUpper().Contains(filtro.ToUpper()) && x.Categoria.Descripcion == categoria);
                        else if (marca != "Todas las marcas" && categoria != "Todas las categorías")
                            listaFiltrada = listaArticulo.FindAll(x => x.Codigo.ToUpper().Contains(filtro.ToUpper()) && x.Categoria.Descripcion == categoria && x.Marca.Descripcion == marca);
                        else if (marca != "Todas las marcas" && categoria == "Todas las categorías")
                            listaFiltrada = listaArticulo.FindAll(x => x.Codigo.ToUpper().Contains(filtro.ToUpper()) && x.Marca.Descripcion == marca);
                        else
                            listaFiltrada = listaArticulo.FindAll(x => x.Codigo.ToUpper().Contains(filtro.ToUpper()) && x.Marca.Descripcion == marca && x.Categoria.Descripcion == categoria);

                        break;
                    case "Descripción":
                        if (cboMarca.SelectedItem.ToString() == "Todas las marcas" && categoria == "Todas las categorías")
                            listaFiltrada = listaArticulo.FindAll(x => x.Descripcion.ToUpper().Contains(filtro.ToUpper()));
                        else if (marca == "Todas las marcas" && categoria != "Todas las categorías")
                            listaFiltrada = listaArticulo.FindAll(x => x.Descripcion.ToUpper().Contains(filtro.ToUpper()) && x.Categoria.Descripcion == categoria);
                        else if (marca == "Todas las marcas" && categoria != "Todas las categorías")
                            listaFiltrada = listaArticulo.FindAll(x => x.Descripcion.ToUpper().Contains(filtro.ToUpper()) && x.Categoria.Descripcion == categoria && x.Marca.Descripcion == marca);
                        else
                            listaFiltrada = listaArticulo.FindAll(x => x.Descripcion.ToUpper().Contains(filtro.ToUpper()) && x.Marca.Descripcion == marca && x.Categoria.Descripcion == categoria);

                        break;
                    case "Precio":
                        if (marca == "Todas las marcas" && categoria == "Todas las categorías")
                            listaFiltrada = listaArticulo.FindAll(x => x.Precio.ToString().Contains(filtro));
                        else if (marca == "Todas las marcas" && categoria != "Todas las categorías")
                            listaFiltrada = listaArticulo.FindAll(x => x.Precio.ToString().Contains(filtro) && x.Categoria.Descripcion == categoria);
                        else if (marca == "Todas las marcas" && categoria != "Todas las categorías")
                            listaFiltrada = listaArticulo.FindAll(x => x.Precio.ToString().Contains(filtro) && x.Categoria.Descripcion == categoria && x.Marca.Descripcion == marca);
                        else
                            listaFiltrada = listaArticulo.FindAll(x => x.Precio.ToString().Contains(filtro) && x.Marca.Descripcion == marca && x.Categoria.Descripcion == categoria);
                        break;
                    default:
                        if (categoria == "Todas las categorías" && marca == "Todas las marcas")
                            listaFiltrada = listaArticulo.FindAll(x => x.Nombre.ToUpper().Contains(filtro.ToUpper()) || x.Descripcion.ToUpper().Contains(filtro.ToUpper()) || x.Codigo.ToUpper().Contains(filtro.ToUpper()) || x.Precio.ToString().Contains(filtro));
                        else if (categoria != "Todas las categorías" && marca == "Todas las marcas")
                            listaFiltrada = listaArticulo.FindAll(x => x.Categoria.Descripcion == categoria || x.Nombre.ToUpper().Contains(filtro.ToUpper()) || x.Descripcion.ToUpper().Contains(filtro.ToUpper()) || x.Codigo.ToUpper().Contains(filtro.ToUpper()) || x.Precio.ToString().Contains(filtro));
                        else if (categoria == "Todas las categorías" && marca != "Todas las marcas")
                            listaFiltrada = listaArticulo.FindAll(x => x.Marca.Descripcion == marca || x.Nombre.ToUpper().Contains(filtro.ToUpper()) || x.Descripcion.ToUpper().Contains(filtro.ToUpper()) || x.Codigo.ToUpper().Contains(filtro.ToUpper()) || x.Precio.ToString().Contains(filtro));
                        else
                            listaFiltrada = listaArticulo.FindAll(x => x.Marca.Descripcion == marca && x.Categoria.Descripcion == categoria || x.Nombre.ToUpper().Contains(filtro.ToUpper()) || x.Descripcion.ToUpper().Contains(filtro.ToUpper()) || x.Codigo.ToUpper().Contains(filtro.ToUpper()) || x.Precio.ToString().Contains(filtro));
                        break;
                }
                if (listaFiltrada != null)
                {
                    dgvListaArticulos.DataSource = null;
                    dgvListaArticulos.DataSource = listaFiltrada;
                    if (btnDetalles.Text == "VER DETALLES")
                        ocultarColumnas();
                    else
                    {
                        ocultarColumnas();
                        mostrarColumnas();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public bool validarFiltroRapido()
        {
            if (cboCampo.SelectedIndex > -1 && txtFiltro.Text.Length > 1)
                return true;
            else
                return false;
        }
        public void marcaYcategoria()
        {
            List<Articulo> listaFiltrada = null;
            try
            {
                if (cboCategoria.SelectedItem != null && cboMarca.SelectedItem != null)
                {
                    string categoria = cboCategoria.SelectedItem.ToString();
                    string marca = cboMarca.SelectedItem.ToString();
                        if (validarFiltroRapido())
                        {
                            cyMconFiltro(categoria, marca);
                        }
                        else
                        {
                            if(categoria == "Todas las categorías")
                            {
                                if (marca == "Todas las marcas")
                                    listaFiltrada = listaArticulo;
                                else
                                    listaFiltrada = listaArticulo.FindAll(x => x.Marca.Descripcion == marca);
                            }
                            else
                            {
                                if (marca == "Todas las marcas")
                                    listaFiltrada = listaArticulo.FindAll(x => x.Categoria.Descripcion == categoria);
                                else
                                    listaFiltrada = listaArticulo.FindAll(x => x.Categoria.Descripcion == categoria && x.Marca.Descripcion == marca);
                            }
                            if(listaFiltrada != null)
                            {
                                dgvListaArticulos.DataSource = null;
                                dgvListaArticulos.DataSource = listaFiltrada;
                            if (btnDetalles.Text == "VER DETALLES")
                                ocultarColumnas();
                            else
                            {
                                ocultarColumnas();
                                mostrarColumnas();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void cyMconFiltro(string categoria, string marca)
        {
            try
            {
                List<Articulo> listaFiltrada = null;
                string campo = cboCampo.SelectedItem.ToString();
                string filtro = txtFiltro.Text;
                switch (campo)
                {
                    case "Nombre":
                        if (categoria == "Todas las categorías" && marca == "Todas las marcas")
                            listaFiltrada = listaArticulo.FindAll(x => x.Nombre.ToUpper().Contains(filtro.ToUpper()));
                        else if (categoria != "Todas las categorías" && marca == "Todas las marcas")
                            listaFiltrada = listaArticulo.FindAll(x => x.Nombre.ToUpper().Contains(filtro.ToUpper()) && x.Categoria.Descripcion == categoria);
                        else if (categoria == "Todas las categorías" && marca != "Todas las marcas")
                            listaFiltrada = listaArticulo.FindAll(x => x.Nombre.ToUpper().Contains(filtro.ToUpper()) && x.Marca.Descripcion == marca);
                        else
                            listaFiltrada = listaArticulo.FindAll(x => x.Nombre.ToUpper().Contains(filtro.ToUpper()) && x.Marca.Descripcion == marca && x.Categoria.Descripcion == categoria);
                        break;
                    case "Código":
                        if (categoria == "Todas las categorías" && marca == "Todas las marcas")
                            listaFiltrada = listaArticulo.FindAll(x => x.Codigo.ToUpper().Contains(filtro.ToUpper()));
                        else if (categoria != "Todas las categorías" && marca == "Todas las marcas")
                            listaFiltrada = listaArticulo.FindAll(x => x.Codigo.ToUpper().Contains(filtro.ToUpper()) && x.Categoria.Descripcion == categoria);
                        else if (categoria == "Todas las categorías" && marca != "Todas las marcas")
                            listaFiltrada = listaArticulo.FindAll(x => x.Codigo.ToUpper().Contains(filtro.ToUpper()) && x.Marca.Descripcion == marca);
                        else
                            listaFiltrada = listaArticulo.FindAll(x => x.Codigo.ToUpper().Contains(filtro.ToUpper()) && x.Marca.Descripcion == marca && x.Categoria.Descripcion == categoria);
                        break;
                    case "Descripción":
                        if (categoria == "Todas las categorías" && marca == "Todas las marcas")
                            listaFiltrada = listaArticulo.FindAll(x => x.Descripcion.ToUpper().Contains(filtro.ToUpper()));
                        else if (categoria != "Todas las categorías" && marca == "Todas las marcas")
                            listaFiltrada = listaArticulo.FindAll(x => x.Descripcion.ToUpper().Contains(filtro.ToUpper()) && x.Categoria.Descripcion == categoria);
                        else if (categoria == "Todas las categorías" && marca != "Todas las marcas")
                            listaFiltrada = listaArticulo.FindAll(x => x.Descripcion.ToUpper().Contains(filtro.ToUpper()) && x.Marca.Descripcion == marca);
                        else
                            listaFiltrada = listaArticulo.FindAll(x => x.Descripcion.ToUpper().Contains(filtro.ToUpper()) && x.Marca.Descripcion == marca && x.Categoria.Descripcion == categoria);
                        break;
                    case "Precio":
                        if (validadSoloNum(filtro))
                        {
                            if (categoria == "Todas las categorías" && marca == "Todas las marcas")
                                listaFiltrada = listaArticulo.FindAll(x => x.Precio.ToString().Contains(filtro));
                            else if (categoria != "Todas las categorías" && marca == "Todas las marcas")
                                listaFiltrada = listaArticulo.FindAll(x => x.Precio.ToString().Contains(filtro) && x.Categoria.Descripcion == categoria);
                            else if (categoria == "Todas las categorías" && marca != "Todas las marcas")
                                listaFiltrada = listaArticulo.FindAll(x => x.Precio.ToString().Contains(filtro) && x.Marca.Descripcion == marca);
                            else
                                listaFiltrada = listaArticulo.FindAll(x => x.Precio.ToString().Contains(filtro) && x.Marca.Descripcion == marca && x.Categoria.Descripcion == categoria);
                        }
                        else
                        {
                            MessageBox.Show("Solo números, para filtrar por precio.");
                            return;
                        }
                        break;
                    default:
                        if (categoria == "Todas las categorías" && marca == "Todas las marcas")
                            listaFiltrada = listaArticulo.FindAll(x => x.Nombre.ToUpper().Contains(filtro.ToUpper()) && x.Descripcion.ToUpper().Contains(filtro.ToUpper()) && x.Codigo.ToUpper().Contains(filtro.ToUpper()) && x.Precio.ToString().Contains(filtro));
                        else if (categoria != "Todas las categorías" && marca == "Todas las marcas")
                            listaFiltrada = listaArticulo.FindAll(x => x.Categoria.Descripcion == categoria && x.Nombre.ToUpper().Contains(filtro.ToUpper()) && x.Descripcion.ToUpper().Contains(filtro.ToUpper()) && x.Codigo.ToUpper().Contains(filtro.ToUpper()) && x.Precio.ToString().Contains(filtro));
                        else if (categoria == "Todas las categorías" && marca != "Todas las marcas")
                            listaFiltrada = listaArticulo.FindAll(x => x.Marca.Descripcion == marca && x.Nombre.ToUpper().Contains(filtro.ToUpper()) && x.Descripcion.ToUpper().Contains(filtro.ToUpper()) && x.Codigo.ToUpper().Contains(filtro.ToUpper()) && x.Precio.ToString().Contains(filtro));
                        else
                            listaFiltrada = listaArticulo.FindAll(x => x.Marca.Descripcion == marca && x.Categoria.Descripcion == categoria && x.Nombre.ToUpper().Contains(filtro.ToUpper()) && x.Descripcion.ToUpper().Contains(filtro.ToUpper()) && x.Codigo.ToUpper().Contains(filtro.ToUpper()) && x.Precio.ToString().Contains(filtro));
                        break;
                }
                if (listaFiltrada != null)
                {
                    dgvListaArticulos.DataSource = null;
                    dgvListaArticulos.DataSource = listaFiltrada;
                    if (btnDetalles.Text == "VER DETALLES")
                        ocultarColumnas();
                    else
                    {
                        ocultarColumnas();
                        mostrarColumnas();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }
        public void mostrarColumnas()
        {
            dgvListaArticulos.Columns["Codigo"].Visible = true;
            dgvListaArticulos.Columns["Precio"].Visible = true;
            dgvListaArticulos.Columns["Descripcion"].Visible = true;
            dgvListaArticulos.Columns["Marca"].Visible = true;
            dgvListaArticulos.Columns["Categoria"].Visible = true;
        }
        public bool validarSeleccionado()
        {
            if (dgvListaArticulos.CurrentRow == null)
                return true;
            else
                return false;
        }

    }
}
