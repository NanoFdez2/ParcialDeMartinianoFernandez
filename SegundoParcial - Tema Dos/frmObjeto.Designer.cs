namespace SegundoParcial___Tema_Dos
{
    partial class frmObjeto
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
            components = new System.ComponentModel.Container();
            label1 = new Label();
            txtCaractUno = new TextBox();
            cboCaractCuatro = new ComboBox();
            label4 = new Label();
            cboCaractCinco = new ComboBox();
            label5 = new Label();
            btnOK = new Button();
            btnCancelar = new Button();
            errorProvider1 = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 22);
            label1.Name = "label1";
            label1.Size = new Size(87, 15);
            label1.TabIndex = 0;
            label1.Text = "Ingrese el radio";
            // 
            // txtCaractUno
            // 
            txtCaractUno.Location = new Point(105, 19);
            txtCaractUno.Name = "txtCaractUno";
            txtCaractUno.Size = new Size(100, 23);
            txtCaractUno.TabIndex = 1;
            // 
            // cboCaractCuatro
            // 
            cboCaractCuatro.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCaractCuatro.FormattingEnabled = true;
            cboCaractCuatro.Location = new Point(387, 19);
            cboCaractCuatro.Name = "cboCaractCuatro";
            cboCaractCuatro.Size = new Size(121, 23);
            cboCaractCuatro.TabIndex = 6;
            cboCaractCuatro.SelectedIndexChanged += cboCaractCuatro_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(345, 22);
            label4.Name = "label4";
            label4.Size = new Size(36, 15);
            label4.TabIndex = 7;
            label4.Text = "Color";
            // 
            // cboCaractCinco
            // 
            cboCaractCinco.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCaractCinco.FormattingEnabled = true;
            cboCaractCinco.Location = new Point(387, 90);
            cboCaractCinco.Name = "cboCaractCinco";
            cboCaractCinco.Size = new Size(121, 23);
            cboCaractCinco.TabIndex = 8;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(298, 93);
            label5.Name = "label5";
            label5.Size = new Size(83, 15);
            label5.TabIndex = 9;
            label5.Text = "Trazo de líneas";
            // 
            // btnOK
            // 
            btnOK.Location = new Point(129, 252);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(76, 67);
            btnOK.TabIndex = 10;
            btnOK.Text = "OK";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(294, 252);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(76, 67);
            btnCancelar.TabIndex = 11;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // frmObjeto
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(717, 422);
            Controls.Add(btnCancelar);
            Controls.Add(btnOK);
            Controls.Add(label5);
            Controls.Add(cboCaractCinco);
            Controls.Add(label4);
            Controls.Add(cboCaractCuatro);
            Controls.Add(txtCaractUno);
            Controls.Add(label1);
            Name = "frmObjeto";
            Text = "frmObjeto";
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtCaractUno;
        private ComboBox cboCaractCuatro;
        private Label label4;
        private ComboBox cboCaractCinco;
        private Label label5;
        private Button btnOK;
        private Button btnCancelar;
        private ErrorProvider errorProvider1;
    }
}