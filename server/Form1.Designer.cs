
namespace server
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.OpenFileDialog fileBrowser;
        private System.Windows.Forms.Button serverButton;
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
            addButton = new Button();
            serverButton = new Button();
            fileBrowser = new OpenFileDialog();
            SuspendLayout();
            // 
            // addButton
            // 
            addButton.Location = new Point(162, 156);
            addButton.Margin = new Padding(4, 5, 4, 5);
            addButton.Name = "addButton";
            addButton.Size = new Size(150, 35);
            addButton.TabIndex = 0;
            addButton.Text = "Add File";
            addButton.UseVisualStyleBackColor = true;
            addButton.Click += buttonAddFile_Click;
            // 
            // serverButton
            // 
            serverButton.Location = new Point(613, 156);
            serverButton.Name = "serverButton";
            serverButton.Size = new Size(150, 35);
            serverButton.TabIndex = 0;
            serverButton.Text = "Server";
            serverButton.UseVisualStyleBackColor = true;
            serverButton.Click += serverButton_Click;
            // 
            // fileBrowser
            // 
            fileBrowser.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(955, 378);
            Controls.Add(addButton);
            Controls.Add(serverButton);
            Margin = new Padding(4, 5, 4, 5);
            Name = "Form1";
            Text = "Server";
            ResumeLayout(false);
        }

        #endregion
    }
}