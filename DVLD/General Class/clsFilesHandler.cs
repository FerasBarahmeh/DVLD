using System;
using System.IO;
using System.Security.Policy;
using System.Windows.Forms;

namespace DVLD.General_Class
{
    public static class clsFilesHandler
    {
        private static string ProjectFilesPath = "C:\\Container\\DVLD\\Images\\";

        public static bool CreateFolderIfNotExist(string path)
        {
            if (! File.Exists(path))
            {
                try
                {
                    Directory.CreateDirectory(path);
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error creating folder: " + ex.Message);
                    return false;
                }
            }
            return true;
        }
        
        public static string GenerateGUID()
        {
            return Guid.NewGuid().ToString();
        }

        public static string ReplaceFileNameWithGUID(string path)
        {
           FileInfo fileInfo = new FileInfo(path);
           string Extention = fileInfo.Extension;
            return GenerateGUID() + Extention;
        }


        public static bool CopyFileToProjectFilesFolder(ref string FilePath)
        {
            if (! CreateFolderIfNotExist(FilePath))
                return false;
            
            string Destination = ProjectFilesPath + ReplaceFileNameWithGUID(FilePath);
            
            try
            {
                File.Copy(FilePath, Destination, true);
            }
            catch (IOException e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            FilePath = Destination;


            return true;
        }

        public static bool DeleteFile(string PathFile)
        {
            try
            {
                File.Delete(PathFile);
            }
            catch (IOException e)
            {
                throw new IOException($"File Delete Error In File Handler {e.Message}", e);
            }
            return true;
        }
    }
}
