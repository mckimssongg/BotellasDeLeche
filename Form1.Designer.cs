namespace BotellasDeLeche
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox comboBoxModo;
        private System.Windows.Forms.Button btnIniciar;
        private System.Windows.Forms.NumericUpDown numericUpDownCompaneros;
        private System.Windows.Forms.ListBox listBoxLog;
        private System.Windows.Forms.Label labelModo;
        private System.Windows.Forms.Label labelCompaneros;

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.comboBoxModo = new System.Windows.Forms.ComboBox();
            this.btnIniciar = new System.Windows.Forms.Button();
            this.numericUpDownCompaneros = new System.Windows.Forms.NumericUpDown();
            this.listBoxLog = new System.Windows.Forms.ListBox();
            this.labelModo = new System.Windows.Forms.Label();
            this.labelCompaneros = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCompaneros)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxModo
            // 
            this.comboBoxModo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxModo.FormattingEnabled = true;
            this.comboBoxModo.Items.AddRange(new object[] {
            "Hilos (Parte a)",
            "Procesos (Parte b)"});
            this.comboBoxModo.Location = new System.Drawing.Point(12, 29);
            this.comboBoxModo.Name = "comboBoxModo";
            this.comboBoxModo.Size = new System.Drawing.Size(200, 24);
            this.comboBoxModo.TabIndex = 0;
            // 
            // btnIniciar
            // 
            this.btnIniciar.Location = new System.Drawing.Point(457, 29);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(200, 24);
            this.btnIniciar.TabIndex = 1;
            this.btnIniciar.Text = "Iniciar Simulación";
            this.btnIniciar.UseVisualStyleBackColor = true;
            this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click);
            // 
            // numericUpDownCompaneros
            // 
            this.numericUpDownCompaneros.Location = new System.Drawing.Point(238, 30);
            this.numericUpDownCompaneros.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDownCompaneros.Name = "numericUpDownCompaneros";
            this.numericUpDownCompaneros.Size = new System.Drawing.Size(200, 22);
            this.numericUpDownCompaneros.TabIndex = 2;
            this.numericUpDownCompaneros.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // listBoxLog
            // 
            this.listBoxLog.FormattingEnabled = true;
            this.listBoxLog.ItemHeight = 16;
            this.listBoxLog.Location = new System.Drawing.Point(12, 70);
            this.listBoxLog.Name = "listBoxLog";
            this.listBoxLog.Size = new System.Drawing.Size(776, 356);
            this.listBoxLog.TabIndex = 3;
            // 
            // labelModo
            // 
            this.labelModo.AutoSize = true;
            this.labelModo.Location = new System.Drawing.Point(12, 9);
            this.labelModo.Name = "labelModo";
            this.labelModo.Size = new System.Drawing.Size(123, 17);
            this.labelModo.TabIndex = 4;
            this.labelModo.Text = "Seleccione el modo:";
            // 
            // labelCompaneros
            // 
            this.labelCompaneros.AutoSize = true;
            this.labelCompaneros.Location = new System.Drawing.Point(235, 9);
            this.labelCompaneros.Name = "labelCompaneros";
            this.labelCompaneros.Size = new System.Drawing.Size(160, 17);
            this.labelCompaneros.TabIndex = 5;
            this.labelCompaneros.Text = "Número de compañeros:";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelCompaneros);
            this.Controls.Add(this.labelModo);
            this.Controls.Add(this.listBoxLog);
            this.Controls.Add(this.numericUpDownCompaneros);
            this.Controls.Add(this.btnIniciar);
            this.Controls.Add(this.comboBoxModo);
            this.Name = "Form1";
            this.Text = "Demasiadas Botellas de Leche";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCompaneros)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
    }
}
