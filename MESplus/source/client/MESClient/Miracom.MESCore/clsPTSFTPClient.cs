//Author             : Mohammed Habeeb - habeeb_matrix@hotmail.com  
//Date Created       : 17th January 2007 
//Description        : This class demonstartes common FTP functionalities using .net 2.0.
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;

using Miracom.CliFrx;

namespace Miracom.MESCore
{
    public sealed class PTSFTPClient
    {
        private string ftpServerIP, ftpUserID, ftpPassword;

        public string FtpPassword
        {
            get { return ftpPassword; }
            set { ftpPassword = value; }
        }

        public string FtpUserID
        {
            get { return ftpUserID; }
            set { ftpUserID = value; }
        }

        public string FtpServerIP
        {
            get { return ftpServerIP; }
            set { ftpServerIP = value; }
        }

        public PTSFTPClient() : this(string.Empty, string.Empty, string.Empty) { }

        public PTSFTPClient(string ServerIP, string UserID, string Password)
        {
            this.ftpServerIP = ServerIP;
            this.ftpUserID = UserID;
            this.ftpPassword = Password;
        }

        /// <summary>
        /// Method to upload the specified file to the specified FTP Server
        /// </summary>
        /// <param name="filename">file full name to be uploaded</param>
        private bool Upload(string filename)
        {
            FileInfo fileInf = new FileInfo(filename);
            string uri = "ftp://" + ftpServerIP + "/" + fileInf.Name;
            FtpWebRequest reqFTP;

            // Create FtpWebRequest object from the Uri provided
            reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(uri));

            // Provide the WebPermission Credintials
            reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);

            // By default KeepAlive is true, where the control connection is not closed
            // after a command is executed.
            reqFTP.KeepAlive = false;

            // Specify the command to be executed.
            reqFTP.Method = WebRequestMethods.Ftp.UploadFile;

            // Specify the data transfer type.
            reqFTP.UseBinary = true;

            // Notify the server about the size of the uploaded file
            reqFTP.ContentLength = fileInf.Length;

            // The buffer size is set to 2kb
            int buffLength = 2048;
            byte[] buff = new byte[buffLength];
            int contentLen;

            // Opens a file stream (System.IO.FileStream) to read the file to be uploaded
            FileStream fs = fileInf.OpenRead();

