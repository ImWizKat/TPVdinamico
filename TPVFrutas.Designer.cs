
namespace TPVdinámico
{
    partial class TPVFrutas
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
            this.panelBotones = new System.Windows.Forms.FlowLayoutPanel();
            this.tablaCarrito = new System.Windows.Forms.DataGridView();
            this.Producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioUnitario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Peso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValorParcial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Procedencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Stock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonNuevoCliente = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonEmail = new System.Windows.Forms.Button();
            this.buttonCargar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxContraseña = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBoxMail = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tablaCarrito)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelBotones
            // 
            this.panelBotones.Location = new System.Drawing.Point(12, 12);
            this.panelBotones.Name = "panelBotones";
            this.panelBotones.Size = new System.Drawing.Size(482, 362);
            this.panelBotones.TabIndex = 6;
            // 
            // tablaCarrito
            // 
            this.tablaCarrito.AllowUserToAddRows = false;
            this.tablaCarrito.AllowUserToOrderColumns = true;
            this.tablaCarrito.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaCarrito.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Producto,
            this.PrecioUnitario,
            this.Peso,
            this.ValorParcial,
            this.Procedencia,
            this.Stock});
            this.tablaCarrito.Location = new System.Drawing.Point(6, 0);
            this.tablaCarrito.Name = "tablaCarrito";
            this.tablaCarrito.ReadOnly = true;
            this.tablaCarrito.Size = new System.Drawing.Size(643, 277);
            this.tablaCarrito.TabIndex = 1;
            this.tablaCarrito.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.tablaCarrito_UserDeletedRow);
            // 
            // Producto
            // 
            this.Producto.HeaderText = "Producto";
            this.Producto.Name = "Producto";
            this.Producto.ReadOnly = true;
            // 
            // PrecioUnitario
            // 
            this.PrecioUnitario.HeaderText = "PrecioUnitario";
            this.PrecioUnitario.Name = "PrecioUnitario";
            this.PrecioUnitario.ReadOnly = true;
            // 
            // Peso
            // 
            this.Peso.HeaderText = "Peso";
            this.Peso.Name = "Peso";
            this.Peso.ReadOnly = true;
            // 
            // ValorParcial
            // 
            this.ValorParcial.HeaderText = "ValorParcial";
            this.ValorParcial.Name = "ValorParcial";
            this.ValorParcial.ReadOnly = true;
            // 
            // Procedencia
            // 
            this.Procedencia.HeaderText = "Procedencia";
            this.Procedencia.Name = "Procedencia";
            this.Procedencia.ReadOnly = true;
            // 
            // Stock
            // 
            this.Stock.HeaderText = "Stock";
            this.Stock.Name = "Stock";
            this.Stock.ReadOnly = true;
            // 
            // buttonNuevoCliente
            // 
            this.buttonNuevoCliente.Location = new System.Drawing.Point(187, 283);
            this.buttonNuevoCliente.Name = "buttonNuevoCliente";
            this.buttonNuevoCliente.Size = new System.Drawing.Size(83, 79);
            this.buttonNuevoCliente.TabIndex = 4;
            this.buttonNuevoCliente.Text = "Nuevo Cliente";
            this.buttonNuevoCliente.UseVisualStyleBackColor = true;
            this.buttonNuevoCliente.Click += new System.EventHandler(this.buttonNuevoCliente_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(511, 301);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 31);
            this.label1.TabIndex = 5;
            this.label1.Text = "0";
            // 
            // buttonEmail
            // 
            this.buttonEmail.Location = new System.Drawing.Point(359, 283);
            this.buttonEmail.Name = "buttonEmail";
            this.buttonEmail.Size = new System.Drawing.Size(83, 79);
            this.buttonEmail.TabIndex = 7;
            this.buttonEmail.Text = "COBRO Generar y enviar factura";
            this.buttonEmail.UseVisualStyleBackColor = true;
            this.buttonEmail.Click += new System.EventHandler(this.buttonEmail_Click);
            // 
            // buttonCargar
            // 
            this.buttonCargar.Location = new System.Drawing.Point(500, 295);
            this.buttonCargar.Name = "buttonCargar";
            this.buttonCargar.Size = new System.Drawing.Size(83, 79);
            this.buttonCargar.TabIndex = 8;
            this.buttonCargar.Text = "Cargar";
            this.buttonCargar.UseVisualStyleBackColor = true;
            this.buttonCargar.Click += new System.EventHandler(this.buttonCargar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tablaCarrito);
            this.groupBox1.Controls.Add(this.buttonEmail);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.buttonNuevoCliente);
            this.groupBox1.Location = new System.Drawing.Point(500, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(650, 362);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.textBoxContraseña);
            this.groupBox2.Location = new System.Drawing.Point(13, 381);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(469, 50);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(186, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Introduce contraseña y presiona enter";
            // 
            // textBoxContraseña
            // 
            this.textBoxContraseña.Location = new System.Drawing.Point(208, 19);
            this.textBoxContraseña.Name = "textBoxContraseña";
            this.textBoxContraseña.PasswordChar = '*';
            this.textBoxContraseña.Size = new System.Drawing.Size(252, 20);
            this.textBoxContraseña.TabIndex = 1;
            this.textBoxContraseña.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxContraseña_KeyUp);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBoxMail);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(488, 381);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(481, 50);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Visible = false;
            // 
            // textBoxMail
            // 
            this.textBoxMail.Location = new System.Drawing.Point(183, 19);
            this.textBoxMail.Name = "textBoxMail";
            this.textBoxMail.Size = new System.Drawing.Size(291, 20);
            this.textBoxMail.TabIndex = 6;
            this.textBoxMail.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxMail_KeyUp);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(171, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Introduce el mail del cliente + enter";
            // 
            // TPVFrutas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1156, 439);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.buttonCargar);
            this.Controls.Add(this.panelBotones);
            this.Controls.Add(this.groupBox1);
            this.Name = "TPVFrutas";
            this.Text = "TPVFrutas";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tablaCarrito)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel panelBotones;
        private System.Windows.Forms.DataGridView tablaCarrito;
        private System.Windows.Forms.Button buttonNuevoCliente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonEmail;
        private System.Windows.Forms.Button buttonCargar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBoxContraseña;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textBoxMail;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioUnitario;
        private System.Windows.Forms.DataGridViewTextBoxColumn Peso;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValorParcial;
        private System.Windows.Forms.DataGridViewTextBoxColumn Procedencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn Stock;
    }
}

