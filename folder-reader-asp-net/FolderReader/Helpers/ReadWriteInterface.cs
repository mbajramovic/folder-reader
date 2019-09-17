using System;
using System.Xml;
using System.Collections.Generic;
using FolderReader.Models;
using System.IO;

namespace FolderReader.Helpers
{
    public class ReadWriteInterface 
    {

        /// Function that writes path to folder that contains all other folders.
        /// Function has only one parameter - path (type String) to that folder.
        /// The path is saved in XML document - data.xml.
        public void writePath(String path) 
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load("data.xml");
            XmlNode xmlNode = xmlDocument.DocumentElement.SelectSingleNode("path");
            xmlNode.InnerText = path;
            xmlDocument.Save("data.xml");
        }

        /// Function that returns content of folder whose name is provided as parameter.
        public List<Content> getFolderContent(FolderNumber folderNumber) 
        {
            String path = getPath();
            if (path.Length == 0)
            {
                throw new Exception("Morate unijeti putanju do svih ostalih foldera.");
            }

            String folderName = "";
            try
            {
                folderName = getFolderName(path, folderNumber.FolderName);
            }
            catch (Exception ex)
            {
                throw new Exception("Definište ispravnu putanju (Administrator).");
            }

            if (folderName.Length == 0)
            {
                throw new Exception("Ne postoji folder koji odgovara unesenom broju.");
            }

            List<Content> contents = new List<Content>();
            contents = readFolder(folderName, contents);
            return contents;
        }

        /// Function that reads path to folder that contains all other folders.
        /// Function doen't have parameters.
        /// Function reads path from XML document - data.xml.
        public String getPath() {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load("data.xml");
            XmlNode xmlNode = xmlDocument.DocumentElement.SelectSingleNode("path");
            return xmlNode.InnerText;
        }

        /// Function that finds out the name of folder.
        /// Since the name of folder is provided like six-digit number, and since the folder names
        /// in directory can contains spaces (after three digits, in the example I have got from Nermin)
        // it is necessary to find out the correct name of folder, so there can be two cases:
        ///   1. the name of folder doens't containt any space
        ///   2. the name ofg folder contains space after three digits
        /// Of course, it is possible to add some other cases in provided if.
        /// Function has two params - path to folder that contains all other folders and the
        /// six-digit folder number.
        private String getFolderName(String path, String folderNumber) 
        {
            try
            {
                String[] directories = Directory.GetDirectories(path);
                foreach (String directory in directories)
                {
                    if (directory == folderNumber || 
                        directory.Contains(folderNumber.Substring(0, 3) + ' ' + folderNumber.Substring(3, 3)))
                    {
                        return directory;
                    }
                }
            }
            catch (Exception ex)
            {
               throw ex;
            }
            return "";
        }

        /// Function that reads the target directory recursively.
        private List<Content> readFolder(String targetDirectory, List<Content> contents) {

            String[] files = Directory.GetFiles(targetDirectory);
            foreach(String file in files)
            {
                contents.Add(new Content(targetDirectory, file.Substring(targetDirectory.Length + 1, file.Length - 1 - targetDirectory.Length)));
            }

            String[] directories = Directory.GetDirectories(targetDirectory);
            foreach(String directory in directories) 
            {
                readFolder(directory, contents);
            }
            return contents;
        }
    }
}
