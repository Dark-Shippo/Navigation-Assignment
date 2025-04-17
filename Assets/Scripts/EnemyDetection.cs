using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    public Transform target;
    public float aggro = 0.0f;
    public float aggroMin = 0.0f;
    public float aggroMax = 10.0f;
    public float aggroIncreaseRate = 5.0f;
    public float aggroDecreaseRate = 1.5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(target != null)
        {
            aggro += aggroIncreaseRate * Time.deltaTime;
        }
        else
        {
            aggro -= aggroDecreaseRate * Time.deltaTime;
        }
        aggro = Mathf.Clamp(aggro, aggroMin, aggroMax);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            target = other.transform;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            target = null;
        }
    }
}