            try
            {
                // Stream to which the file to be upload is written
                Stream strm = reqFTP.GetRequestStream();

                // Read from the file stream 2kb at a time
                contentLen = fs.Read(buff, 0, buffLength);

                // Till Stream content ends
                while (contentLen != 0)
                {
                    // Write Content from the file stream to the FTP Upload Stream
                    strm.Write(buff, 0, contentLen);
                    contentLen = fs.Read(buff, 0, buffLength);
                }

                // Close the file stream and the Request Stream
                strm.Close();
                fs.Close();
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message + "[ Upload Error ]");
                return false;
            }
            return true;
        }

        public void DeleteFTP(string fileName)
        {
            try
            {
                string uri = "ftp://" + ftpServerIP + "/" + fileName;
                FtpWebRequest reqFTP;
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(uri));

                reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                reqFTP.KeepAlive = false;
                reqFTP.Method = WebRequestMethods.Ftp.DeleteFile;

                string result = String.Empty;
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                long size = response.ContentLength;
                Stream datastream = response.GetResponseStream();
                StreamReader sr = new StreamReader(datastream);
                result = sr.ReadToEnd();
                sr.Close();
                datastream.Close();
                response.Close();
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message + "[ FTP Delete ]");
            }
        }

        private string[] GetFilesDetailList()
        {
            string[] downloadFiles;
            try
            {
                StringBuilder result = new StringBuilder();
                FtpWebRequest ftp;
                ftp = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + ftpServerIP + "/"));
                ftp.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                ftp.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
                WebResponse response = ftp.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                string line = reader.ReadLine();
                while (line != null)
                {
                    result.Append(line);
                    result.Append("\n");
                    line = reader.ReadLine();
                }

                //result.Remove(result.ToString().LastIndexOf("\n"), 1);
                reader.Close();
                response.Close();
                return result.ToString().Split('\n');
                //MessageBox.Show(result.ToString().Split('\n'));
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                downloadFiles = null;
                return downloadFiles;
            }
        }

        public string[] GetFileList()
        {
            string[] downloadFiles;
            StringBuilder result = new StringBuilder();
            FtpWebRequest reqFTP;
            try
            {
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + ftpServerIP + "/"));
                reqFTP.UseBinary = true;
                reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                reqFTP.Method = WebRequestMethods.Ftp.ListDirectory;
                WebResponse response = reqFTP.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                //MessageBox.Show(reader.ReadToEnd());
                string line = reader.ReadLine();
                while (line != null)
                {
                    result.Append(line);
                    result.Append("\n");
                    line = reader.ReadLine();
                }
                result.Remove(result.ToString().LastIndexOf('\n'), 1);
                reader.Close();
                response.Close();
                //MessageBox.Show(response.StatusDescription);
                return result.ToString().Split('\n');
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                downloadFiles = null;
                return downloadFiles;
            }
        }

        private void Download(string filePath, string fileName)
        {
            FtpWebRequest reqFTP;
            try
            {
                //filePath = <<The full path where the file is to be created.>>, 
                //fileName = <<Name of the file to be created(Need not be the name of the file on FTP server).>>
                FileStream outputStream = new FileStream(filePath + "\\" + fileName, FileMode.Create);

                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + ftpServerIP + "/" + fileName));
                reqFTP.Method = WebRequestMethods.Ftp.DownloadFile;
                reqFTP.UseBinary = true;
                reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                Stream ftpStream = response.GetResponseStream();

                long cl = response.ContentLength;
                int bufferSize = 2048;
                int readCount; //FileStream 할당
                byte[] buffer = new byte[bufferSize];

                readCount = ftpStream.Read(buffer, 0, bufferSize); //버퍼,읽는 위치 0번째부터, 한번에 읽을 데이터량 2KB.
                while (readCount > 0)
                {
                    outputStream.Write(buffer, 0, readCount); //파일스트림에 버퍼 데이터를 이용하여 쓴다.
                    readCount = ftpStream.Read(buffer, 0, bufferSize);
                }

                ftpStream.Close();
                outputStream.Close();
                response.Close();
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        //Modify private to public by Kelly Jung
        public long GetFileSize(string filename)
        {
            FtpWebRequest reqFTP;
            long fileSize = 0;
            try
            {
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + ftpServerIP + "/" + filename));
                reqFTP.Method = WebRequestMethods.Ftp.GetFileSize;
                reqFTP.UseBinary = true;
                reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                Stream ftpStream = response.GetResponseStream();
                fileSize = response.ContentLength;

                ftpStream.Close();
                response.Close();
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            return fileSize;
        }

        private void Rename(string currentFilename, string newFilename)
        {
            FtpWebRequest reqFTP;
            try
            {
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + ftpServerIP + "/" + currentFilename));
                reqFTP.Method = WebRequestMethods.Ftp.Rename;
                reqFTP.RenameTo = newFilename;
                reqFTP.UseBinary = true;
                reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                Stream ftpStream = response.GetResponseStream();

                ftpStream.Close();
                response.Close();
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void MakeDir(string dirName)
        {
            FtpWebRequest reqFTP;
            try
            {
                // dirName = name of the directory to create.
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + ftpServerIP + "/" + dirName));
                reqFTP.Method = WebRequestMethods.Ftp.MakeDirectory;
                reqFTP.UseBinary = true;
                reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                Stream ftpStream = response.GetResponseStream();

                ftpStream.Close();
                response.Close();
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        public bool UpLoadFile(string fn)
        {
            return Upload(fn);
        }
        public void DownLoadFile(string filePath, string fn)
        {
            Download(filePath, fn);
        }
        public string[] FileList()
        {
            return GetFileList();
        }
        public void DeleteFile(string fn)
        {
            DeleteFTP(fn);
        }
        public string[] FilesDetailList()
        {
            return GetFilesDetailList();
        }

        /// <summary>
        /// Method to upload the specified file to the specified FTP Server
        /// </summary>
        /// <param name="filename">file full name to be uploaded</param>
        public bool Upload(string source_path, string dest_path)
        {
            FileInfo fileInf = new FileInfo(source_path);
            string uri = dest_path;
            FtpWebRequest reqFTP;

            // Create FtpWebRequest object from the Uri provided
            reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(uri));

            // Provide the WebPermission Credintials
            reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);

            // By default KeepAlive is true, where the control connection is not closed
            // after a command is executed.
            reqFTP.KeepAlive = false;

            // Specify the command to be executed.
            reqFTP.Method = WebRequestMethods.Ftp.UploadFile;

            // Specify the data transfer type.
            reqFTP.UseBinary = true;

            // Notify the server about the size of the uploaded file
            reqFTP.ContentLength = fileInf.Length;

            // The buffer size is set to 2kb
            int buffLength = 2048;
            byte[] buff = new byte[buffLength];
            int contentLen;

            // Opens a file stream (System.IO.FileStream) to read the file to be uploaded
            FileStream fs = fileInf.OpenRead();

            try
            {
                // Stream to which the file to be upload is written
                Stream strm = reqFTP.GetRequestStream();

                // Read from the file stream 2kb at a time
                contentLen = fs.Read(buff, 0, buffLength);

                // Till Stream content ends
                while (contentLen != 0)
                {
                    // Write Content from the file stream to the FTP Upload Stream
                    strm.Write(buff, 0, contentLen);
                    contentLen = fs.Read(buff, 0, buffLength);
                }

                // Close the file stream and the Request Stream
                strm.Close();
                fs.Close();
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message + "[ Upload Error ]");
                return false;
            }
            return true;
        }
        public void DownLoad(string remote_path, string download_path)
        {
            FtpWebRequest reqFTP;
            try
            {
                //filePath = <<The full path where the file is to be created.>>, 
                //fileName = <<Name of the file to be created(Need not be the name of the file on FTP server).>>
                FileStream outputStream = new FileStream(download_path, FileMode.CreateNew);

                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(remote_path));
                reqFTP.Method = WebRequestMethods.Ftp.DownloadFile;
                reqFTP.UseBinary = true;
                reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                Stream ftpStream = response.GetResponseStream();

                long cl = response.ContentLength;
                int bufferSize = 2048;
                int readCount; //FileStream 할당
                byte[] buffer = new byte[bufferSize];

                readCount = ftpStream.Read(buffer, 0, bufferSize); //버퍼,읽는 위치 0번째부터, 한번에 읽을 데이터량 2KB.
                while (readCount > 0)
                {
                    outputStream.Write(buffer, 0, readCount); //파일스트림에 버퍼 데이터를 이용하여 쓴다.
                    readCount = ftpStream.Read(buffer, 0, bufferSize);
                }

                ftpStream.Close();
                outputStream.Close();
                response.Close();
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
        public void Open(string remote_path, string download_path)
        {
            FtpWebRequest reqFTP;
            try
            {
                //filePath = <<The full path where the file is to be created.>>, 
                //fileName = <<Name of the file to be created(Need not be the name of the file on FTP server).>>

                System.IO.MemoryStream outputStream = new MemoryStream();
                //FileStream outputStream = new FileStream(download_path, FileMode.Open);

                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(remote_path));
                reqFTP.Method = WebRequestMethods.Ftp.DownloadFile;
                reqFTP.UseBinary = true;
                reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                Stream ftpStream = response.GetResponseStream();

                long cl = response.ContentLength;
                int bufferSize = 2048;
                int readCount; //FileStream 할당
                byte[] buffer = new byte[bufferSize];

                readCount = ftpStream.Read(buffer, 0, bufferSize); //버퍼,읽는 위치 0번째부터, 한번에 읽을 데이터량 2KB.
                while (readCount > 0)
                {
                    outputStream.Write(buffer, 0, readCount); //파일스트림에 버퍼 데이터를 이용하여 쓴다.
                    readCount = ftpStream.Read(buffer, 0, bufferSize);
                }

                ftpStream.Close();
                outputStream.Close();
                response.Close();
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
        public void Delete(string file_path)
        {
            try
            {
                string uri = file_path;
                FtpWebRequest reqFTP;
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(uri));

                reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                reqFTP.KeepAlive = false;
                reqFTP.Method = WebRequestMethods.Ftp.DeleteFile;

                string result = String.Empty;
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                long size = response.ContentLength;
                Stream datastream = response.GetResponseStream();
                StreamReader sr = new StreamReader(datastream);
                result = sr.ReadToEnd();
                sr.Close();
                datastream.Close();
                response.Close();
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message + "[ FTP Delete ]");
            }
        }

    }
}
