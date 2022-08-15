using System.Collections;
using UnityEngine;

namespace Assets.Scripts.UI.MainMenu
{
    public class UIManager : MonoBehaviour
    {

        public void PageActivate(GameObject page)
        {
            if (!page.activeInHierarchy)
            {
                page.SetActive(true);
            }
        }

        public void Pagedeactivate(GameObject page)
        {
            if (page.activeInHierarchy)
            {
                page.SetActive(false);
            }
        }
        public void LoadLevelByBuildInNumber(GameObject page)
        {
            int LevelNum = page.name[page.name.Length - 1] - '0';
            // Button cannot call function which returns IEnumerator
            LoadManager.Instance.LoadLevelExWithLoadPageButton(LevelNum, page); 
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}