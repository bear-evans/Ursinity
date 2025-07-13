using System;
using System.IO;
using UnityEngine;

namespace TheBearDev.Ursinity.Runtime.Filesystem
{
    public static class FileHandler
    {
        /// <summary>
        /// Retrieves the list of file paths contained within the specified directory path.
        /// </summary>
        /// <param name="path">The directory path from which to retrieve the file paths.</param>
        /// <returns>Returns an array of file paths as strings, or null if an error occurs.</returns>
        public static string[] GetFilesInDirectory(string path)
        {
            try
            {
                return Directory.GetFiles(path);
            }
            catch (Exception e)
            {
                Debug.LogError(e);

                return null;
            }
        }

        /// <summary>
        /// Gets the full path by combining the application's persistent data path with the specified relative path.
        /// </summary>
        /// <param name="path">The relative path to be combined with the persistent data path.</param>
        /// <returns>Returns the full path as a string.</returns>
        public static string GetFilePath(string path)
        {
            return Path.Combine(Application.persistentDataPath, path);
        }

        /// <summary>
        /// Checks if a file exists at the specified path.
        /// </summary>
        /// <param name="path">The file path to check for existence.</param>
        /// <returns>Returns true if the file exists; otherwise, false.</returns>
        public static bool DoesFileExist(string path)
        {
            return File.Exists(path);
        }


        /// <summary>
        /// Deletes the file at the specified path.
        /// </summary>
        /// <param name="path">The file path of the file to delete.</param>
        public static void DeleteFile(string path)
        {
            try
            {
                File.Delete(path);
            }
            catch (Exception e)
            {
                Debug.LogError(e);
            }
        }

        /// <summary>
        /// Retrieves the file name and extension from the specified path.
        /// </summary>
        /// <param name="path">The full file path from which to extract the file name and extension.</param>
        /// <returns>Returns the file name and extension as a string, or null if an error occurs.</returns>
        public static string GetFileName(string path)
        {
            try
            {
                return Path.GetFileName(path);
            }
            catch (Exception e)
            {
                Debug.LogError(e);
            }

            return null;
        }

        /// <summary>
        /// Retrieves the size of the file at the specified path.
        /// </summary>
        /// <param name="path">The file path to determine the size of.</param>
        /// <returns>Returns the file size in bytes as a long value. Returns 0 if an error occurs.</returns>
        public static long GetFileSize(string path)
        {
            try
            {
                return new FileInfo(path).Length;
            }
            catch (Exception e)
            {
                Debug.LogError(e);
            }

            return 0;
        }


        /// <summary>
        /// Retrieves the last modified date and time of the file at the specified path.
        /// </summary>
        /// <param name="path">The file path to check the last modified time for.</param>
        /// <returns>Returns the last modified date and time as a DateTime object. Returns the default DateTime value if an error occurs.</returns>
        public static DateTime GetLastModified(string path)
        {
            try
            {
                return new FileInfo(path).LastWriteTime;
            }
            catch (Exception e)
            {
                Debug.LogError(e);
            }

            return default;
        }
    }
}