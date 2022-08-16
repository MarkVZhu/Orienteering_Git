using System.Collections;
using UnityEngine;

namespace Assets.Scripts.UI.MainMenu
{
    public class UIManager : MonoBehaviour
    {
        public GameObject[] menuUIList;  

        public void PageActivate(GameObject page)
        {
            if (!page.activeInHierarchy)
            {
                for(int i = 0;  i < menuUIList.Length; i++)
                {
                    if (!page.name.Equals(menuUIList[i].name))
                    {
                        //Deactivate other pages when it activates one page
                        menuUIList[i].SetActive(false);
                    }
                }
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