using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
public class EnemyMove : MonoBehaviour
{
    [SerializeField] private Transform[] path;
    [SerializeField] private int currentPathIndex = 0;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private EnemyDetection detection;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        detection = GetComponentInChildren<EnemyDetection>();
    }

    // Update is called once per frame
    void Update()
    {
        if (detection.aggro < 3 || detection.target == null)
        {
            if (agent.remainingDistance < agent.stoppingDistance)
            {
                agent.SetDestination(path[currentPathIndex++].position);
                if (currentPathIndex >= path.Length)
                {
                    currentPathIndex = 0;
                }
            }
        }
        else
        {
            agent.SetDestination(detection.target.position);
        }
    }

    //IEnumerator WaitHere()
    //{
    //    yield return new WaitForSeconds(10);
    //}

}
