namespace InterfaceDesigner
{
    partial class NewScript
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
            this.Description = new System.Windows.Forms.Label();
            this.ActionsScript = new System.Windows.Forms.ListBox();
            this.Next = new System.Windows.Forms.Button();
            this.Back = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Description
            // 
            this.Description.Dock = System.Windows.Forms.DockStyle.Top;
            this.Description.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Description.Location = new System.Drawing.Point(0, 0);
            this.Description.Name = "Description";
            this.Description.Size = new System.Drawing.Size(305, 48);
            this.Description.TabIndex = 1;
            this.Description.Text = "Описание";
            this.Description.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // ActionsScript
            // 
            this.ActionsScript.Dock = System.Windows.Forms.DockStyle.Top;
            this.ActionsScript.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ActionsScript.FormattingEnabled = true;
            this.ActionsScript.ItemHeight = 19;
            this.ActionsScript.Location = new System.Drawing.Point(0, 48);
            this.ActionsScript.Name = "ActionsScript";
            this.ActionsScript.Size = new System.Drawing.Size(305, 213);
            this.ActionsScript.TabIndex = 0;
            // 
            // Next
            // 
            this.Next.Dock = System.Windows.Forms.DockStyle.Left;
            this.Next.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Next.Location = new System.Drawing.Point(0, 261);
            this.Next.Name = "Next";
            this.Next.Size = new System.Drawing.Size(154, 25);
            this.Next.TabIndex = 2;
            this.Next.Text = "Далее";
            this.Next.UseVisualStyleBackColor = true;
            this.Next.Click += new System.EventHandler(this.Next_Click);
            // 
            // Back
            // 
            this.Back.Dock = System.Windows.Forms.DockStyle.Right;
            this.Back.Enabled = false;
            this.Back.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Back.Location = new System.Drawing.Point(151, 261);
            this.Back.Name = "Back";
            this.Back.Size = new System.Drawing.Size(154, 25);
            this.Back.TabIndex = 3;
            this.Back.Text = "Назад";
            this.Back.UseVisualStyleBackColor = true;
            this.Back.Click += new System.EventHandler(this.Back_Click);
            // 
            // NewScript
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(305, 286);
            this.Controls.Add(this.Back);
            this.Controls.Add(this.Next);
            this.Controls.Add(this.ActionsScript);
            this.Controls.Add(this.Description);
            this.Name = "NewScript";
            this.Text = "NewScript";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label Description;
        private System.Windows.Forms.ListBox ActionsScript;
        private System.Windows.Forms.Button Next;
        private System.Windows.Forms.Button Back;
    }
}