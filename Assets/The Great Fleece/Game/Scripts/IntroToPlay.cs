using System.Collections;
using UnityEngine;
using UnityEngine.Playables;

public class IntroToPlay : MonoBehaviour
{
    public GameObject introCutscene;
    public PlayableDirector director;

    public GameObject camera_1pos;
    public GameObject player;
    private bool hasPlayed = false;

    void Start()
    {
        GameManager.Instance.animPlaying = true;
        director.stopped += OnCutsceneEnd;

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            director.time = 59.0f;
        }
    }
    void OnCutsceneEnd(PlayableDirector pd)
    {
        if (!hasPlayed)
        {
            hasPlayed = true;
            GameManager.Instance.animPlaying = false;
            foreach (var cam in FindObjectsByType<Unity.Cinemachine.CinemachineCamera>(FindObjectsSortMode.None))
            {
                cam.gameObject.SetActive(false);
            }
            var brain = Camera.main.GetComponent<Unity.Cinemachine.CinemachineBrain>();
            if (brain != null && !brain.enabled)
                brain.enabled = true;

            StartCoroutine(EnablePlay());

        }
        IEnumerator EnablePlay()
        {
            yield return null;
            if (camera_1pos != null)
            {
                Camera.main.transform.position = camera_1pos.transform.position;
                Camera.main.transform.rotation = camera_1pos.transform.rotation;
            }
            if (player != null)
            {
                player.SetActive(true);
            }
            introCutscene.SetActive(false);
        }
    }
}
