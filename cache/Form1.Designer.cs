namespace cache
{
    public partial class Form1
    {

        #region Windows Form Designer generated code

        public System.Windows.Forms.ListBox listBoxFiles;
        public System.Windows.Forms.Button buttonClearCache;
        public System.Windows.Forms.Button buttonExit;
        public System.Windows.Forms.TextBox textBoxLog;
        public System.Windows.Forms.Button show_button;
        public void InitializeComponent()
        {
            listBoxFiles = new ListBox();
            buttonClearCache = new Button();
            buttonExit = new Button();
            textBoxLog = new TextBox();
            show_button = new Button();
            SuspendLayout();
            // 
            // listBoxFiles
            // 
            listBoxFiles.FormattingEnabled = true;
            listBoxFiles.ItemHeight = 20;
            listBoxFiles.Location = new Point(10, 11);
            listBoxFiles.Margin = new Padding(4);
            listBoxFiles.Name = "listBoxFiles";
            listBoxFiles.Size = new Size(368, 304);
            listBoxFiles.TabIndex = 0;
            // 
            // buttonClearCache
            // 
            buttonClearCache.Location = new Point(210, 335);
            buttonClearCache.Margin = new Padding(4);
            buttonClearCache.Name = "buttonClearCache";
            buttonClearCache.Size = new Size(141, 72);
            buttonClearCache.TabIndex = 1;
            buttonClearCache.Text = "Clear Cache";
            buttonClearCache.UseVisualStyleBackColor = true;
            buttonClearCache.Click += buttonClearCache_Click;
            // 
            // buttonExit
            // 
            buttonExit.Location = new Point(847, 430);
            buttonExit.Margin = new Padding(4);
            buttonExit.Name = "buttonExit";
            buttonExit.Size = new Size(114, 41);
            buttonExit.TabIndex = 2;
            buttonExit.Text = "Exit";
            buttonExit.UseVisualStyleBackColor = true;
            buttonExit.Click += buttonExit_Click;
            // 
            // textBoxLog
            // 
            textBoxLog.Location = new Point(401, 11);
            textBoxLog.Margin = new Padding(4);
            textBoxLog.Multiline = true;
            textBoxLog.Name = "textBoxLog";
            textBoxLog.ReadOnly = true;
            textBoxLog.ScrollBars = ScrollBars.Vertical;
            textBoxLog.Size = new Size(560, 396);
            textBoxLog.TabIndex = 3;
            // 
            // show_button
            // 
            show_button.Location = new Point(28, 335);
            show_button.Margin = new Padding(4);
            show_button.Name = "show_button";
            show_button.Size = new Size(132, 72);
            show_button.TabIndex = 4;
            show_button.Text = "Show all data";
            show_button.UseVisualStyleBackColor = true;
            show_button.Click += show_button_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(974, 484);
            Controls.Add(show_button);
            Controls.Add(textBoxLog);
            Controls.Add(buttonExit);
            Controls.Add(buttonClearCache);
            Controls.Add(listBoxFiles);
            Margin = new Padding(4);
            Name = "Form1";
            Text = "Cache Server";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion


    }
}