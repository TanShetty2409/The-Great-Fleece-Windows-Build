using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;
    public static UIManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.Log("UIManager is null");
            }
            return _instance;
        }
    }
    private void Awake()
    {
        _instance = this;
    }
    public void Restart()
    {
        SceneManager.LoadScene("Main");
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void QuitToMainMenu()
    {
        SceneManager.LoadScene("Main_Menu");
    }
}
