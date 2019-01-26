using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;

public class HaplessVictim : MonoBehaviour
{
    // public Transform[] patrolPoints;

    NavMeshAgent _navMeshAgent;
    Animator _animator;

    int patrolPointIndex;
    float proximityBeforeChangeDestination = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
    	_navMeshAgent = GetComponent<NavMeshAgent>();
	    _animator = GetComponent<Animator>();

        _navMeshAgent.updatePosition = true;
	    SetNextDestination();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Hello, world!");
//        animator.SetFloat("Forward", navMeshAgent.desiredVelocity.magnitude, 0.1f, Time.deltaTime);
        _navMeshAgent.updatePosition = true;
	       SetNextDestination();

         // if (!_navMeshAgent.pathPending && _navMeshAgent.remainingDistance < proximityBeforeChangeDestination)
         // {
         //      SetNextDestination();
         // }
    }


    void SetNextDestination()
    {
        // _navMeshAgent.SetDestination(patrolPoints[patrolPointIndex].position);
        // patrolPointIndex = (patrolPointIndex + 1) % patrolPoints.Length;
    }

    /*
    void OnCollisionEnter(Collision c)
    {
        var other = c.gameObject;
        if (other.CompareTag("Player"))
        {
            other.SendMessage("Die");
        }
    }*/
}
