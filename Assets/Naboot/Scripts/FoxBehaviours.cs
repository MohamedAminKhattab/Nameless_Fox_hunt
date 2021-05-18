
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
    [SerializeField] Transform Enemy;
    private FoxState foxState;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
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
    public void StartGathering()// to be called from the scriptabel event
    {
        //Target = SO.transform;
        foxState = FoxState.gathering;
        // Debug.LogWarning(PcikUP.value.position);
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
                Task.current.Succeed();
            }
            else
            {
                Task.current.Fail();
            }
        }
        else
        {
            Task.current.Fail();
        }
    }
    [Task]
    public void shouldMoveToPlayer()
    {
        distance.x = transform.position.x - player.position.x;
        distance.y = transform.position.z - player.position.z;
        //Todo create my own vector2 class to calculate the distance and other things if needed
        if (foxState == FoxState.idle && Vector2.SqrMagnitude(distance) > followingRange * followingRange)
        {
            Target = player;
            Task.current.Succeed();
        }
        else
        {
            Task.current.Fail();
            agent.isStopped = true;
        }
    }

    [Task]
    public void shouldLure()
    {
        if(foxState==FoxState.luring) //check if the enemy is valid 
        {
            Target = Enemy;
            Task.current.Succeed();
        }
        else
        {
            Task.current.Fail();
            agent.isStopped=true;
        }
    }
    #endregion

    #region leafs
    [Task]
    public void FinishFetching()
    {
        hasTargetSo.state = false;
        PickUp.value = null;
        Task.current.Succeed();
    }

    [Task]
    public void MoveToTarget()
    {

        agent.isStopped = false;

        agent.SetDestination(Target.position);
        if (agent.remainingDistance <= agent.stoppingDistance && !agent.pathPending)
            Task.current.Succeed();
    }

    [Task] //should be a task or not??
    public void ReturnToIdle() // better to be standing alone not in the end of followingtarget to be reused 
    {
        foxState = FoxState.idle;
        Task.current.Succeed();
    }
    #endregion
}