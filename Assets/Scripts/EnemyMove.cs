using System.Collections;
using UnityEngine;
using UnityEngine.AI;
public class EnemyMove : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Transform target2;

    [SerializeField] private NavMeshAgent agent;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(target.position);
        if (agent.destination == target.position)
        {
            StartCoroutine(WaitHere());
            agent.SetDestination(target2.position);
        }
        
    }

    IEnumerator WaitHere()
    {
        yield return new WaitForSeconds(10);
    }

}
