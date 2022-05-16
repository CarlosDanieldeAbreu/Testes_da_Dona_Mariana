namespace Testes.WinApp.ModuloQuestão
{
    partial class TelaCadastroQuestaoForm
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
            this.comboBoxDisciplina = new System.Windows.Forms.ComboBox();
            this.labelDisciplina = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGravar = new System.Windows.Forms.Button();
            this.labelMateria = new System.Windows.Forms.Label();
            this.comboBoxMateria = new System.Windows.Forms.ComboBox();
            this.textBoxPergunta = new System.Windows.Forms.TextBox();
            this.labelPergunta = new System.Windows.Forms.Label();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.labelNumero = new System.Windows.Forms.Label();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.listItensRespostas = new System.Windows.Forms.ListBox();
            this.labelResposta = new System.Windows.Forms.Label();
            this.txtResposta = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBoxDisciplina
            // 
            this.comboBoxDisciplina.FormattingEnabled = true;
            this.comboBoxDisciplina.Location = new System.Drawing.Point(77, 55);
            this.comboBoxDisciplina.Name = "comboBoxDisciplina";
            this.comboBoxDisciplina.Size = new System.Drawing.Size(191, 23);
            this.comboBoxDisciplina.TabIndex = 0;
            this.comboBoxDisciplina.SelectedIndexChanged += new System.EventHandler(this.comboBoxDisciplina_SelectedIndexChanged);
            // 
            // labelDisciplina
            // 
            this.labelDisciplina.AutoSize = true;
            this.labelDisciplina.Location = new System.Drawing.Point(13, 58);
            this.labelDisciplina.Name = "labelDisciplina";
            this.labelDisciplina.Size = new System.Drawing.Size(61, 15);
            this.labelDisciplina.TabIndex = 1;
            this.labelDisciplina.Text = "Disciplina:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(307, 470);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(72, 39);
            this.btnCancelar.TabIndex = 44;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnGravar
            // 
            this.btnGravar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnGravar.Location = new System.Drawing.Point(226, 470);
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.Size = new System.Drawing.Size(72, 39);
            this.btnGravar.TabIndex = 43;
            this.btnGravar.Text = "Gravar";
            this.btnGravar.UseVisualStyleBackColor = true;
            this.btnGravar.Click += new System.EventHandler(this.btnGravar_Click);
            // 
            // labelMateria
            // 
            this.labelMateria.AutoSize = true;
            this.labelMateria.Location = new System.Drawing.Point(13, 87);
            this.labelMateria.Name = "labelMateria";
            this.labelMateria.Size = new System.Drawing.Size(50, 15);
            this.labelMateria.TabIndex = 46;
            this.labelMateria.Text = "Matéria:";
            // 
            // comboBoxMateria
            // 
            this.comboBoxMateria.FormattingEnabled = true;
            this.comboBoxMateria.Location = new System.Drawing.Point(77, 84);
            this.comboBoxMateria.Name = "comboBoxMateria";
            this.comboBoxMateria.Size = new System.Drawing.Size(191, 23);
            this.comboBoxMateria.TabIndex = 45;
            // 
            // textBoxPergunta
            // 
            this.textBoxPergunta.Location = new System.Drawing.Point(13, 136);
            this.textBoxPergunta.Multiline = true;
            this.textBoxPergunta.Name = "textBoxPergunta";
            this.textBoxPergunta.Size = new System.Drawing.Size(366, 102);
            this.textBoxPergunta.TabIndex = 47;
            // 
            // labelPergunta
            // 
            this.labelPergunta.AutoSize = true;
            this.labelPergunta.Location = new System.Drawing.Point(13, 118);
            this.labelPergunta.Name = "labelPergunta";
            this.labelPergunta.Size = new System.Drawing.Size(171, 15);
            this.labelPergunta.TabIndex = 48;
            this.labelPergunta.Text = "Digite o enunciado da questão:";
            // 
            // txtNumero
            // 
            this.txtNumero.Enabled = false;
            this.txtNumero.Location = new System.Drawing.Point(77, 26);
            this.txtNumero.Multiline = true;
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(38, 23);
            this.txtNumero.TabIndex = 63;
            // 
            // labelNumero
            // 
            this.labelNumero.AutoSize = true;
            this.labelNumero.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelNumero.Location = new System.Drawing.Point(19, 29);
            this.labelNumero.Name = "labelNumero";
            this.labelNumero.Size = new System.Drawing.Size(54, 15);
            this.labelNumero.TabIndex = 62;
            this.labelNumero.Text = "Número:";
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.Location = new System.Drawing.Point(291, 296);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(75, 23);
            this.btnAdicionar.TabIndex = 67;
            this.btnAdicionar.Text = "Adicionar";
            this.btnAdicionar.UseVisualStyleBackColor = true;
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
            // 
            // listItensRespostas
            // 
            this.listItensRespostas.FormattingEnabled = true;
            this.listItensRespostas.ItemHeight = 15;
            this.listItensRespostas.Location = new System.Drawing.Point(13, 325);
            this.listItensRespostas.Name = "listItensRespostas";
            this.listItensRespostas.Size = new System.Drawing.Size(352, 139);
            this.listItensRespostas.TabIndex = 66;
            // 
            // labelResposta
            // 
            this.labelResposta.AutoSize = true;
            this.labelResposta.Location = new System.Drawing.Point(14, 298);
            this.labelResposta.Name = "labelResposta";
            this.labelResposta.Size = new System.Drawing.Size(57, 15);
            this.labelResposta.TabIndex = 65;
            this.labelResposta.Text = "Resposta:";
            // 
            // txtResposta
            // 
            this.txtResposta.Location = new System.Drawing.Point(74, 296);
            this.txtResposta.Name = "txtResposta";
            this.txtResposta.Size = new System.Drawing.Size(195, 23);
            this.txtResposta.TabIndex = 64;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 241);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(331, 45);
            this.label2.TabIndex = 68;
            this.label2.Text = "Digite as alternativas da questão:\r\nObservação adicione as alternativas inclusive" +
    " a correta \r\ne depois deixe escrito no campo resposta a alternativa correta\r\n";
            // 
            // TelaCadastroQuestaoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 515);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnAdicionar);
            this.Controls.Add(this.listItensRespostas);
            this.Controls.Add(this.labelResposta);
            this.Controls.Add(this.txtResposta);
            this.Controls.Add(this.txtNumero);
            this.Controls.Add(this.labelNumero);
            this.Controls.Add(this.labelPergunta);
            this.Controls.Add(this.textBoxPergunta);
            this.Controls.Add(this.labelMateria);
            this.Controls.Add(this.comboBoxMateria);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGravar);
            this.Controls.Add(this.labelDisciplina);
            this.Controls.Add(this.comboBoxDisciplina);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TelaCadastroQuestaoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de questão";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TelaCadastroQuestaosForm_FormClosing);
            this.Load += new System.EventHandler(this.TelaCadastroQuestoesForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxDisciplina;
        private System.Windows.Forms.Label labelDisciplina;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGravar;
        private System.Windows.Forms.Label labelMateria;
        private System.Windows.Forms.ComboBox comboBoxMateria;
        private System.Windows.Forms.TextBox textBoxPergunta;
        private System.Windows.Forms.Label labelPergunta;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.Label labelNumero;
        private System.Windows.Forms.Button btnAdicionar;
        private System.Windows.Forms.ListBox listItensRespostas;
        private System.Windows.Forms.Label labelResposta;
        private System.Windows.Forms.TextBox txtResposta;
        private System.Windows.Forms.Label label2;
    }
}