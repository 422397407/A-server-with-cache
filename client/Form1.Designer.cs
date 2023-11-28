namespace client
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ListBox listBoxFiles;
        private System.Windows.Forms.TextBox textBoxFileContents;
        private System.Windows.Forms.Button buttonDownloadFile;
        private System.Windows.Forms.Button buttonListFiles;
        private System.Windows.Forms.Button buttonShowCacheClick;
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
            listBoxFiles = new ListBox();
            textBoxFileContents = new TextBox();
            buttonListFiles = new Button();
            buttonDownloadFile = new Button();
            buttonShowCacheClick = new Button();
            SuspendLayout();
            // 
            // listBoxFiles
            // 
            listBoxFiles.FormattingEnabled = true;
            listBoxFiles.ItemHeight = 20;
            listBoxFiles.Location = new Point(15, 16);
            listBoxFiles.Margin = new Padding(4);
            listBoxFiles.Name = "listBoxFiles";
            listBoxFiles.Size = new Size(256, 564);
            listBoxFiles.TabIndex = 0;
            // 
            // textBoxFileContents
            // 
            textBoxFileContents.Location = new Point(293, 55);
            textBoxFileContents.Margin = new Padding(4);
            textBoxFileContents.Multiline = true;
            textBoxFileContents.Name = "textBoxFileContents";
            textBoxFileContents.ReadOnly = true;
            textBoxFileContents.ScrollBars = ScrollBars.Vertical;
            textBoxFileContents.Size = new Size(566, 490);
            textBoxFileContents.TabIndex = 1;
            // 
            // buttonListFiles
            // 
            buttonListFiles.Location = new Point(350, 16);
            buttonListFiles.Margin = new Padding(4);
            buttonListFiles.Name = "buttonListFiles";
            buttonListFiles.Size = new Size(139, 31);
            buttonListFiles.TabIndex = 2;
            buttonListFiles.Text = "List Files";
            buttonListFiles.UseVisualStyleBackColor = true;
            buttonListFiles.Click += buttonListFiles_Click;
            // 
            // buttonDownloadFile
            // 
            buttonDownloadFile.Location = new Point(550, 16);
            buttonDownloadFile.Margin = new Padding(4);
            buttonDownloadFile.Name = "buttonDownloadFile";
            buttonDownloadFile.Size = new Size(139, 31);
            buttonDownloadFile.TabIndex = 3;
            buttonDownloadFile.Text = "Download";
            buttonDownloadFile.UseVisualStyleBackColor = true;
            buttonDownloadFile.Click += buttonDownloadFile_Click;
            // 
            // buttonShowCacheClick
            // 
            buttonShowCacheClick.Location = new Point(750, 16);
            buttonShowCacheClick.Margin = new Padding(4);
            buttonShowCacheClick.Name = "buttonShowCacheClick";
            buttonShowCacheClick.Size = new Size(139, 31);
            buttonShowCacheClick.TabIndex = 4;
            buttonShowCacheClick.Text = "Open Cache";
            buttonShowCacheClick.UseVisualStyleBackColor = true;
            buttonShowCacheClick.Click += buttonShowCache_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1029, 600);
            Controls.Add(textBoxFileContents);
            Controls.Add(listBoxFiles);
            Controls.Add(buttonListFiles);
            Controls.Add(buttonDownloadFile);
            Controls.Add(buttonShowCacheClick);
            Margin = new Padding(4);
            Name = "Form1";
            Text = "File Downloader";
            ResumeLayout(false);
            PerformLayout();
        }
    }


    #endregion
}
