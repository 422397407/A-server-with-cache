using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using cache;

namespace cache
{
    public class Cache
    {
        // Dictionary of cached files
        public static readonly Dictionary<string, byte[]> fileCache = new();
        // Record a list of cached logs
        public static string cacheLog = "";
        // list file list function
        public static string[] ListFiles()
        {
            string[] fileNames = fileCache.Keys.ToArray();
            return fileNames;
        }
        
        public void ShowCacheForm()
        {
            new Form1().ShowDialog();
        }
        
        // clear cache function
        public static void clear()
        {
            fileCache.Clear();
        }
        static void Main(string[] args)
        {
            // Create a TCP listener
            TcpListener listener = new TcpListener(IPAddress.Any, 8083);
            listener.Start();
            // Waiting for client connection

            while (true)
            {
                TcpClient client = listener.AcceptTcpClient();
                NetworkStream stream = client.GetStream();
                // receive command
                byte[] commandBytes = new byte[1];
                stream.Read(commandBytes, 0, 1);
                byte command = commandBytes[0];
                string path0 = Path.Combine(Directory.GetCurrentDirectory(), "../../../cache_data");
                string[] filenum = Directory.GetFiles(path0);
                if (filenum.Length == 1)
                {
                    clear();
                }
                //List file
                if (command == 3)
                {
                    TcpClient server = new TcpClient();
                    server.Connect(IPAddress.Loopback, 8081);
                    NetworkStream stream_server = server.GetStream();
                    // send command to server
                    stream_server.Write(commandBytes, 0, commandBytes.Length);
                    // Receiving the server's response
                    byte[] buffer = new byte[1024];
                    int bytesRead = stream_server.Read(buffer, 0, buffer.Length);
                    string fileList = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    // send the result to the client
                    StreamWriter writer = new(stream);
                    writer.Write(fileList);
                    writer.Flush();
                    stream.Close();
                    stream_server.Close();
                    client.Close();
                }
                //Download Flie
                else if (command == 1)
                {
                    // Receive filename length
                    byte[] data = new byte[4];
                    stream.Read(data, 0, 4);
                    int fileNameLength = BitConverter.ToInt32(data, 0);
                    // Receive file name
                    byte[] fileNameBytes = new byte[fileNameLength];
                    stream.Read(fileNameBytes, 0, fileNameLength);
                    string fileName = Encoding.UTF8.GetString(fileNameBytes);
                    // Handle file requests
                    string path = Path.Combine(Directory.GetCurrentDirectory(), "../../../cache_data");
                    cacheLog = "";
                    // If the file is already cached, return the cached file content
                    if (fileCache.TryGetValue(fileName, out byte[] value))
                    {
                        string fileContents = Encoding.UTF8.GetString(value);
                        // Record cache log
                        cacheLog = "";
                        string logEntry = string.Format("\n User request: file {0} at {1}", fileName, DateTime.Now.ToString());
                        cacheLog += logEntry;

                        logEntry = "\n Response: cached file " + fileName + "\n";
                        cacheLog += logEntry;
                        //Save the log in the cachelog file
                        string logpath = Path.Combine(path, "cachelog.txt");
                        using (StreamWriter writer_log = new StreamWriter(logpath, true))
                        {
                            writer_log.WriteLine(cacheLog);
                        }
                        StreamWriter writer_cache = new StreamWriter(stream);
                        // read the contents of the file and send them to the client
                        writer_cache.WriteLine(fileContents);
                        writer_cache.Flush();
                    }
                    else
                    {
                        TcpClient server = new TcpClient();
                        server.Connect(IPAddress.Loopback, 8081);
                        byte[] fileNameBytes_toserver = Encoding.UTF8.GetBytes(fileName);
                        byte[] fileNameBytes_toserver_Len = BitConverter.GetBytes(fileNameBytes_toserver.Length);
                        byte[] data2 = new byte[5 + fileNameBytes.Length];
                        data2[0] = 1;
                        Array.Copy(fileNameBytes_toserver_Len, 0, data2, 1, fileNameBytes_toserver_Len.Length);
                        Array.Copy(fileNameBytes_toserver, 0, data2, 5, fileNameBytes_toserver.Length);
                        using (NetworkStream stream_server_load = server.GetStream())
                        {
                            // Send the data to the server
                            stream_server_load.Write(data2, 0, data2.Length);
                            stream_server_load.Flush();

                            byte[] buffer = new byte[1024];
                            stream_server_load.Read(buffer, 0, buffer.Length);
                            string filecontent = Encoding.UTF8.GetString(buffer);

                            StreamWriter writer_load = new(stream);
                            // read the contents of the file and send them to the client
                            writer_load.WriteLine(filecontent);
                            writer_load.Flush ();

                            //Add cache and log
                            fileCache.Add(fileName, Encoding.UTF8.GetBytes(filecontent));
                            cacheLog = "";
                            string logEntry = string.Format("User request: file {0} at {1}", fileName, DateTime.Now.ToString());
                            cacheLog += logEntry;
                            logEntry = "\nResponse: file " + fileName + " downloaded from the server\n";
                            cacheLog += logEntry;

                            string pathload = Path.Combine(Directory.GetCurrentDirectory(), "../../../cache_data");
                            string logpath = Path.Combine(pathload, "cachelog.txt");

                            using (StreamWriter writerlog = new StreamWriter(logpath, true))
                            {
                                writerlog.WriteLine(cacheLog);
                            }

                            foreach (var file in fileCache)
                            {
                                string filePath = Path.Combine(path, file.Key);
                                File.WriteAllBytes(filePath, file.Value);
                            }

                            stream.Close();
                            stream_server_load.Close();
                            client.Close();
                        }
                        
                    }
                    
                }
            }
        }

    }
}

