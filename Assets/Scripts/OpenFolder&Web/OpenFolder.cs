
using System.IO;
using UnityEngine;
public class OpenFolder : MonoBehaviour
{
    public void OpenDirectory(GameObject prompt)
    {
        bool isFile = false;
        string path = Application.dataPath + "/Resources/image/maps";
        if (string.IsNullOrEmpty(path)) return;
        path = path.Replace("/", "\\");
        if (isFile)
        {
            if (!File.Exists(path))
            {
                Debug.LogError("No File: " + path);
                return;
            }
            path = string.Format("/Select, {0}", path);
        }
        else
        {
            if (!Directory.Exists(path))
            {
                Debug.LogError("No Directory: " + path);
                return;
            }
        }
        if (!prompt.activeInHierarchy)
        {
            System.Diagnostics.Process.Start("explorer.exe", path);
            prompt.SetActive(true);
        }
    }
}