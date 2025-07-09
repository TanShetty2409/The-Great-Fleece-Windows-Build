using System.Collections;
using UnityEngine;

public class SecurityCam : MonoBehaviour
{
    public GameObject captureCutscene;
    private Animator _anim;
    void Start()
    {
        _anim = GetComponentInParent<Animator>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            MeshRenderer render = GetComponent<MeshRenderer>();
            Color color = new Color(0.6f, 0.1f, 0.1f, 0.15f);
            render.material.SetColor("_TintColor", color);
            StartCoroutine(cutSceneDelay());
            
        }
    }
    IEnumerator cutSceneDelay()
    {
        _anim.enabled = !_anim.enabled;
        yield return new WaitForSeconds(0.5f);
        captureCutscene.SetActive(true);
    }
}
