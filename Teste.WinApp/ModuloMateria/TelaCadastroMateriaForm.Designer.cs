namespace Testes.WinApp.ModuloMateria
{
    partial class TelaCadastroMateriaForm
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
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelDisciplina = new System.Windows.Forms.Label();
            this.comboBoxDisciplina = new System.Windows.Forms.ComboBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGravar = new System.Windows.Forms.Button();
            this.comboBoxSerie = new System.Windows.Forms.ComboBox();
            this.labelSerie = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtNumero
            // 
            this.txtNumero.BackColor = System.Drawing.Color.White;
            this.txtNumero.Enabled = false;
            this.txtNumero.Location = new System.Drawing.Point(82, 12);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(47, 23);
            this.txtNumero.TabIndex = 38;
            // 
            // txtNome
            // 
            this.txtNome.BackColor = System.Drawing.Color.White;
            this.txtNome.Location = new System.Drawing.Point(82, 41);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(385, 23);
            this.txtNome.TabIndex = 35;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 44);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 15);
            this.label4.TabIndex = 37;
            this.label4.Text = "Nome:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 15);
            this.label1.TabIndex = 36;
            this.label1.Text = "Número:";
            // 
            // labelDisciplina
            // 
            this.labelDisciplina.AutoSize = true;
            this.labelDisciplina.Location = new System.Drawing.Point(28, 77);
            this.labelDisciplina.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDisciplina.Name = "labelDisciplina";
            this.labelDisciplina.Size = new System.Drawing.Size(61, 15);
            this.labelDisciplina.TabIndex = 39;
            this.labelDisciplina.Text = "Disciplina:";
            // 
            // comboBoxDisciplina
            // 
            this.comboBoxDisciplina.FormattingEnabled = true;
            this.comboBoxDisciplina.Location = new System.Drawing.Point(96, 74);
            this.comboBoxDisciplina.Name = "comboBoxDisciplina";
            this.comboBoxDisciplina.Size = new System.Drawing.Size(231, 23);
            this.comboBoxDisciplina.TabIndex = 40;
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(399, 134);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(72, 39);
            this.btnCancelar.TabIndex = 42;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnGravar
            // 
            this.btnGravar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnGravar.Location = new System.Drawing.Point(318, 134);
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.Size = new System.Drawing.Size(72, 39);
            this.btnGravar.TabIndex = 41;
            this.btnGravar.Text = "Gravar";
            this.btnGravar.UseVisualStyleBackColor = true;
            this.btnGravar.Click += new System.EventHandler(this.btnGravar_Click);
            // 
            // comboBoxSerie
            // 
            this.comboBoxSerie.FormattingEnabled = true;
            this.comboBoxSerie.Items.AddRange(new object[] {
            "1ª",
            "2ª"});
            this.comboBoxSerie.Location = new System.Drawing.Point(96, 105);
            this.comboBoxSerie.Name = "comboBoxSerie";
            this.comboBoxSerie.Size = new System.Drawing.Size(74, 23);
            this.comboBoxSerie.TabIndex = 44;
            // 
            // labelSerie
            // 
            this.labelSerie.AutoSize = true;
            this.labelSerie.Location = new System.Drawing.Point(36, 108);
            this.labelSerie.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSerie.Name = "labelSerie";
            this.labelSerie.Size = new System.Drawing.Size(35, 15);
            this.labelSerie.TabIndex = 43;
            this.labelSerie.Text = "Série:";
            // 
            // TelaCadastroMateriaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 185);
            this.Controls.Add(this.comboBoxSerie);
            this.Controls.Add(this.labelSerie);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGravar);
            this.Controls.Add(this.comboBoxDisciplina);
            this.Controls.Add(this.labelDisciplina);
            this.Controls.Add(this.txtNumero);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TelaCadastroMateriaForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de matéria";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelDisciplina;
        private System.Windows.Forms.ComboBox comboBoxDisciplina;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGravar;
        private System.Windows.Forms.ComboBox comboBoxSerie;
        private System.Windows.Forms.Label labelSerie;
    }
}