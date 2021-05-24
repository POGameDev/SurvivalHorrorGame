using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    NavMeshAgent nm;
    public Transform target;
    public enum AIState { idle, chasing, attack };
    public AIState aiState = AIState.idle;
    public Animator animator;
    private float distanceThreshold = 50f;
    private float attackThreshold = 2.5f;
    private float dist;
    private int atackDamage = 10;
    
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
                    if (dist < attackThreshold)
                    {
                        aiState = AIState.attack;
                        animator.SetBool("Attacking", true);
                    }
                    nm.SetDestination(target.position);
                    break;

                case AIState.attack:
                    if(UserInterface.Health > 0)
                    {
                        UserInterface.Health -= atackDamage;
                    }
                    nm.SetDestination(transform.position);
                    dist = Vector3.Distance(target.position, transform.position);
                    if (dist > attackThreshold)
                    {
                        aiState = AIState.chasing;
                        animator.SetBool("Attacking", false);
                    }
                    break;
                    
                default:
                    break;
            }
            yield return new WaitForSeconds(0.2f);
        }
    }
}
