namespace InterfaceDesigner
{
    partial class Variables
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
            this.VariablesToBind = new System.Windows.Forms.DataGridView();
            this.Bind = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.VariablesToBind)).BeginInit();
            this.SuspendLayout();
            // 
            // VariablesToBind
            // 
            this.VariablesToBind.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.VariablesToBind.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.VariablesToBind.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VariablesToBind.Location = new System.Drawing.Point(0, 0);
            this.VariablesToBind.Name = "VariablesToBind";
            this.VariablesToBind.Size = new System.Drawing.Size(900, 450);
            this.VariablesToBind.TabIndex = 0;
            this.VariablesToBind.Enter += new System.EventHandler(this.VariablesToBind_Enter);
            // 
            // Bind
            // 
            this.Bind.Location = new System.Drawing.Point(813, 415);
            this.Bind.Name = "Bind";
            this.Bind.Size = new System.Drawing.Size(75, 23);
            this.Bind.TabIndex = 1;
            this.Bind.Text = "Привязать";
            this.Bind.UseVisualStyleBackColor = true;
            this.Bind.Click += new System.EventHandler(this.Bind_Click);
            // 
            // Variables
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 450);
            this.Controls.Add(this.Bind);
            this.Controls.Add(this.VariablesToBind);
            this.Name = "Variables";
            this.Text = "Variables";
            ((System.ComponentModel.ISupportInitialize)(this.VariablesToBind)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView VariablesToBind;
        private System.Windows.Forms.Button Bind;
    }
}