namespace WinAppClient
{
    partial class frmPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnProcesar = new System.Windows.Forms.Button();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtConsola = new System.Windows.Forms.TextBox();
            this.btnCargarXml = new System.Windows.Forms.Button();
            this.lblXml = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRecepcionId = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtDatosRecepcion = new System.Windows.Forms.TextBox();
            this.btnConsultarPorEstado = new System.Windows.Forms.Button();
            this.txtEstado = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnProcesar
            // 
            this.btnProcesar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProcesar.Location = new System.Drawing.Point(223, 13);
            this.btnProcesar.Margin = new System.Windows.Forms.Padding(4);
            this.btnProcesar.Name = "btnProcesar";
            this.btnProcesar.Size = new System.Drawing.Size(161, 50);
            this.btnProcesar.TabIndex = 1;
            this.btnProcesar.Text = "Procesar";
            this.btnProcesar.UseVisualStyleBackColor = true;
            this.btnProcesar.Click += new System.EventHandler(this.btnProcesar_Click);
            // 
            // btnConsultar
            // 
            this.btnConsultar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConsultar.Location = new System.Drawing.Point(423, 13);
            this.btnConsultar.Margin = new System.Windows.Forms.Padding(4);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(161, 50);
            this.btnConsultar.TabIndex = 2;
            this.btnConsultar.Text = "Consultar Por Id";
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.txtConsola);
            this.groupBox1.Location = new System.Drawing.Point(13, 191);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(823, 168);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Consola";
            // 
            // txtConsola
            // 
            this.txtConsola.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtConsola.Location = new System.Drawing.Point(4, 19);
            this.txtConsola.Margin = new System.Windows.Forms.Padding(4);
            this.txtConsola.Multiline = true;
            this.txtConsola.Name = "txtConsola";
            this.txtConsola.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtConsola.Size = new System.Drawing.Size(815, 145);
            this.txtConsola.TabIndex = 3;
            // 
            // btnCargarXml
            // 
            this.btnCargarXml.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCargarXml.Location = new System.Drawing.Point(22, 13);
            this.btnCargarXml.Margin = new System.Windows.Forms.Padding(4);
            this.btnCargarXml.Name = "btnCargarXml";
            this.btnCargarXml.Size = new System.Drawing.Size(161, 50);
            this.btnCargarXml.TabIndex = 0;
            this.btnCargarXml.Text = "Cargar";
            this.btnCargarXml.UseVisualStyleBackColor = true;
            this.btnCargarXml.Click += new System.EventHandler(this.btnCargarXml_Click);
            // 
            // lblXml
            // 
            this.lblXml.AutoSize = true;
            this.lblXml.Location = new System.Drawing.Point(16, 84);
            this.lblXml.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblXml.Name = "lblXml";
            this.lblXml.Size = new System.Drawing.Size(45, 17);
            this.lblXml.TabIndex = 5;
            this.lblXml.Text = "lblXml";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 118);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "RecepcionId:";
            // 
            // txtRecepcionId
            // 
            this.txtRecepcionId.Location = new System.Drawing.Point(109, 115);
            this.txtRecepcionId.Name = "txtRecepcionId";
            this.txtRecepcionId.Size = new System.Drawing.Size(121, 22);
            this.txtRecepcionId.TabIndex = 3;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.txtDatosRecepcion);
            this.groupBox2.Location = new System.Drawing.Point(13, 381);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(823, 342);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos Recepción";
            // 
            // txtDatosRecepcion
            // 
            this.txtDatosRecepcion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDatosRecepcion.Location = new System.Drawing.Point(4, 19);
            this.txtDatosRecepcion.Margin = new System.Windows.Forms.Padding(4);
            this.txtDatosRecepcion.Multiline = true;
            this.txtDatosRecepcion.Name = "txtDatosRecepcion";
            this.txtDatosRecepcion.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtDatosRecepcion.Size = new System.Drawing.Size(815, 319);
            this.txtDatosRecepcion.TabIndex = 3;
            // 
            // btnConsultarPorEstado
            // 
            this.btnConsultarPorEstado.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConsultarPorEstado.Location = new System.Drawing.Point(618, 13);
            this.btnConsultarPorEstado.Margin = new System.Windows.Forms.Padding(4);
            this.btnConsultarPorEstado.Name = "btnConsultarPorEstado";
            this.btnConsultarPorEstado.Size = new System.Drawing.Size(161, 50);
            this.btnConsultarPorEstado.TabIndex = 7;
            this.btnConsultarPorEstado.Text = "Consultar Por Estado";
            this.btnConsultarPorEstado.UseVisualStyleBackColor = true;
            this.btnConsultarPorEstado.Click += new System.EventHandler(this.btnConsultarPorEstado_Click);
            // 
            // txtEstado
            // 
            this.txtEstado.Location = new System.Drawing.Point(109, 152);
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.Size = new System.Drawing.Size(121, 22);
            this.txtEstado.TabIndex = 8;
            this.txtEstado.Text = "N";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 155);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "Estado:";
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(855, 748);
            this.Controls.Add(this.txtEstado);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnConsultarPorEstado);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.txtRecepcionId);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblXml);
            this.Controls.Add(this.btnCargarXml);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnConsultar);
            this.Controls.Add(this.btnProcesar);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmPrincipal";
            this.Text = "App Client";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnProcesar;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtConsola;
        private System.Windows.Forms.Button btnCargarXml;
        private System.Windows.Forms.Label lblXml;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRecepcionId;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtDatosRecepcion;
        private System.Windows.Forms.Button btnConsultarPorEstado;
        private System.Windows.Forms.TextBox txtEstado;
        private System.Windows.Forms.Label label2;
    }
}

