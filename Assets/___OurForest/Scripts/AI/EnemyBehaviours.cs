
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
    [SerializeField] int shootingAngle = 45;
    [SerializeField] BoolSO isPlayerHidden;
    private EnemyState enemyState;
     [SerializeField]Transform Gun;

    

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

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag.Equals("Arrow")) //todo run animations 
        {
            gameObject.SetActive(false);
        }
    }


    #region Panda Leafs
    [Task]
    public void canSeeTheFox()
    {
      if(isPlayerHidden.state)
        {
            Task.current.Fail();
            return;
        }
        if (Measurements.isInRange(transform,fox,VisionRange))
        {
            if (Measurements.isInRange(transform, fox, (int)agent.stoppingDistance)) //can switch 
            {
                enemyState = EnemyState.shooting;
                agent.isStopped = true;
                Task.current.Fail();
                return;
            }
            else
            {
                enemyState = EnemyState.chasingFox;
                //soundSystem.PlayEnemySound(enemyState);
                Task.current.Succeed();
                return;
            }
        }
        else
        {
            enemyState = EnemyState.goingToHouse; // should be removed when the tree gets bigger
            Task.current.Fail();
        }
    }
    [Task]
    public void ShouldShoot()
    {
        if (enemyState == EnemyState.shooting)
            Task.current.Succeed();
        else
            Task.current.Fail();
    }
    [Task]
    public void MoveToTarget()
    {

        agent.isStopped = false;
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
    public bool isIntrupted()// i don't like this method at all seems stupid 
    {
        //if (enemyState == EnemyState.goingToHouse)
        //    soundSystem.PlayEnemySound(enemyState);
        return enemyState !=EnemyState.goingToHouse;

    }
    [Task]
    public void DoNothingForNow()
    {
        Task.current.Succeed();
    }
    [Task]
    public void Aim()
    {
        Vector3 direction = target.position - this.transform.position;
       
        

        this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
                                                Quaternion.LookRotation(direction),
                                                Time.deltaTime * 5);
        if (Task.isInspected)
            Task.current.debugInfo = string.Format("angle={0}",
                Vector3.Angle(this.transform.forward, direction));


        if (Vector3.Angle(this.transform.forward, direction) < shootingAngle)
        {
            Task.current.Succeed();
        }
    }
   
    [Task]
    public void Fire()
    {
        
        soundSystem.PlayEnemySound(enemyState);
        GameObject go = Instantiate(bullet, Gun.position, transform.rotation);
        go.AddComponent<Rigidbody>().AddForce(transform.forward * 500);
        Task.current.Succeed();
    }
    #endregion
}