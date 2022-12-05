namespace pantallas
{
    partial class frmInicio
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvListaArticulos = new System.Windows.Forms.DataGridView();
            this.lblMarca = new System.Windows.Forms.Label();
            this.pbxArticulo = new System.Windows.Forms.PictureBox();
            this.cboMarca = new System.Windows.Forms.ComboBox();
            this.cboCategoria = new System.Windows.Forms.ComboBox();
            this.lblCategoría = new System.Windows.Forms.Label();
            this.btnFiltro = new System.Windows.Forms.Button();
            this.lblFiltro = new System.Windows.Forms.Label();
            this.lblCriterio = new System.Windows.Forms.Label();
            this.cboCampo = new System.Windows.Forms.ComboBox();
            this.cboCriterio = new System.Windows.Forms.ComboBox();
            this.txtFiltro = new System.Windows.Forms.TextBox();
            this.lblFiltroTexto = new System.Windows.Forms.Label();
            this.btnCambiarFiltro = new System.Windows.Forms.Button();
            this.btnDetalles = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.agregarUnArticuloToolStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarUnArticuloToolStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarArtículoToolStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.verDetallesDeEsteProductoToolStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.lblFiltroText = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaArticulos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxArticulo)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvListaArticulos
            // 
            this.dgvListaArticulos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvListaArticulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaArticulos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvListaArticulos.Location = new System.Drawing.Point(243, 87);
            this.dgvListaArticulos.MultiSelect = false;
            this.dgvListaArticulos.Name = "dgvListaArticulos";
            this.dgvListaArticulos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListaArticulos.Size = new System.Drawing.Size(169, 338);
            this.dgvListaArticulos.TabIndex = 0;
            this.dgvListaArticulos.SelectionChanged += new System.EventHandler(this.dgvListaArticulos_SelectionChanged);
            // 
            // lblMarca
            // 
            this.lblMarca.AutoSize = true;
            this.lblMarca.Location = new System.Drawing.Point(187, 30);
            this.lblMarca.Name = "lblMarca";
            this.lblMarca.Size = new System.Drawing.Size(40, 13);
            this.lblMarca.TabIndex = 1;
            this.lblMarca.Text = "Marca:";
            // 
            // pbxArticulo
            // 
            this.pbxArticulo.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.pbxArticulo.Location = new System.Drawing.Point(429, 27);
            this.pbxArticulo.Name = "pbxArticulo";
            this.pbxArticulo.Size = new System.Drawing.Size(200, 369);
            this.pbxArticulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxArticulo.TabIndex = 3;
            this.pbxArticulo.TabStop = false;
            // 
            // cboMarca
            // 
            this.cboMarca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMarca.FormattingEnabled = true;
            this.cboMarca.Location = new System.Drawing.Point(243, 27);
            this.cboMarca.Name = "cboMarca";
            this.cboMarca.Size = new System.Drawing.Size(117, 21);
            this.cboMarca.TabIndex = 2;
            this.cboMarca.SelectedIndexChanged += new System.EventHandler(this.cboMarca_SelectedIndexChanged);
            // 
            // cboCategoria
            // 
            this.cboCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCategoria.FormattingEnabled = true;
            this.cboCategoria.Location = new System.Drawing.Point(64, 27);
            this.cboCategoria.Name = "cboCategoria";
            this.cboCategoria.Size = new System.Drawing.Size(117, 21);
            this.cboCategoria.TabIndex = 1;
            this.cboCategoria.SelectedIndexChanged += new System.EventHandler(this.cboCategoria_SelectedIndexChanged);
            // 
            // lblCategoría
            // 
            this.lblCategoría.AutoSize = true;
            this.lblCategoría.Location = new System.Drawing.Point(9, 30);
            this.lblCategoría.Name = "lblCategoría";
            this.lblCategoría.Size = new System.Drawing.Size(54, 13);
            this.lblCategoría.TabIndex = 6;
            this.lblCategoría.Text = "Categoría";
            // 
            // btnFiltro
            // 
            this.btnFiltro.Location = new System.Drawing.Point(88, 207);
            this.btnFiltro.Name = "btnFiltro";
            this.btnFiltro.Size = new System.Drawing.Size(94, 21);
            this.btnFiltro.TabIndex = 6;
            this.btnFiltro.Text = "Filtrar";
            this.btnFiltro.UseVisualStyleBackColor = true;
            this.btnFiltro.Visible = false;
            this.btnFiltro.Click += new System.EventHandler(this.btnFiltro_Click_1);
            // 
            // lblFiltro
            // 
            this.lblFiltro.AutoSize = true;
            this.lblFiltro.Location = new System.Drawing.Point(9, 130);
            this.lblFiltro.Name = "lblFiltro";
            this.lblFiltro.Size = new System.Drawing.Size(53, 13);
            this.lblFiltro.TabIndex = 8;
            this.lblFiltro.Text = "Filtrar por:";
            // 
            // lblCriterio
            // 
            this.lblCriterio.AutoSize = true;
            this.lblCriterio.Location = new System.Drawing.Point(9, 154);
            this.lblCriterio.Name = "lblCriterio";
            this.lblCriterio.Size = new System.Drawing.Size(42, 13);
            this.lblCriterio.TabIndex = 9;
            this.lblCriterio.Text = "Criterio:";
            this.lblCriterio.Visible = false;
            // 
            // cboCampo
            // 
            this.cboCampo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCampo.FormattingEnabled = true;
            this.cboCampo.Location = new System.Drawing.Point(68, 127);
            this.cboCampo.Name = "cboCampo";
            this.cboCampo.Size = new System.Drawing.Size(131, 21);
            this.cboCampo.TabIndex = 4;
            this.cboCampo.SelectedIndexChanged += new System.EventHandler(this.cboCampo_SelectedIndexChanged);
            // 
            // cboCriterio
            // 
            this.cboCriterio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCriterio.FormattingEnabled = true;
            this.cboCriterio.Location = new System.Drawing.Point(68, 154);
            this.cboCriterio.Name = "cboCriterio";
            this.cboCriterio.Size = new System.Drawing.Size(131, 21);
            this.cboCriterio.TabIndex = 11;
            this.cboCriterio.Visible = false;
            // 
            // txtFiltro
            // 
            this.txtFiltro.Location = new System.Drawing.Point(68, 154);
            this.txtFiltro.Name = "txtFiltro";
            this.txtFiltro.Size = new System.Drawing.Size(131, 20);
            this.txtFiltro.TabIndex = 5;
            this.txtFiltro.TextChanged += new System.EventHandler(this.txtFiltro_TextChanged);
            // 
            // lblFiltroTexto
            // 
            this.lblFiltroTexto.AutoSize = true;
            this.lblFiltroTexto.Location = new System.Drawing.Point(353, 277);
            this.lblFiltroTexto.Name = "lblFiltroTexto";
            this.lblFiltroTexto.Size = new System.Drawing.Size(0, 13);
            this.lblFiltroTexto.TabIndex = 13;
            // 
            // btnCambiarFiltro
            // 
            this.btnCambiarFiltro.Location = new System.Drawing.Point(12, 87);
            this.btnCambiarFiltro.Name = "btnCambiarFiltro";
            this.btnCambiarFiltro.Size = new System.Drawing.Size(205, 23);
            this.btnCambiarFiltro.TabIndex = 3;
            this.btnCambiarFiltro.Text = "Filtro Avanzado";
            this.btnCambiarFiltro.UseVisualStyleBackColor = true;
            this.btnCambiarFiltro.Click += new System.EventHandler(this.btnCambiarFiltro_Click);
            // 
            // btnDetalles
            // 
            this.btnDetalles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDetalles.Location = new System.Drawing.Point(429, 402);
            this.btnDetalles.Name = "btnDetalles";
            this.btnDetalles.Size = new System.Drawing.Size(200, 23);
            this.btnDetalles.TabIndex = 7;
            this.btnDetalles.Text = "VER DETALLES";
            this.btnDetalles.UseVisualStyleBackColor = true;
            this.btnDetalles.Click += new System.EventHandler(this.btnDetalles_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agregarUnArticuloToolStripMenu,
            this.modificarUnArticuloToolStripMenu,
            this.eliminarArtículoToolStripMenu,
            this.verDetallesDeEsteProductoToolStripMenu});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(641, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // agregarUnArticuloToolStripMenu
            // 
            this.agregarUnArticuloToolStripMenu.Name = "agregarUnArticuloToolStripMenu";
            this.agregarUnArticuloToolStripMenu.Size = new System.Drawing.Size(121, 20);
            this.agregarUnArticuloToolStripMenu.Text = "&Agregar un artículo";
            this.agregarUnArticuloToolStripMenu.Click += new System.EventHandler(this.agregarUnArticuloToolStripMenu_Click);
            // 
            // modificarUnArticuloToolStripMenu
            // 
            this.modificarUnArticuloToolStripMenu.Name = "modificarUnArticuloToolStripMenu";
            this.modificarUnArticuloToolStripMenu.Size = new System.Drawing.Size(113, 20);
            this.modificarUnArticuloToolStripMenu.Text = "&Modificar artículo";
            this.modificarUnArticuloToolStripMenu.Click += new System.EventHandler(this.modificarUnArticuloToolStripMenu_Click);
            // 
            // eliminarArtículoToolStripMenu
            // 
            this.eliminarArtículoToolStripMenu.Name = "eliminarArtículoToolStripMenu";
            this.eliminarArtículoToolStripMenu.Size = new System.Drawing.Size(105, 20);
            this.eliminarArtículoToolStripMenu.Text = "&Eliminar artículo";
            this.eliminarArtículoToolStripMenu.Click += new System.EventHandler(this.eliminarArtículoToolStripMenu_Click);
            // 
            // verDetallesDeEsteProductoToolStripMenu
            // 
            this.verDetallesDeEsteProductoToolStripMenu.Name = "verDetallesDeEsteProductoToolStripMenu";
            this.verDetallesDeEsteProductoToolStripMenu.Size = new System.Drawing.Size(161, 20);
            this.verDetallesDeEsteProductoToolStripMenu.Text = "&Ver detalles de este artículo";
            this.verDetallesDeEsteProductoToolStripMenu.Click += new System.EventHandler(this.verDetallesDeEsteProductoToolStripMenuItem_Click);
            // 
            // lblFiltroText
            // 
            this.lblFiltroText.AutoSize = true;
            this.lblFiltroText.Location = new System.Drawing.Point(12, 157);
            this.lblFiltroText.Name = "lblFiltroText";
            this.lblFiltroText.Size = new System.Drawing.Size(32, 13);
            this.lblFiltroText.TabIndex = 19;
            this.lblFiltroText.Text = "Filtro:";
            // 
            // frmInicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 430);
            this.Controls.Add(this.lblFiltroText);
            this.Controls.Add(this.btnDetalles);
            this.Controls.Add(this.btnCambiarFiltro);
            this.Controls.Add(this.lblFiltroTexto);
            this.Controls.Add(this.txtFiltro);
            this.Controls.Add(this.cboCriterio);
            this.Controls.Add(this.cboCampo);
            this.Controls.Add(this.lblCriterio);
            this.Controls.Add(this.lblFiltro);
            this.Controls.Add(this.btnFiltro);
            this.Controls.Add(this.lblCategoría);
            this.Controls.Add(this.cboCategoria);
            this.Controls.Add(this.cboMarca);
            this.Controls.Add(this.pbxArticulo);
            this.Controls.Add(this.lblMarca);
            this.Controls.Add(this.dgvListaArticulos);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(657, 469);
            this.MinimumSize = new System.Drawing.Size(657, 469);
            this.Name = "frmInicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inicio";
            this.Load += new System.EventHandler(this.frmInicio_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaArticulos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxArticulo)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvListaArticulos;
        private System.Windows.Forms.Label lblMarca;
        private System.Windows.Forms.PictureBox pbxArticulo;
        private System.Windows.Forms.ComboBox cboMarca;
        private System.Windows.Forms.ComboBox cboCategoria;
        private System.Windows.Forms.Label lblCategoría;
        private System.Windows.Forms.Button btnFiltro;
        private System.Windows.Forms.Label lblFiltro;
        private System.Windows.Forms.Label lblCriterio;
        private System.Windows.Forms.ComboBox cboCampo;
        private System.Windows.Forms.ComboBox cboCriterio;
        private System.Windows.Forms.TextBox txtFiltro;
        private System.Windows.Forms.Label lblFiltroTexto;
        private System.Windows.Forms.Button btnCambiarFiltro;
        private System.Windows.Forms.Button btnDetalles;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem agregarUnArticuloToolStripMenu;
        private System.Windows.Forms.ToolStripMenuItem modificarUnArticuloToolStripMenu;
        private System.Windows.Forms.ToolStripMenuItem eliminarArtículoToolStripMenu;
        private System.Windows.Forms.Label lblFiltroText;
        private System.Windows.Forms.ToolStripMenuItem verDetallesDeEsteProductoToolStripMenu;
    }
}

