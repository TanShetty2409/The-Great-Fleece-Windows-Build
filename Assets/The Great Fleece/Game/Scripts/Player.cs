using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private NavMeshAgent _agent;
    private Animator _animator;
    public GameObject coin;
    [SerializeField]
    private AudioClip _coinTossClip;
    private bool _coinThrown;
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponentInChildren<Animator>();
    }


    void Update()
    {   //Movement
        if (Input.GetMouseButtonDown(0))  
        {
            Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(rayOrigin, out hitInfo))
            {
                // Debug.Log("Hit: " + hitInfo.point);

                _agent.destination = hitInfo.point;
                _animator.SetBool("walk", true);
            }

        }

        if (!_agent.pathPending && _agent.remainingDistance <= _agent.stoppingDistance)
        {
            if (!_agent.hasPath || _agent.velocity.sqrMagnitude < 0.01f)
            {
                _animator.SetBool("walk", false);
            }
        }

        //Coin Toss
        if (Input.GetMouseButtonDown(1) && !_coinThrown)
        {
            _animator.SetTrigger("Throw");

            Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            int groundMask = LayerMask.GetMask("Ground");
            if (Physics.Raycast(rayOrigin, out hitInfo, Mathf.Infinity, groundMask))
            {
                Debug.Log("Raycast hit: " + hitInfo.collider.gameObject.name);
                Vector3 coinSpawnPos = hitInfo.point;

                GameObject coinInstance = Instantiate(coin, coinSpawnPos, Quaternion.identity);

                Renderer coinRenderer = coinInstance.GetComponentInChildren<Renderer>();
                if (coinRenderer != null)
                {
                    float coinHeight = coinRenderer.bounds.size.y;
                    coinInstance.transform.position += new Vector3(0, coinHeight / 2f + 0.01f, 0);
                }

                AudioSource.PlayClipAtPoint(_coinTossClip, transform.position);
                SendGuardtoCoin(coinInstance.transform.position);
                _coinThrown = true;
            }

        }


        void SendGuardtoCoin(Vector3 coinPos)
        {
            GameObject[] guards = GameObject.FindGameObjectsWithTag("Guard1");
            foreach (var guard in guards)
            {
                NavMeshAgent currentAgent = guard.GetComponent<NavMeshAgent>();
                GuardAI currentGuard = guard.GetComponent<GuardAI>();
                Animator guardAnim = guard.GetComponent<Animator>();
                currentGuard.coinTossed = true;
                currentAgent.SetDestination(coinPos);
                guardAnim.SetBool("walk", true);
                currentGuard.coinPos = coinPos;
            }
        }

    }
}