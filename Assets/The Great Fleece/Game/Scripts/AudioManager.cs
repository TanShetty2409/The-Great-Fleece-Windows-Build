using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager _instance;
    public static AudioManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.Log("AudioManager is null");
            }
            return _instance;
        }
    }
    public AudioSource voiceOver;
    private void Awake()
    {
        _instance = this;
    }
    public void PlayVoiceOver(AudioClip cliptoPlay)
    {
        voiceOver.clip = cliptoPlay;
        voiceOver.Play();
    }
}
