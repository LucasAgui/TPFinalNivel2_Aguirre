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
using System.IO;
using System.Configuration;
namespace pantallas
{
    public partial class frmAgregar : Form
    {
        Articulo articulo = null;
        public frmAgregar()
        {
            InitializeComponent();
        }
        public frmAgregar(Articulo aModificar)
        {
            InitializeComponent();
            this.articulo = aModificar;
            btnAgregar.Text = "Modificar";
            Text = "Modificar artículo";
        }
        OpenFileDialog archivo = null;
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void frmAgregar_Load(object sender, EventArgs e)
        {
            MarcaNegocio negocioM = new MarcaNegocio();
            CategoriaNegocio negocioC = new CategoriaNegocio();
            txtNombre.MaxLength = 49;
            txtCodigo.MaxLength = 49;
            txtDescripcion.MaxLength = 149;
            txtUrl.MaxLength = 999;
            txtPrecio.MaxLength = 14;
            try
            {
                cboMarca.DataSource = negocioM.listar();
                cboCategoria.DataSource = negocioC.listar();

                if (articulo != null)
                {
                    cboMarca.ValueMember = "Id";
                    cboMarca.DisplayMember = "Descripcion";
                    cboMarca.SelectedValue = articulo.Marca.Id;
                    cboCategoria.ValueMember = "Id";
                    cboCategoria.DisplayMember = "Descripcion";
                    cboCategoria.SelectedValue = articulo.Categoria.Id;
                    cargarImagen(articulo.UrlImagen);
                    txtNombre.Text = articulo.Nombre;
                    txtCodigo.Text = articulo.Codigo;
                    txtDescripcion.Text = articulo.Descripcion;
                    txtUrl.Text = articulo.UrlImagen;
                    txtPrecio.Text = articulo.Precio.ToString("16,2");
                }
                else
                {
                    cargarImagen("lalala");
                    cboMarca.SelectedIndex = -1;
                    cboCategoria.SelectedIndex = -1;
                    cargarImagen("https://w7.pngwing.com/pngs/733/160/png-transparent-computer-icons-upload-youtube-icon-upload-miscellaneous-photography-sign-thumbnail.png", true);
                }
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            try
            {
                if (validarAceptar())
                {
                    if (articulo == null)
                        articulo = new Articulo();
                    articulo.Codigo = txtCodigo.Text;
                    articulo.Nombre = txtNombre.Text;
                    articulo.Descripcion = txtDescripcion.Text;
                    articulo.UrlImagen = txtUrl.Text;
                    articulo.Precio = decimal.Parse(txtPrecio.Text);
                    articulo.Categoria = (Categoria)cboCategoria.SelectedItem;
                    articulo.Marca = (Marca)cboMarca.SelectedItem;
                    if(articulo.Id == 0)
                    {
                    DialogResult resultado = MessageBox.Show("¿Estas seguro de que quieres añadir este artículo?", "Agregar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (resultado == DialogResult.Yes)
                    {
                        negocio.altaArticulo(articulo);
                        MessageBox.Show("Añadido exitosamente");
                        Close();

                        }
                        if (archivo != null && !(txtUrl.Text.ToUpper().Contains("HTTP")) && archivo.FileName == txtUrl.Text)
                            if (!(Directory.Exists(ConfigurationManager.AppSettings["fotos-articulosaguirre"])))
                                Directory.CreateDirectory(ConfigurationManager.AppSettings["fotos-articulosaguirre"]);
                        if (!(File.Exists(ConfigurationManager.AppSettings["fotos-articulosaguirre"] + archivo.SafeFileName)))
                            File.Copy(archivo.FileName, ConfigurationManager.AppSettings["fotos-articulosaguirre"] + archivo.SafeFileName);
                    }
                    else
                    {
                        DialogResult resultado = MessageBox.Show("¿Estas seguro de que quieres modificar este artículo?", "Modificar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (resultado == DialogResult.Yes)
                        {
                            negocio.modificarArticulo(articulo);
                            MessageBox.Show("Modificado exitosamente");
                            Close();

                        }
                        if (archivo != null && !(txtUrl.Text.ToUpper().Contains("HTTP")) && archivo.FileName == txtUrl.Text)
                        {
                            if (!(Directory.Exists(ConfigurationManager.AppSettings["fotos-articulosaguirre"])))
                                Directory.CreateDirectory(ConfigurationManager.AppSettings["fotos-articulosaguirre"]);
                                if (!(File.Exists(ConfigurationManager.AppSettings["fotos-articulosaguirre"] + archivo.SafeFileName)))
                                    File.Copy(archivo.FileName, ConfigurationManager.AppSettings["fotos-articulosaguirre"] + archivo.SafeFileName);

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void txtUrl_Leave(object sender, EventArgs e)
        {
            try
            {
                cargarImagen(txtUrl.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void btnSubir_Click(object sender, EventArgs e)
        {
            archivo = new OpenFileDialog();
            try
            {
                if (!(File.Exists(ConfigurationManager.AppSettings["fotos-articulosaguirre"])))
                {
                    Directory.CreateDirectory(ConfigurationManager.AppSettings["fotos-articulosaguirre"]);
                }
                archivo.Filter = "jpg|*.jpg;|png|*.png;";
                if (archivo.ShowDialog() == DialogResult.OK)
                {
                    txtUrl.Text = archivo.FileName;
                    cargarImagen(archivo.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        //HELPER------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public bool validarAceptar()
        {
            bool mensajitoNum = false;
            bool mensajito = false;
            if(txtNombre.Text == "")
            {
                lblAsteriscoNom.Visible = true;
                mensajito = true;
            }
            else
                lblAsteriscoNom.Visible = false;
            if (cboMarca.SelectedIndex < 0)
            {
                lblAsteriscoMar.Visible = true;
                mensajito = true;
            }
            else
                lblAsteriscoMar.Visible = false;
            if (cboCategoria.SelectedIndex < 0)
            {
                lblAsteriscoCat.Visible = true;
                mensajito = true;
            }
            else
                lblAsteriscoCat.Visible = false;
            if (!(validadSoloNum(txtPrecio.Text)))
            {
                lblAsteriscoNum.Visible = true;
                mensajitoNum = true;
            }
            else
                lblAsteriscoNum.Visible = false;
            if (mensajitoNum)
            {
                MessageBox.Show("ingrese solo números sin comas ni puntos en campos numéricos por favor ", "Campo invalido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (mensajito)
            {
                MessageBox.Show("Rellené los campos obligatorios para continuar...", "Formulario incompleto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else
                return true;
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
        private void cargarImagen(string url, bool a = false)
        {

            try
            {
                if (!(a))
                {
                    pbxImagen.Load(url);
                }
                else
                    pbxSubir.Load(url);
            }
            catch
            {
                pbxImagen.Load("https://img.freepik.com/vector-premium/icono-marco-fotos-foto-vacia-blanco-vector-sobre-fondo-transparente-aislado-eps-10_399089-1290.jpg");
            }
        }

    }
}
