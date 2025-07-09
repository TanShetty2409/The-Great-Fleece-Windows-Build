using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour
{
    public void StartScene()
    {
        SceneManager.LoadScene("Loading_Scene");
    }
    public void Quit()
    {
        Application.Quit();   
    }
}
