using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Panda;
using UnityEngine.AI;
public enum FoxState
{
    idle,
    gathering
}
public class FoxBehaviours : MonoBehaviour
{
    NavMeshAgent agent;
    [SerializeField] Transform player;
    [SerializeField] int followingRange = 2;
    private Vector2 distance;
    public Transform Target;
    public Transform myCube;
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
        
    }
   [Task]
   public void ReturnToFollowing()
    {
        foxState = FoxState.idle;
        Task.current.Succeed();
    }
    #region selectors
    [Task]
    public bool shouldFetch()
    {
        if (foxState == FoxState.gathering)
        {
            Target = myCube;
            return true;
        }
        else return false;
    }
    [Task]
    public bool shouldMoveToPlayer()
    {
        distance.x = transform.position.x - player.position.x;
        distance.y = transform.position.z - player.position.z;
        //Todo create my own vector2 class to calculate the distance and other things if needed
        if (foxState==FoxState.idle && Vector2.SqrMagnitude(distance) > followingRange * followingRange)
        {
            Target = player;
            Task.current.Succeed();
            return true;

        }
        else
        {
            Task.current.Succeed();
            return false;
        }
    }
    #endregion

    #region moving leafs
    [Task]
    public void MoveToPlayer()
    {
        agent.SetDestination(player.position);
        Task.current.Succeed();
    }
    [Task]
    public void MoveToTarget()
    {
        agent.SetDestination(Target.position);
        if(agent.remainingDistance<= agent.stoppingDistance)
        Task.current.Succeed();
    }
    #endregion
}
