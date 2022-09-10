
using System.IO;
using UnityEngine;
public class OpenWeb : MonoBehaviour
{
    public void OpenUrl(string url)
    {
        Application.OpenURL(url);
    }
}