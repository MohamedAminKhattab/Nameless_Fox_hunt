
using UnityEngine;
using UnityEngine.AI;
using Panda;

public enum EnemyState
{
    goingToHouse,
    chasingFox,
    shooting
}
public class EnemyBehaviours : MonoBehaviour
{
    //Todo create world state
    NavMeshAgent agent;
    Transform target;
    private SoundSystem soundSystem;
    [SerializeField] GameObject bullet;
    [SerializeField] Transform fox;
    [SerializeField] Transform yelena;
    [SerializeField] Transform DefaultGoal;
    [SerializeField] int VisionRange = 4;
    private EnemyState enemyState;
    float StartingTime;
    float currentTime;

    public Transform Fox { get => fox; set => fox = value; }
    public Transform Yelena { get => yelena; set => yelena = value; }
    public Transform DefaultGoal1 { get => DefaultGoal; set => DefaultGoal = value; }

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        target = DefaultGoal;
        enemyState = EnemyState.goingToHouse;
        soundSystem = GetComponent<SoundSystem>(); //GetInParent
    }


  

    #region Panda Leafs
    [Task]
    public bool canSeeTheFox()
    {
      
        if (Measurements.isInRange(transform,fox,VisionRange))
        {
            enemyState = EnemyState.chasingFox;
            soundSystem.PlayEnemySound(enemyState);

            return true;
        }
        else
        {
            enemyState = EnemyState.goingToHouse; // should be removed when the tree gets bigger
            return false;
        }
    }
    [Task]
    public void MoveToTarget()
    {
     

        switch (enemyState)
        {
            case EnemyState.goingToHouse:
                target = DefaultGoal;
                break;
            case EnemyState.chasingFox:
                target = fox;
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
        if (enemyState == EnemyState.goingToHouse)
            soundSystem.PlayEnemySound(enemyState);
        return enemyState !=EnemyState.goingToHouse;

    }
    [Task]
    public void DoNothingForNow()
    {
        Task.current.Succeed();
    }
    [Task]
    public void Shoot()
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
