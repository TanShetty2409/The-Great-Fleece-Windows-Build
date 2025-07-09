using System;
using System.Collections;
using UnityEngine;

public class GetCardCutsceneTrigger : MonoBehaviour
{
    public GameObject getCardcutscene;
    public GameObject camera_5;
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            getCardcutscene.SetActive(true);
            StartCoroutine(disableCutscene());
            GameManager.Instance.hasCard = true;
            Debug.Log("Setting hasCard = true | GameManager is " + GameManager.Instance);
        }
    }
    IEnumerator disableCutscene()
    {
        yield return new WaitForSeconds(5.5f);
        Camera.main.transform.position = camera_5.transform.position;
        Camera.main.transform.rotation = camera_5.transform.rotation;
        getCardcutscene.SetActive(false);
    }
}
