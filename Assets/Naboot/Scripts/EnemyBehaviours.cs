
using UnityEngine;
using UnityEngine.AI;
using Panda;

public class EnemyBehaviours : MonoBehaviour
{
    NavMeshAgent agent;
   [SerializeField] Transform target;
    [SerializeField] GameObject bullet;
    float StartingTime;
    float currentTime;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [Task] 
    public void MoveToTarget()
    {
        agent.SetDestination(target.position);
        if (agent.remainingDistance <= agent.stoppingDistance && !agent.pathPending)
            Task.current.Succeed();
        else
            Task.current.Fail();
    }
    [Task]
    public void isIntrupted()
    {
        Task.current.Fail();
       
    }
    [Task]
    public void DoNothingForNow()
    {
        Task.current.Succeed();
    }
    [Task]
    void Shoot()
    {
        currentTime = Time.time;
        if (currentTime - StartingTime >= 1)
        {
            Fire();
            StartingTime = Time.time;

        Task.current.Succeed();
        }
    }
    void Fire()
    {
        GameObject go = Instantiate(bullet, transform.position, transform.rotation);
        go.AddComponent<Rigidbody>().AddForce(transform.forward * 500);
    }

}
