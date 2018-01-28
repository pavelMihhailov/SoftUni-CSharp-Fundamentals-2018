﻿using System;
using System.Collections.Generic;
using System.IO;

public static class IOManager
{
    public static void TraverseDirectory(int depth)
    {
        OutputWriter.WriteEmptyLine();
        int initialIdentation = SessionData.currentPath.Split('\\').Length;
        var subFolders = new Queue<string>();
        subFolders.Enqueue(SessionData.currentPath);

        while (subFolders.Count > 0)
        {
            var currentPath = subFolders.Dequeue();
            int identation = currentPath.Split('\\').Length;
            OutputWriter.WriteMessageonNewLine(string.Format("{0}{1}", new string('-', identation), currentPath));

            try
            {
                foreach (var file in Directory.GetFiles(currentPath))
                {
                    int indexOfLastSlash = file.LastIndexOf('\\');
                    string fileName = file.Substring(indexOfLastSlash);
                    OutputWriter.WriteMessageonNewLine(new string('-', indexOfLastSlash) + fileName);
                }

                foreach (string directoryPath in Directory.GetDirectories(currentPath))
                {
                    subFolders.Enqueue(directoryPath);
                }
            }
            catch (UnauthorizedAccessException)
            {
                OutputWriter.DisplayException(ExceptionMessages.UnauthorizedAccessExceptionMessage);
            }

            if (depth - identation < 0)
            {
                break;
            }
        }
    }

    public static void CreateDirectoryInCurrentFolder(string name)
    {
        string path = Directory.GetCurrentDirectory() + "\\" + name;
        try
        {
            Directory.CreateDirectory(path);
        }
        catch (ArgumentException)
        {
            OutputWriter.DisplayException(ExceptionMessages.ForbiddenSymbolsContainedInName);
        }
    }

    public static void ChangeCurrentDirectoryRelative(string relativePath)
    {
        if (relativePath.Equals(".."))
        {
            try
            {
                string currentPath = SessionData.currentPath;
                int indexOfLastSlash = currentPath.LastIndexOf('\\');
                string newPath = currentPath.Substring(0, indexOfLastSlash);
                SessionData.currentPath = newPath;
            }
            catch (ArgumentOutOfRangeException)
            {
                OutputWriter.DisplayException(ExceptionMessages.UnableToGoHigherInPartitionHierarchy);
            }
        }

        else
        {
            string currentPath = SessionData.currentPath;
            currentPath += "\\" + relativePath;
            ChangeCurrentDirectoryAbsolute(currentPath);
        }
    }

    public static void ChangeCurrentDirectoryAbsolute(string absolutePath)
    {
        if (!Directory.Exists(absolutePath))
        {
            OutputWriter.DisplayException(ExceptionMessages.InvalidPath);
            return;
        }

        SessionData.currentPath = absolutePath;
    }
}
