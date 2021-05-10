
using UnityEngine;
using UnityEngine.AI;
using Panda;

enum HuntingState
{
    goingToHouse,
    chasingFox
}
public class EnemyBehaviours : MonoBehaviour
{
    //Todo create world state
    NavMeshAgent agent;
    Transform target;
    [SerializeField] GameObject bullet;
    [SerializeField] Transform Fox;
    [SerializeField] Transform yelena;
    [SerializeField] Transform DefaultGoal;
    private Vector2 distance;
    [SerializeField] int VisionRange = 2;
    private HuntingState huntingState;
    float StartingTime;
    float currentTime;

    public Transform Fox1 { get => Fox; set => Fox = value; }
    public Transform Yelena { get => yelena; set => yelena = value; }
    public Transform DefaultGoal1 { get => DefaultGoal; set => DefaultGoal = value; }

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        target = DefaultGoal;
        huntingState = HuntingState.goingToHouse;
    }


  

    #region Panda Leafs
    [Task]
    public bool canSeeTheFox()
    {
        distance.x = transform.position.x - Fox.position.x;
        distance.y = transform.position.z - Fox.position.z;
        float actualDistance = Vector2.SqrMagnitude(distance);
        //Debug.Log(actualDistance);
        if (actualDistance < VisionRange * VisionRange)
        {
            huntingState = HuntingState.chasingFox;
            return true;
        }
        else
        {
            huntingState = HuntingState.goingToHouse;
            return false;
        }
    }
    [Task]
    public void MoveToTarget()
    {
        switch (huntingState)
        {
            case HuntingState.goingToHouse:
                target = DefaultGoal;
                break;
            case HuntingState.chasingFox:
                target = Fox;
                break;
        }
        agent.SetDestination(target.position);
        if (agent.remainingDistance <= agent.stoppingDistance && !agent.pathPending)
            Task.current.Succeed();
        //else
        //    Task.current.Fail();
    }
    [Task]
    public bool isIntrupted()
    {

        return huntingState!=HuntingState.goingToHouse;

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

           // Task.current.Succeed();
        }
    }
    void Fire()
    {
        GameObject go = Instantiate(bullet, transform.position, transform.rotation);
        go.AddComponent<Rigidbody>().AddForce(transform.forward * 500);
    }
    #endregion
}
