using UnityEngine;

public class WinLevelCutsceneTrigger : MonoBehaviour
{
    public GameObject cutscene;
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {   Debug.Log("Checking hasCard: " + GameManager.Instance.hasCard);
            if (GameManager.Instance.hasCard == true)
            {
                cutscene.SetActive(true);
            }
            else Debug.Log("Get key card to enter");
        }

    }
}
