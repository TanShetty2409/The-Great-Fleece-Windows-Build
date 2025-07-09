using UnityEngine;

public class Eyes : MonoBehaviour
{
    public GameObject GameOverCutscene;
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameOverCutscene.SetActive(true);
        }
    }

}
