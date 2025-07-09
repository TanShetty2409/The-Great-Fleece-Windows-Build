using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GuardAI : MonoBehaviour
{
    private NavMeshAgent _agent;
    public List<Transform> wayPoints;
    [SerializeField]
    private int i;
    private bool reverse;
    private bool targetReached;
    private Animator _animator;
    public bool coinTossed;
    public Vector3 coinPos;

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();

    }
    void Update()
    {
        if (wayPoints.Count > 0 && wayPoints[i] != null && !coinTossed)
        {
            _agent.SetDestination(wayPoints[i].position);
            float distance = Vector3.Distance(transform.position, wayPoints[i].position);
            
            if (_agent.velocity.sqrMagnitude > 0.01f && !targetReached)
            {
                if (_animator != null)
                {
                    _animator.SetBool("walk", true);
                }
            }
            if (distance < 1.0f && targetReached == false)
            {
                targetReached = true;
                if (wayPoints.Count < 2)
                {
                    if (_animator != null)
                    {
                        _animator.SetBool("walk", false);
                    }
                    return;
                }
                StartCoroutine(MovementPause());
            }
        }
        else
        {
            float distance = Vector3.Distance(transform.position, coinPos);
            // Debug.Log("Distance: " + distance);
            if (distance < 4.0f)
            {
                _animator.SetBool("walk", false);
            }
        }
    }
    IEnumerator MovementPause()
    {
        if (i == 0 || i == wayPoints.Count - 1)
        {
            if (_animator != null)
            {
                _animator.SetBool("walk", false);
            }
            yield return new WaitForSeconds(1.5f);
        }
        if (reverse == true)
        {
            i--;
            if (i < 0)
            {
                reverse = false;
                i = 0;
            }
        }
        else if (reverse == false)
        {
            i++;
            if (i == wayPoints.Count)
            {
                reverse = true;
                i--;
            }
        }
        targetReached = false;
    }
}
