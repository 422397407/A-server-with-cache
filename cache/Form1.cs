using System.IO;
using System.Net.Sockets;
using System.Net;
using System.Text;
using cache;
namespace cache
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        //Changelog textbox
        public void UpdateLogTextBox()
        {
            string logPath = "../../../../cache/cache_data";
            string log_Path = Path.Combine(logPath, "cachelog.txt");
            if (File.Exists(log_Path))
            {
                string logText = File.ReadAllText(log_Path);
                logText = logText.Replace("\n", Environment.NewLine);
                textBoxLog.Text = logText;
            }
            else
            {
                textBoxLog.Text = "Log error!";
            }
        }

        // Update file list box
        public void UpdateFileListBox()
        {
            string path = "../../../../cache/cache_data";
            listBoxFiles.Items.Clear();
            foreach (string fileName in Directory.GetFiles(path))
            {
                if (Path.GetFileName(fileName) != "cachelog.txt")
                {
                    listBoxFiles.Items.Add(Path.GetFileName(fileName));
                }
            }
        }
        //Clearbutton
        public void buttonClearCache_Click(object sender, EventArgs e)
        {
            ClearCache();
            UpdateFileListBox();
            UpdateLogTextBox();
        }
        //Clear
        private void ClearCache()
        {
            string logPath = "../../../../cache/cache_data";
            DirectoryInfo directory = new DirectoryInfo(logPath);
            foreach (FileInfo file in directory.GetFiles())
            {
                file.Delete();
            }
            File.WriteAllText(Path.Combine(logPath, "cachelog.txt"), "Cache cleared at " + DateTime.Now.ToString() + "\n");
        }

        public void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void show_button_Click(object sender, EventArgs e)
        {
            UpdateLogTextBox();
            UpdateFileListBox();
        }
    }

}