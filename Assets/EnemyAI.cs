using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    NavMeshAgent nm;
    public Transform target;
    public enum AIState { idle, chasing };
    public AIState aiState = AIState.idle;
    public Animator animator;
    public float distanceThreshold = 5f;
    private float dist;
    // Start is called before the first frame update
    void Start()
    {
        nm = GetComponent<NavMeshAgent>();
        StartCoroutine(Think());
        //target = GameObject.FindGameObjectsWithTag("Character").transform;
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Think()
    {
        while(true)
        {
            switch(aiState)
            {
                case AIState.idle:
                    dist = Vector3.Distance(target.position, transform.position);
                    if(dist < distanceThreshold)
                    {
                        aiState = AIState.chasing;
                        animator.SetBool("Chasing", true);
                    }
                    break;
                case AIState.chasing:
                    dist = Vector3.Distance(target.position, transform.position);
                    if (dist > distanceThreshold)
                    {
                        aiState = AIState.idle;
                        animator.SetBool("Chasing", false);
                    }
                    nm.SetDestination(target.position);
                    break;
                default:
                    break;
            }
            yield return new WaitForSeconds(0.2f);
        }
    }
}
