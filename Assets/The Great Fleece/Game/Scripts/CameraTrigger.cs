using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    public Transform myCamera;
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Trigger Activated");
            Camera.main.transform.position = myCamera.transform.position;
            Camera.main.transform.rotation = myCamera.transform.rotation;
        }
    }

}
