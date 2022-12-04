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
    public partial class frmDetalle : Form
    {
        Articulo aDetallar = null;
        public frmDetalle()
        {
            InitializeComponent();
        }
        public frmDetalle(Articulo aDetallar)
        {
            InitializeComponent();
            this.aDetallar = aDetallar;
            Text = aDetallar.Nombre;
        }

        private void frmDetalle_Load(object sender, EventArgs e)
        {
            try
            {
                lblMarcaPas.Text = aDetallar.Marca.Descripcion;
                lblCategoriaPas.Text = aDetallar.Categoria.Descripcion;
                lblDescripcionPas.Text = aDetallar.Descripcion;
                lblPrecioPas.Text = "$" + aDetallar.Precio.ToString("0,0");
                lblCodigoPas.Text = aDetallar.Codigo;
                cargarImagen(aDetallar.UrlImagen);
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
                pbxImg.Load(url);
            }
            catch
            {
                pbxImg.Load("https://img.freepik.com/vector-premium/icono-marco-fotos-foto-vacia-blanco-vector-sobre-fondo-transparente-aislado-eps-10_399089-1290.jpg");
            }
        }
    }
}
