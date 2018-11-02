namespace StartupManager
{
    partial class frmMenu
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
            this.dgvDados = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.materialDivider1 = new MaterialSkin.Controls.MaterialDivider();
            this.txtConsulta = new System.Windows.Forms.TextBox();
            this.btnBuscar = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnLimpar = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnNovo = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnAlterar = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnExcluir = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnCanvas = new MaterialSkin.Controls.MaterialRaisedButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDados)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvDados
            // 
            this.dgvDados.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDados.Location = new System.Drawing.Point(13, 118);
            this.dgvDados.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvDados.Name = "dgvDados";
            this.dgvDados.Size = new System.Drawing.Size(867, 559);
            this.dgvDados.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnLimpar);
            this.groupBox1.Controls.Add(this.btnBuscar);
            this.groupBox1.Controls.Add(this.txtConsulta);
            this.groupBox1.Controls.Add(this.materialLabel2);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.groupBox1.Location = new System.Drawing.Point(13, 685);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(996, 71);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "PESQUISAR:";
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(6, 34);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(82, 24);
            this.materialLabel2.TabIndex = 1;
            this.materialLabel2.Text = "Campo:";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(94, 30);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(196, 33);
            this.comboBox1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 37);
            this.label1.TabIndex = 5;
            this.label1.Text = "Projetos";
            // 
            // materialDivider1
            // 
            this.materialDivider1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.materialDivider1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.materialDivider1.Depth = 0;
            this.materialDivider1.Location = new System.Drawing.Point(894, 61);
            this.materialDivider1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialDivider1.Name = "materialDivider1";
            this.materialDivider1.Size = new System.Drawing.Size(128, 616);
            this.materialDivider1.TabIndex = 6;
            this.materialDivider1.Text = "materialDivider1";
            // 
            // txtConsulta
            // 
            this.txtConsulta.Location = new System.Drawing.Point(296, 30);
            this.txtConsulta.Name = "txtConsulta";
            this.txtConsulta.Size = new System.Drawing.Size(502, 31);
            this.txtConsulta.TabIndex = 3;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscar.Depth = 0;
            this.btnBuscar.Location = new System.Drawing.Point(804, 29);
            this.btnBuscar.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Primary = true;
            this.btnBuscar.Size = new System.Drawing.Size(90, 33);
            this.btnBuscar.TabIndex = 4;
            this.btnBuscar.Text = "BUSCAR";
            this.btnBuscar.UseVisualStyleBackColor = true;
            // 
            // btnLimpar
            // 
            this.btnLimpar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLimpar.Depth = 0;
            this.btnLimpar.Location = new System.Drawing.Point(900, 29);
            this.btnLimpar.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Primary = true;
            this.btnLimpar.Size = new System.Drawing.Size(90, 33);
            this.btnLimpar.TabIndex = 5;
            this.btnLimpar.Text = "LIMPAR";
            this.btnLimpar.UseVisualStyleBackColor = true;
            // 
            // btnNovo
            // 
            this.btnNovo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnNovo.Depth = 0;
            this.btnNovo.Location = new System.Drawing.Point(462, 76);
            this.btnNovo.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Primary = true;
            this.btnNovo.Size = new System.Drawing.Size(90, 33);
            this.btnNovo.TabIndex = 7;
            this.btnNovo.Text = "NOVO";
            this.btnNovo.UseVisualStyleBackColor = false;
            // 
            // btnAlterar
            // 
            this.btnAlterar.Depth = 0;
            this.btnAlterar.Location = new System.Drawing.Point(558, 76);
            this.btnAlterar.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Primary = true;
            this.btnAlterar.Size = new System.Drawing.Size(90, 33);
            this.btnAlterar.TabIndex = 8;
            this.btnAlterar.Text = "ALTERAR";
            this.btnAlterar.UseVisualStyleBackColor = true;
            // 
            // btnExcluir
            // 
            this.btnExcluir.Depth = 0;
            this.btnExcluir.Location = new System.Drawing.Point(654, 76);
            this.btnExcluir.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Primary = true;
            this.btnExcluir.Size = new System.Drawing.Size(90, 33);
            this.btnExcluir.TabIndex = 9;
            this.btnExcluir.Text = "EXCLUIR";
            this.btnExcluir.UseVisualStyleBackColor = true;
            // 
            // btnCanvas
            // 
            this.btnCanvas.Depth = 0;
            this.btnCanvas.Location = new System.Drawing.Point(790, 76);
            this.btnCanvas.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnCanvas.Name = "btnCanvas";
            this.btnCanvas.Primary = true;
            this.btnCanvas.Size = new System.Drawing.Size(90, 33);
            this.btnCanvas.TabIndex = 10;
            this.btnCanvas.Text = "CANVAS";
            this.btnCanvas.UseVisualStyleBackColor = true;
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1021, 768);
            this.Controls.Add(this.btnCanvas);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnAlterar);
            this.Controls.Add(this.btnNovo);
            this.Controls.Add(this.materialDivider1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvDados);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmMenu";
            this.Text = "StartUp Manager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMenu_FormClosing);
            this.Load += new System.EventHandler(this.frmMenu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDados)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDados;
        private System.Windows.Forms.GroupBox groupBox1;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private MaterialSkin.Controls.MaterialDivider materialDivider1;
        private MaterialSkin.Controls.MaterialRaisedButton btnLimpar;
        private MaterialSkin.Controls.MaterialRaisedButton btnBuscar;
        private System.Windows.Forms.TextBox txtConsulta;
        private MaterialSkin.Controls.MaterialRaisedButton btnNovo;
        private MaterialSkin.Controls.MaterialRaisedButton btnAlterar;
        private MaterialSkin.Controls.MaterialRaisedButton btnExcluir;
        private MaterialSkin.Controls.MaterialRaisedButton btnCanvas;
    }
}