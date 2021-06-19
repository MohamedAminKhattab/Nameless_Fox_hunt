
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
    [SerializeField] GameObject bullet;
    [SerializeField] Transform fox;
    [SerializeField] Transform yelena;
    [SerializeField] Transform DefaultGoal;
    [SerializeField] Transform SpawnPoint;
    [SerializeField] int VisionRange = 4;
    [SerializeField] int shootingAngle = 45;
    [SerializeField] BoolSO isPlayerHidden;
    [SerializeField] Transform Gun;
    [SerializeField] float raidingSpeed = 1;
    [SerializeField] BoolSO isenemyDeadSound;
    [SerializeField] BoolSO isenemymovingSound;
    [SerializeField] GameObject MuzlleVfx;

    NavMeshAgent agent;
    Transform target;
    Animator anim;
    private EnemyState enemyState;
    private Transform fovTarget;
    private bool canSeeFox;
    private Vector3 direction;
    private Transform CurrentGoal;
    public Transform Fox { get => fox; set => fox = value; }
    public Transform Yelena { get => yelena; set => yelena = value; }
    public Transform DefaultGoal1 { get => DefaultGoal; set => DefaultGoal = value; }


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        target = DefaultGoal;
        enemyState = EnemyState.goingToHouse;
        anim = GetComponent<Animator>();
      //  SpawnPoint = GetComponentInParent<SpawnPoint>().transform;

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
        agent.speed = 0;
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
            
           
                fovTarget = fox;
                canSeeFox = true;
                Task.current.Succeed();
                return;
            }
            else if (Measurements.isInRange(transform, yelena, VisionRange)) // test distance
            {
                direction = yelena.position - this.transform.position;

                if (Vector3.Angle(this.transform.forward, direction) < shootingAngle) //test angle
                {
                    fovTarget = yelena;
                    Task.current.Succeed();
                    return;
                }
            else
            {
                enemyState = EnemyState.goingToHouse; // should be removed when the tree gets bigger
                agent.speed = raidingSpeed;
                anim.SetBool("shooting", false);
                Task.current.Fail();
                return;
            }
        }
            else
            {
                enemyState = EnemyState.goingToHouse; // should be removed when the tree gets bigger
                agent.speed = raidingSpeed;
                anim.SetBool("shooting", false);
                Task.current.Fail();
                return;
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
        if (Measurements.isInRange(transform, fovTarget, (int)agent.stoppingDistance))
        {
            enemyState = EnemyState.shooting;
            agent.isStopped = true;
            if(!anim.GetBool("shooting"))
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
    public void ReturnToSpawn()
    {
        CurrentGoal = SpawnPoint;
        Task.current.Succeed();
    } [Task]
    public void TargetTheHouse()
    {
        CurrentGoal = DefaultGoal;
        Task.current.Succeed();
    }
    [Task]
    public void MoveToTarget()
    {

        agent.isStopped = false;
        switch (enemyState)
        {
            case EnemyState.goingToHouse:
                target = CurrentGoal;
                break;
        
            case EnemyState.chasing:
                target = fovTarget;
                break;

        }
        Debug.Log(target);

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
    Vector3 AimDirection;
    [Task]
    public void Aim()
    {
         AimDirection = target.position - this.transform.position;

        // transform.forward = AimDirection;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction, Vector3.up), .5f);


        if (Task.isInspected)
            Task.current.debugInfo = string.Format("angle={0}",
                Vector3.Angle(this.transform.forward, AimDirection));


        if (Vector3.Angle(this.transform.forward, AimDirection) < shootingAngle)
        {
            Task.current.Succeed();
        }
    }

    [Task]
    public void Fire()
    {

       // FindObjectOfType<AudioManager>().PlayeSound("Gun");
        GameObject go = Instantiate(bullet, Gun.position, transform.rotation);
        go.AddComponent<Rigidbody>().AddForce(AimDirection * 500);
        MuzlleVfx.GetComponent<ParticleSystem>().Play();
        Task.current.Succeed();
    }
    #endregion
}
