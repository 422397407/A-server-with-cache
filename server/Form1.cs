namespace server
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonAddFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "All files (*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Server.AddFile(dialog.FileName);
                MessageBox.Show("File added successfully!");
            }
        }

        private void serverButton_Click(object sender, EventArgs e)
        {
            Thread serverThread = new(Server.StartServer);
            serverThread.Start();
        }
    }


}
