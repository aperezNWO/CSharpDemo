using System;
using System.ComponentModel;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace _4_DataAccess
{
    // Skill 4.1 - Performing I/O Operations
    public class Skill_4_1_INPUT_OPTUPUT_OPS
    {
        //
        internal static void FileStreamTest()
        {
            //
            Console.WriteLine("Using FileStream");
            //
            try
            {
                // Writing to a File
                string filePath = @"OutputText_01.txt";
                using (FileStream outputStream = new FileStream
                    (
                        filePath,
                        FileMode.OpenOrCreate,
                        FileAccess.Write
                    ))
                {
                    //
                    Console.WriteLine("Creating the file {0}", filePath);
                    //
                    string outputMessageString = "Hello, World";
                    byte[] outputMessageBytes = Encoding.UTF8.GetBytes(outputMessageString);
                    outputStream.Write(outputMessageBytes, 0, outputMessageBytes.Length);
                    outputStream.Close();
                };

                // Read From File
                using (FileStream inputStream = new FileStream
                    (
                         filePath
                        , FileMode.OpenOrCreate
                        , FileAccess.Read
                    ))
                {
                    //
                    long fileLength  = inputStream.Length;
                    byte[] readBytes = new byte[fileLength];
                    inputStream.Read(readBytes, 0, (int)fileLength);
                    string readString = Encoding.UTF8.GetString(readBytes);
                    inputStream.Close();
                    //
                    Console.WriteLine("Read Message : {0}", readString);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR : {0}", ex.Message + " " + ex.StackTrace);
            }
        }
        //
        internal static void StreamReaderWriterTest()
        {
            //
            Console.WriteLine("Working with text files");
            //
            try
            {
                //
                string filePath = @"OutputText_02.txt";
                string message = "Hello,World";
                //
                using (StreamWriter writeStream = new StreamWriter(filePath))
                {
                    //
                    writeStream.Write(message);
                    //
                    Console.WriteLine("Writing to File : '{0}', Content : '{1}'", filePath, message);
                }
                //
                using (StreamReader readStream = new StreamReader(filePath))
                {
                    //
                    string readString = readStream.ReadToEnd();
                    //
                    Console.WriteLine("Reading from File {0}, Text Read : {1}", filePath, readString);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR : {0}", ex.Message + " " + ex.StackTrace);
            }
        }
        //
        internal static void GZipTest()
        {
            //
            Console.WriteLine("Chain Streams Together");
            //
            try
            {
                //
                string filePath = @"CompText_01.zip";
                string inputMessage = "Hello, World\n";
                int FILE_SIZE = 2000;
                //
                using (FileStream writeFile = new FileStream(
                             filePath
                            , FileMode.OpenOrCreate
                            , FileAccess.Write
                        ))
                {
                    //
                    using (GZipStream writeFileZip = new GZipStream(
                                 writeFile
                                , CompressionMode.Compress
                            ))
                    {
                        //
                        using (StreamWriter writeFileText = new StreamWriter
                            (
                                writeFileZip
                            ))
                        {
                            //
                            for (int i = 1; i < FILE_SIZE; i++)
                            {
                                writeFileText.Write(inputMessage);
                            }
                            //
                            Console.WriteLine("Writing Text : '{0}', to zip File {1} ", inputMessage, filePath);
                        }
                    }
                }
                //
                using (FileStream readFile = new FileStream(
                        filePath
                        , FileMode.Open
                        , FileAccess.Read
                    ))
                {
                    //
                    using (GZipStream readFileZip = new GZipStream
                        (
                             readFile
                            , CompressionMode.Decompress
                        ))
                    {
                        //
                        string outputMessage = string.Empty;
                        using (StreamReader readFileText = new StreamReader
                            (
                                readFileZip
                            ))
                        {
                            outputMessage = readFileText.ReadToEnd();
                        }
                        //
                        Console.WriteLine("Reading Text Size : '{0}', from zip File {1} ", outputMessage.Length, filePath);
                    }
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR : {0}", ex.Message + " " + ex.StackTrace);
            }
        }
        //
        internal static void FileClassTest()
        {
            //
            Console.WriteLine("Use the File Class / Handle Stream Exception");
            //
            try
            {
                //
                string filePath = @"TextFile01.txt";
                string fileContentStart = @"- This text goes in the file." + System.Environment.NewLine;
                string fileContentEnd = @"- This goes on the end." + System.Environment.NewLine;
                //
                File.WriteAllText(path: filePath, contents: fileContentStart);
                //
                File.AppendAllText(path: filePath, contents: fileContentEnd);
                //
                if (File.Exists(filePath))
                {
                    Console.WriteLine("-File Created : '{0}'.", filePath);
                }
                //
                string contents = File.ReadAllText(path: filePath);
                Console.WriteLine("-File Read : '{0}'. Contents : '{1}'.", filePath, contents);
                //
                string filePathCopy = @"TextFile02.txt";
                File.Copy(sourceFileName: (filePath), destFileName: filePathCopy, overwrite: true);
                Console.WriteLine("Copying file from {0} to {1}", filePath, filePathCopy);
                //
                using (TextReader reader = File.OpenText(path: filePathCopy))
                {
                    string text = reader.ReadToEnd();
                    Console.WriteLine("Copied content : '{0}'", text);
                }
            }
            catch (FileNotFoundException ioException)
            {
                Console.WriteLine("ERROR : '{0}'", ioException.Message + " " + ioException.StackTrace);
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR : '{0}'", (ex.Message + " " + ex.StackTrace));
            }
        }
        //
        internal static void DriveInfoTest()
        {
            //
            Console.Write("System Drive Info");
            //
            try
            {
                DriveInfo[] drives = DriveInfo.GetDrives();
                foreach (DriveInfo drive in drives)
                {
                    Console.WriteLine("Name : {0}", drive.Name);
                    if (drive.IsReady)
                    {
                        Console.WriteLine(" Type        : {0} ", drive.DriveType);
                        Console.WriteLine(" Label       : {0} ", drive.VolumeLabel);
                        Console.WriteLine(" Format      : {0} ", drive.DriveFormat);
                        Console.WriteLine(" Total Space : {0} ", drive.TotalSize);
                        Console.WriteLine(" Free Space  : {0} ", drive.TotalFreeSpace);
                    }
                    else
                    {
                        Console.WriteLine("Drive Not Ready");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR : '{0}'", (ex.Message + " " + ex.StackTrace));
            }
            //
        }
        //
        internal static void FileInfoTest()
        {
            //
            Console.WriteLine("Using File Info - [Listing 4.8]");
            //
            try
            {
                //
                string filePath = "TextFile.txt";
                File.WriteAllText(path: filePath, contents: "This text goes in the file");
                FileInfo info = new FileInfo(filePath);

                //
                Console.WriteLine("Name         : {0}", info.Name);
                Console.WriteLine("Full Path    : {0}", info.FullName);
                Console.WriteLine("Last Access  : {0}", info.LastAccessTime);
                Console.WriteLine("Length       : {0}", info.Length);
                Console.WriteLine("Attributes   : {0}", info.Attributes);

                //
                Console.WriteLine("Make the file read only");
                info.Attributes |= FileAttributes.ReadOnly;
                Console.WriteLine("Attributes: {0}", info.Attributes);

                //
                Console.WriteLine("Remove the read only attribute");
                info.Attributes &= ~FileAttributes.ReadOnly;
                Console.WriteLine("Attributes: {0}", info.Attributes);

                //
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR : '{0}'", (ex.Message + " " + ex.StackTrace));
            }

        }
        //
        internal static void DirectoryInfoTest()
        {
            //
            Console.WriteLine("Using Directory/DirectoryInfo Classes - [Listing 4.9/4.10]");
            //
            try
            {
                string directoryName = @"TestDir";

                //----------------------------------------------------------
                //
                Console.WriteLine("4.9 Directory Class");
                //
                Directory.CreateDirectory(directoryName);
                //
                if (Directory.Exists(directoryName))
                    Console.WriteLine("Directory created successfully : '{0}'", directoryName);
                //
                Directory.Delete(directoryName);
                //
                Console.WriteLine("Directory deleted successfully");

                //----------------------------------------------------------
                //
                Console.WriteLine("4.10 DirectoryInfo Class");
                //
                DirectoryInfo localDir = new DirectoryInfo(directoryName);
                localDir.Create();
                //
                if (localDir.Exists)
                    Console.WriteLine("Directory created successfully : '{0}'", localDir.Name);
                localDir.Delete();
                //
                Console.WriteLine("Directory deleted successfully");
                //
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR : '{0}'", (ex.Message + " " + ex.StackTrace));
            }
        }
        //
        internal static void FilePathTest()
        {
            //
            Console.WriteLine("Files and Paths - [Listing 4.11]");
            //
            try
            {
                //
                string fullName = @"D:\Usuarios\Alejandro\dev\Exam70483\repo\4_DataAccess\Output\test.txt";
                string dirName = Path.GetDirectoryName(fullName);
                string fileName = Path.GetFileName(fullName);
                string fileExtension = Path.GetExtension(fullName);
                string lisName = Path.ChangeExtension(fullName, ".lis");
                string newTest = Path.Combine(dirName, "newtest.txt");

                //
                Console.WriteLine("Full name               : {0}", fullName);
                Console.WriteLine("File directory          : {0}", dirName);
                Console.WriteLine("File name               : {0}", fileName);
                Console.WriteLine("File extension          : {0}", fileExtension);
                Console.WriteLine("File with lis extension : {0}", lisName);
                Console.WriteLine("New test                : {0}", newTest);

                //
                for (int fileItem = 0; fileItem < 10; fileItem++)
                {
                    string result = Path.GetRandomFileName();
                    Console.WriteLine("Random file name is     : {0} ", result);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR : '{0}'", (ex.Message + " " + ex.StackTrace));
            }
        }
        //        
        static void FindFiles(DirectoryInfo dir, string searchPattern)
        {
            foreach (DirectoryInfo directory in dir.GetDirectories())
            {
                FindFiles(directory, searchPattern);
            }
            FileInfo[] matchingFiles = dir.GetFiles(searchPattern);
            foreach (FileInfo fileInfo in matchingFiles)
            {
                Console.WriteLine(fileInfo.FullName);
            }
        }
        internal static void SearchFilesTest()
        {
            //
            Console.WriteLine("Searching for Files - [Listing 4.12]");
            //
            try
            {
                DirectoryInfo startDir = new DirectoryInfo(@"..\..\..\..");
                string searchString = "*.cs";
                FindFiles(startDir, searchString);
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR : '{0}'", (ex.Message + " " + ex.StackTrace));
            }
        }
        //
        internal static void WebRequestTest()
        {
            //
            Console.WriteLine("Web Request - [Listing 4.13]");
            //
            try
            {
                //
                string uri = @"https://www.microsoft.com";
                string directoryPath = @"..\..\";
                DirectoryInfo startDir = new DirectoryInfo(directoryPath);
                string filePath = Path.Combine(startDir.FullName, @"output\microsoft.html");

                //
                Console.WriteLine("Reading content from URL : {0}", uri);
                Console.WriteLine("Reading content to path  : {0}", startDir.FullName);


                WebRequest webRequest = WebRequest.Create(uri);
                WebResponse webResponse = webRequest.GetResponse();
                //
                using (StreamReader responseReader = new StreamReader(webResponse.GetResponseStream()))
                {
                    string siteText = responseReader.ReadToEnd();
                    File.WriteAllText(filePath, siteText);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR : '{0}'", (ex.Message + " " + ex.StackTrace));
            }
        }
        //
        public static string ReadWebPage(string p_uri, string p_filePath)
        {
            //
            Console.WriteLine("Reading Synchronous content from uri : {0} ", p_uri);
            //
            string siteText = string.Empty;
            //
            using (WebClient client = new WebClient())
            {
                siteText = client.DownloadString(p_uri);
            }
            // 
            return siteText;
        }
        //
        internal static async Task<string> ReadWebPageAsync_1(string p_uri)
        {
            //
            Console.WriteLine("Reading Asynchronous content from uri : {0} ", p_uri);
            //
            string siteText = string.Empty;
            //
            using (WebClient client = new WebClient())
            {
                siteText = await client.DownloadStringTaskAsync(p_uri);
            }
            // 
            return siteText;
        }
        //
        public static async Task<string> ReadWebPageAsync_2(string p_uri)
        {
            //
            Console.WriteLine("Reading Asynchronous content from uri : {0} ", p_uri);
            //
            string siteText = string.Empty;
            //
            using (HttpClient client = new HttpClient())
            {
                siteText = await client.GetStringAsync(p_uri);
            }
            // 
            return siteText;
        }
        public static string GetFilePath(string p_corporationName, out string p_uri)
        {
            p_uri = string.Format(@"https://www.{0}.com", p_corporationName);
            string directoryPath = @"..\..\";
            DirectoryInfo startDir = new DirectoryInfo(directoryPath);
            string filePath = Path.Combine(startDir.FullName, string.Format(@"output\{0}.html", p_corporationName));

            return filePath;
        }
        internal static async Task WebClientTestAsync()
        {
            try
            {
                //
                Console.WriteLine("Web Client /Async  - [Listing 4.14/4.15]");
                //
                string corporationName = string.Empty;
                string filePath = string.Empty;
                string siteText = string.Empty;
                string uri = string.Empty;

                //
                corporationName = @"IBM";
                filePath = GetFilePath(corporationName, out uri);
                siteText = ReadWebPage(
                                                      p_uri: uri
                                                    , p_filePath: filePath
                                                    );
                File.WriteAllText(path: filePath, contents: siteText);

                //
                corporationName = @"oracle";
                filePath = GetFilePath(corporationName, out uri);
                siteText = await ReadWebPageAsync_1(p_uri: uri);
                File.WriteAllText(path: filePath, contents: siteText);
                //
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR : '{0}'", (ex.Message + " " + ex.StackTrace));
            }
        }
        //
        public static async Task HttpClientTest()
        {
            try
            {
                //
                Console.WriteLine("HttpClient/Async  - [Listing 4.16]");
                //
                string corporationName = string.Empty;
                string filePath        = string.Empty;
                string siteText        = string.Empty;
                string uri             = string.Empty;
                //
                corporationName  = @"google";
                filePath         = Skill_4_1_INPUT_OPTUPUT_OPS.GetFilePath(corporationName, out uri);
                siteText         = await Skill_4_1_INPUT_OPTUPUT_OPS.ReadWebPageAsync_2(p_uri: uri);
                File.WriteAllText(path: filePath, contents: siteText);
                //
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR : '{0}'", (ex.Message + " " + ex.StackTrace));
            }
        }
        //
        internal static async Task WriteBytesAsync(string filename, byte[] items)
        {
            //
            Console.WriteLine("Wriing content Asynchronously to file : {0} ", filename);
            //
            using (FileStream outStream = new FileStream(filename, FileMode.OpenOrCreate,
            FileAccess.Write))
            {
                await outStream.WriteAsync(items, 0, items.Length);
            }
        }
        //
        public static async Task FileAsyncTest()
        {
            try
            {
                //
                Console.WriteLine("File/Async  - [Listing 4.17]");
                //
                string corporationName = string.Empty;
                string filePath        = string.Empty;
                string uri             = string.Empty;
                int fileLength         = 1000;
                //
                byte[] data           = new byte[fileLength];
                for (int bytePosition = 0; bytePosition < fileLength; bytePosition++)
                {
                    data[bytePosition] =  Byte.Parse("1");
                }
                //
                corporationName = @"facebook";
                filePath        = Skill_4_1_INPUT_OPTUPUT_OPS.GetFilePath(corporationName, out uri);
                await WriteBytesAsync(filePath, data);
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR : '{0}'", (ex.Message + " " + ex.StackTrace));
            }
        }
    }
}
