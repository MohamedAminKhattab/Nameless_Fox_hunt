
using UnityEngine;
using UnityEngine.AI;
using Panda;

public enum EnemyState
{
    goingToHouse,
    chasing,
    shooting,
    dead
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
    [SerializeField] Transform Gun;
    [SerializeField] float raidingSpeed = 1;
    [SerializeField] BoolSO isenemyDeadSound;
    [SerializeField] BoolSO isenemymovingSound;
    Animator anim;
    private Transform fovTarget;

    private Vector3 direction;
    public Transform Fox { get => fox; set => fox = value; }
    public Transform Yelena { get => yelena; set => yelena = value; }
    public Transform DefaultGoal1 { get => DefaultGoal; set => DefaultGoal = value; }


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        target = DefaultGoal;
        enemyState = EnemyState.goingToHouse;
        soundSystem = GetComponent<SoundSystem>(); //GetInParent
        anim = GetComponent<Animator>();

    }
    private void Update()
    {
        anim.SetBool("speed", !agent.isStopped);
        anim.SetBool("chase", enemyState == EnemyState.chasing);//change to global chasing
        isenemymovingSound.state = !agent.isStopped;


    }
    private void OnDestroy()
    {
        isenemyDeadSound.state = true; //genius 

    }
    private void Die()
    {
        agent.isStopped = true;
        enemyState = EnemyState.dead;
        anim.SetTrigger("die");
        isenemyDeadSound.state = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Arrow") || other.tag.Equals("Trap"))
        {
            Die();
        }
    }


    #region Panda Leafs
    [Task]
    public void FOV()
    {
        if (isPlayerHidden.state || enemyState == EnemyState.dead)
        {
            enemyState = EnemyState.goingToHouse;
            Task.current.Fail();
            return;
        }


        if (Measurements.isInRange(transform, fox, VisionRange)) // test distance
        {
            direction = fox.position - this.transform.position;
            if (Vector3.Angle(this.transform.forward, direction) < shootingAngle) //test angle
            {
                fovTarget = fox;
                Task.current.Succeed();
            }
        }
        else if (Measurements.isInRange(transform, yelena, VisionRange)) // test distance
        {
            direction = yelena.position - this.transform.position;
            if (Vector3.Angle(this.transform.forward, direction) < shootingAngle) //test angle
            {
                fovTarget = yelena;
                Task.current.Succeed();
            }
            else
            {
                enemyState = EnemyState.goingToHouse; // should be removed when the tree gets bigger
                agent.speed = raidingSpeed;
                anim.SetBool("shooting", false);
                Task.current.Fail();
            }
        }
    }
    [Task]
    public void Chase()
    {
        enemyState = EnemyState.chasing; //should Chase
        agent.speed = 3;
        Task.current.Succeed();
    }
    [Task]
    public void ShouldShoot()
    {
        if (Measurements.isInRange(transform, fox, (int)agent.stoppingDistance))
        {
            enemyState = EnemyState.shooting;
            agent.isStopped = true;
            anim.SetBool("shooting", true);
            Task.current.Succeed();


        }
        else
        {
            anim.SetBool("shooting", false);
            Task.current.Fail();
        }
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
            case EnemyState.chasing:
                target = fovTarget;
                break;

        }
        //Debug.Log(agent.pathPending);

        agent.SetDestination(target.position);
        if (agent.remainingDistance <= agent.stoppingDistance && !agent.pathPending)
        {
            Task.current.Succeed();
            agent.isStopped = true;
        }

    }
    [Task]
    public bool isIntrupted()// i don't like this method at all seems stupid 
    {


        return enemyState != EnemyState.goingToHouse;

    }
    //[Task]
    //public void LookAround()
    // {
    //     agent.isStopped = true;
    //     if(anim.is().)
    // }
    [Task]
    public void Aim()
    {
        Vector3 direction = target.position - this.transform.position;

        transform.forward = direction;


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
        FindObjectOfType<AudioManager>().PlayeSound("Gun");
        GameObject go = Instantiate(bullet, Gun.position, transform.rotation);
        go.AddComponent<Rigidbody>().AddForce(Gun.transform.forward * 500);
        Task.current.Succeed();
    }
    #endregion
}
