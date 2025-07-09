using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.Log("GameManager is null");
            }
            return _instance;
        }
    }
    public bool hasCard { get; set; }
    public bool animPlaying { get; set; }
    private void Awake()
    {
        _instance = this;
    }
}
