using UnityEngine;
using Panda;
using UnityEngine.AI;
public enum FoxState //should subtite with world States
{
    idle,
    gathering,
    luring
}
public class FoxBehaviours : MonoBehaviour
{
    //I should call return to idle after every other leaf task cuz the tree is a fallback tree 

    NavMeshAgent agent;
    [SerializeField] Transform player;
    [SerializeField] int followingRange = 2;
    private Vector2 distance;
    private Transform Target;
    [SerializeField] TransformSO PickUp;
    [SerializeField] BoolSO hasTargetSo;
    [SerializeField] BoolSO hasEnemyTargetSo;
    [SerializeField] TransformSO Enemy;
    [SerializeField] BoolSO isPlayerHidden;
    [SerializeField] BoolSO isLuringSound;
    Animator anim;
    [SerializeField] EventSO FoxDeath;
    [SerializeField] HealthSO foxHealth;
    private FoxState foxState;

    public Transform Player { get => player; set => player = value; }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("bullet"))
        {
            
            foxHealth.ApplyDamage(5);
            if (foxHealth.dead)
                FoxDeath.Raise();


        }
    }


    void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        foxHealth.initialHealth = 100;
        foxHealth.currentHealth = 100;
        foxHealth.dead = false;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {

            foxState = FoxState.gathering;

        }
        if (Input.GetKeyDown(KeyCode.S))
        {

            foxState = FoxState.idle;

        }
        if (Input.GetKeyDown(KeyCode.L))
        {

            foxState = FoxState.luring;

        }
    }
    #region Public functions 

    public void Heal() //for khattab to call when collects vine
    {
        foxHealth.Healing(10);
    }
    public void StartGathering()// to be called from the scriptabel event
    {
        //Target = SO.transform;
        foxState = FoxState.gathering;
        // Debug.LogWarning(PcikUP.value.position);
    }
    public void StartLuring()
    {
        foxState = FoxState.luring;
        isLuringSound.state = true;
        Debug.Log("luringgggg");
    }
    public void Flee() //be called from khattab after collecting the pickup
    {
        foxState = FoxState.idle;
    }


    /// <summary>
    /// /////////////////////////////
    /// </summary>
    #endregion

    #region selectors checks


    [Task]
    public void shouldFetch()
    {
        if (foxState == FoxState.gathering)
        {
            if (PickUp.value)
            {
                Target = (Transform)PickUp.value;
                anim.SetBool("run", true);

                 agent.stoppingDistance = .5f; //Todo change elsewhere
                Task.current.Succeed();
            }
            else
            {
                Task.current.Fail();
                anim.SetBool("run", false);

                agent.isStopped = true;
            }
        }
        else
        {
            anim.SetBool("run", false);
            Task.current.Fail();
        }
    }
    [Task]
    public void shouldMoveToPlayer()
    {
        if (isPlayerHidden.state)
        {
            Target = Player;
            agent.stoppingDistance = 1f;
            agent.speed = 5;
            anim.SetBool("run", true);
            if (agent.remainingDistance <= agent.stoppingDistance && !agent.pathPending)
            {
                agent.isStopped = true;
                anim.SetBool("run", false);
                anim.SetBool("walk", false);
                agent.speed = 3.5f;


            }
            Task.current.Succeed();
            return;

        }
        else
            agent.stoppingDistance = 2;
        distance.x = transform.position.x - player.position.x;
        distance.y = transform.position.z - player.position.z;
        //Todo create my own vector2 class to calculate the distance and other things if needed
        if (foxState == FoxState.idle && Vector2.SqrMagnitude(distance) > followingRange * followingRange)
        {
            //agent.stoppingDistance = 2;
            Target = player;
            anim.SetBool("walk", true);

            Task.current.Succeed();
        }
        else
        {
            anim.SetBool("walk", false);

            agent.isStopped = true;
            Task.current.Fail();
        }
    }

    [Task]
    public void shouldLure()
    {
        if (foxState == FoxState.luring && foxHealth.currentHealth >= 40f) //check if the enemy is valid 
        {
            Debug.Log("it's true");
            if (Enemy.value)
            {
                
                Target = Enemy.value;
                anim.SetBool("run", true);
                agent.speed = 5;
                 agent.stoppingDistance = 2;
                Task.current.Succeed();
                
            }
            else
            {
                anim.SetBool("run", false);
                agent.speed = 3.5f;
                Task.current.Fail();
            }
        }
        else
        {
            anim.SetBool("run", false);
            agent.speed = 3.5f;
            agent.isStopped = true;
            Task.current.Fail();
        }
    }
    #endregion

    #region leafs
    [Task]
    public void FinishFetching()
    {
        hasTargetSo.state = false;
        PickUp.value = null;
        agent.stoppingDistance = 2;
        Task.current.Succeed();
    }
    [Task]
    public void FinishLuring()
    {
        hasEnemyTargetSo.state = false;
        Enemy.value = null;
        isLuringSound.state = false;
        Task.current.Succeed();
    }

    [Task]
    public void MoveToTarget()
    {
        if (Task.isInspected)
            Task.current.debugInfo = string.Format("t={0:0.00}", Time.time);

        agent.isStopped = false;
        agent.SetDestination(Target.position);
        if (agent.remainingDistance <= agent.stoppingDistance && !agent.pathPending)
        {
            Task.current.Succeed();
        }

    }

    [Task] 
    public void ReturnToIdle() // better to be standing alone not in the end of followingtarget to be reused 
    {
        foxState = FoxState.idle;
        Task.current.Succeed();
    }
    #endregion
}