namespace Paint
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dlgColor = new ColorDialog();
            btnColor = new Button();
            SuspendLayout();
            // 
            // btnColor
            // 
            btnColor.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnColor.Location = new Point(12, 309);
            btnColor.Name = "btnColor";
            btnColor.Size = new Size(75, 23);
            btnColor.TabIndex = 0;
            btnColor.Text = "Color";
            btnColor.UseVisualStyleBackColor = true;
            btnColor.Click += btnColor_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(549, 344);
            Controls.Add(btnColor);
            Cursor = Cursors.Cross;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Paint";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private ColorDialog dlgColor;
        private Button btnColor;
    }
}
