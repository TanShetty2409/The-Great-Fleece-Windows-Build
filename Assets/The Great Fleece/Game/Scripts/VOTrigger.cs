using UnityEngine;

public class VOTrigger : MonoBehaviour
{
    public AudioClip _voiceOverClip;
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            AudioManager.Instance.PlayVoiceOver(_voiceOverClip);
        }
    }
}
