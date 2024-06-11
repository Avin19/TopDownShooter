using UnityEditor;
using static System.IO.Directory;
using static System.IO.Path;
using static UnityEngine.Application;
using static UnityEditor.AssetDatabase;
using UnityEditor.PackageManager;

using UnityEngine;
using UnityEditor.PackageManager.Requests;

namespace avinash
{
    /// <summary>
    ///  This is Editor Tool to  Create Default Folder Structure and Install Necessary packages 
    /// </summary>
    public static class Tools
    {
        [MenuItem("Tools/Setup/Create Default Folders")]
        public static void CreateDefaultFolders()
        {
            CreateDirectories("Project", "Scripts", "Materials", "Music", "Perfabs", "Models", "Texture", "Editor", "Fonts", "Sprites");
            Refresh();

        }
        public static void CreateDirectories(string root, params string[] dir)
        {
            string fullPath = Combine(dataPath, root);
            foreach (string newDir in dir)
            {
                CreateDirectory(Combine(fullPath, newDir));
            }
        }

        [MenuItem("Tools/Setup / Resolve Packages")]
        public static void Resolve()
        {
            Client.Resolve();


        }
        [MenuItem(" Tools/Setup /Add Remove Necessary Package  ")]
        public static void AddVisualStudioCode()
        {
            string[] apackages = { "com.unity.ide.visualstudio", "com.unity.textmeshpro" };
            string[] rpackages = { "com.unity.visualscripting", "com.unity.ide.rider", "com.unity.timeline" };
            Client.AddAndRemove(apackages, rpackages);

            Resolve();

        }



    }
}