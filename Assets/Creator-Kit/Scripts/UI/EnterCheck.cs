using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterCheck : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene(2);
        }
    }
}
