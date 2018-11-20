namespace Carrera
{
    partial class Form1
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
            this.pgbCarril1 = new System.Windows.Forms.ProgressBar();
            this.pgbCarril2 = new System.Windows.Forms.ProgressBar();
            this.lblCarril1 = new System.Windows.Forms.Label();
            this.lblCarril2 = new System.Windows.Forms.Label();
            this.btnCorrer = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pgbCarril1
            // 
            this.pgbCarril1.Location = new System.Drawing.Point(163, 21);
            this.pgbCarril1.Name = "pgbCarril1";
            this.pgbCarril1.Size = new System.Drawing.Size(233, 23);
            this.pgbCarril1.TabIndex = 0;
            // 
            // pgbCarril2
            // 
            this.pgbCarril2.Location = new System.Drawing.Point(163, 50);
            this.pgbCarril2.Name = "pgbCarril2";
            this.pgbCarril2.Size = new System.Drawing.Size(233, 23);
            this.pgbCarril2.TabIndex = 1;
            // 
            // lblCarril1
            // 
            this.lblCarril1.AutoSize = true;
            this.lblCarril1.Location = new System.Drawing.Point(24, 21);
            this.lblCarril1.Name = "lblCarril1";
            this.lblCarril1.Size = new System.Drawing.Size(42, 13);
            this.lblCarril1.TabIndex = 2;
            this.lblCarril1.Text = "Carril 1:";
            // 
            // lblCarril2
            // 
            this.lblCarril2.AutoSize = true;
            this.lblCarril2.Location = new System.Drawing.Point(24, 60);
            this.lblCarril2.Name = "lblCarril2";
            this.lblCarril2.Size = new System.Drawing.Size(42, 13);
            this.lblCarril2.TabIndex = 3;
            this.lblCarril2.Text = "Carril 2:";
            // 
            // btnCorrer
            // 
            this.btnCorrer.Location = new System.Drawing.Point(283, 89);
            this.btnCorrer.Name = "btnCorrer";
            this.btnCorrer.Size = new System.Drawing.Size(113, 35);
            this.btnCorrer.TabIndex = 4;
            this.btnCorrer.Text = "Correr";
            this.btnCorrer.UseVisualStyleBackColor = true;
            this.btnCorrer.Click += new System.EventHandler(this.btnCorrer_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(70, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(73, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "label2";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 165);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCorrer);
            this.Controls.Add(this.lblCarril2);
            this.Controls.Add(this.lblCarril1);
            this.Controls.Add(this.pgbCarril2);
            this.Controls.Add(this.pgbCarril1);
            this.Name = "Form1";
            this.Text = "RSP";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar pgbCarril1;
        private System.Windows.Forms.ProgressBar pgbCarril2;
        private System.Windows.Forms.Label lblCarril1;
        private System.Windows.Forms.Label lblCarril2;
        private System.Windows.Forms.Button btnCorrer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

