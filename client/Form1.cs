using System.Net;
using System.Net.Sockets;
using System.Text;
using cache;

namespace client
{
    public partial class Form1 : Form
    {
        private TcpClient client;
        private NetworkStream stream;
        private const int CommandListFiles = 3;
        private const int CommandDownloadFile = 1;

        public Form1()
        {
            InitializeComponent();
        }

        //cache GUI
        private void buttonShowCache_Click(object sender, EventArgs e)
        {
            Cache cache = new Cache();
            cache.ShowCacheForm();
        }
        // - ls
        private void buttonListFiles_Click(object sender, EventArgs e)
        {
            client = new TcpClient();
            client.Connect(IPAddress.Loopback, 8083);
            // get the network stream
            stream = client.GetStream();
            // send show list command
            byte[] commandBytes = { CommandListFiles };
            stream.Write(commandBytes, 0, commandBytes.Length);
            stream.Flush();
            // Receive result
            byte[] buffer = new byte[1024];
            stream.Read(buffer, 0, buffer.Length);

            string fileList = Encoding.UTF8.GetString(buffer);
            string[] files = fileList.Split('\n');
            listBoxFiles.Items.Clear();
            foreach (string file in files)
            {
                listBoxFiles.Items.Add(file);
            }
            stream.Close();
            client.Close();

        }

        //Download
        private void buttonDownloadFile_Click(object sender, EventArgs e)
        {
            if (listBoxFiles.SelectedItem != null)
            {
                client = new TcpClient();
                client.Connect(IPAddress.Loopback, 8083);

                // get the network stream
                string fileName = listBoxFiles.SelectedItem.ToString();
                byte[] fileNameBytes = Encoding.UTF8.GetBytes(fileName);
                byte[] fileNameLengthBytes = BitConverter.GetBytes(fileNameBytes.Length);
                byte[] data = new byte[5 + fileNameBytes.Length];
                data[0] = CommandDownloadFile;
                Array.Copy(fileNameLengthBytes, 0, data, 1, fileNameLengthBytes.Length);
                Array.Copy(fileNameBytes, 0, data, 5, fileNameBytes.Length);
                using (NetworkStream stream = client.GetStream())
                {
                    // Send the data to the server
                    stream.Write(data, 0, data.Length);
                    stream.Flush();

                    byte[] buffer = new byte[1024];
                    stream.Read(buffer, 0, buffer.Length);

                    string fileList = Encoding.UTF8.GetString(buffer);
                    textBoxFileContents.Text = fileList;
                }
                stream.Close();
                client.Close();
            }
        }
    }
}
