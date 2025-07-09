using UnityEngine;

public class LookatPlayer : MonoBehaviour
{
    public Transform target;
    public Transform startPosition;
    void Start()
    {
        transform.position = startPosition.position;
        transform.rotation = startPosition.rotation;
    }
    void Update()
    {
        transform.LookAt(target);
    }
}
