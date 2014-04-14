namespace GeneticsLab
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.dataGridViewResults = new System.Windows.Forms.DataGridView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.processButton = new System.Windows.Forms.ToolStripButton();
            this.oneName = new System.Windows.Forms.TextBox();
            this.oneAlign = new System.Windows.Forms.TextBox();
            this.twoAlign = new System.Windows.Forms.TextBox();
            this.twoName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResults)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewResults
            // 
            this.dataGridViewResults.AllowUserToAddRows = false;
            this.dataGridViewResults.AllowUserToDeleteRows = false;
            this.dataGridViewResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewResults.Location = new System.Drawing.Point(12, 28);
            this.dataGridViewResults.Name = "dataGridViewResults";
            this.dataGridViewResults.ReadOnly = true;
            this.dataGridViewResults.Size = new System.Drawing.Size(855, 287);
            this.dataGridViewResults.TabIndex = 0;
            this.dataGridViewResults.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewResults_CellClick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusMessage});
            this.statusStrip1.Location = new System.Drawing.Point(0, 439);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(879, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusMessage
            // 
            this.statusMessage.Name = "statusMessage";
            this.statusMessage.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.processButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(879, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // processButton
            // 
            this.processButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.processButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.processButton.Image = ((System.Drawing.Image)(resources.GetObject("processButton.Image")));
            this.processButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.processButton.Name = "processButton";
            this.processButton.Size = new System.Drawing.Size(51, 22);
            this.processButton.Text = "Process";
            this.processButton.Click += new System.EventHandler(this.processButton_Click);
            // 
            // oneName
            // 
            this.oneName.Location = new System.Drawing.Point(340, 321);
            this.oneName.Name = "oneName";
            this.oneName.Size = new System.Drawing.Size(160, 20);
            this.oneName.TabIndex = 3;
            // 
            // oneAlign
            // 
            this.oneAlign.Location = new System.Drawing.Point(195, 348);
            this.oneAlign.Name = "oneAlign";
            this.oneAlign.Size = new System.Drawing.Size(485, 20);
            this.oneAlign.TabIndex = 4;
            // 
            // twoAlign
            // 
            this.twoAlign.Location = new System.Drawing.Point(195, 383);
            this.twoAlign.Name = "twoAlign";
            this.twoAlign.Size = new System.Drawing.Size(485, 20);
            this.twoAlign.TabIndex = 5;
            // 
            // twoName
            // 
            this.twoName.Location = new System.Drawing.Point(340, 409);
            this.twoName.Name = "twoName";
            this.twoName.Size = new System.Drawing.Size(160, 20);
            this.twoName.TabIndex = 6;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(879, 461);
            this.Controls.Add(this.twoName);
            this.Controls.Add(this.twoAlign);
            this.Controls.Add(this.oneAlign);
            this.Controls.Add(this.oneName);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.dataGridViewResults);
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.Text = "CS 312 - Project #3 - Gene Sequence Alignment";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResults)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewResults;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusMessage;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton processButton;
        private System.Windows.Forms.TextBox oneName;
        private System.Windows.Forms.TextBox oneAlign;
        private System.Windows.Forms.TextBox twoAlign;
        private System.Windows.Forms.TextBox twoName;
    }
}

