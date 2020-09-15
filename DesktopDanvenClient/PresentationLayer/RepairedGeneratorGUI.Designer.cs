namespace DesktopDanvenClient {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.generatorListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // generatorListBox
            // 
            this.generatorListBox.FormattingEnabled = true;
            this.generatorListBox.ItemHeight = 20;
            this.generatorListBox.Location = new System.Drawing.Point(12, 55);
            this.generatorListBox.Name = "generatorListBox";
            this.generatorListBox.Size = new System.Drawing.Size(263, 304);
            this.generatorListBox.TabIndex = 0;
            this.generatorListBox.SelectedIndexChanged += new System.EventHandler(this.generatorListBox_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 488);
            this.Controls.Add(this.generatorListBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox generatorListBox;
    }
}

