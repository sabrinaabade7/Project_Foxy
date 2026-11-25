using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemySlime : MonoBehaviour
{
    private GameManager gameManager;
    private Animator anim;

    [SerializeField] private int hp;
    private bool isDie;

    [SerializeField] private float corroutineTime;
    
    [SerializeField] private EnemyState state;
    
    [Header("AI Details")] 
    private NavMeshAgent agent;
    private Vector3 destination;
    private int idWayPoint;
    

// Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        gameManager = FindAnyObjectByType((typeof(GameManager)) as GameManager;
        
        ChangeState(state);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void GetHit(int amount)
    {
        if (isDie)
        {
            return;
        }

        hp -= amount;

        if (hp > 0)
        {
            anim.SetTrigger("getHit");
        }
        else
        {
            anim.SetTrigger("die");
            StartCoroutine(Died());
        }

    }

    private IEnumerator Died()
    {
        isDie = true;
        yield return new WaitForSeconds(corroutineTime);
        Destroy(this.gameObject);
    }

    private void StateManager()
    {
        switch (state)
        {
            case EnemyState.IDLE:
                break;
            case EnemyState.ALERT:
                break;
            case EnemyState.EXPLORE:
                break;
            case EnemyState.PATROL:
                break;
            case EnemyState.FOLLOW:
                break;
            case EnemyState.FURY:
                break;

        }

    }

    private void ChangeState(EnemyState newState) //responsavel por informar o que vai acontecer.
    {
        StopAllCoroutines();
        state = newState;
        
        switch (state)
        {
            case EnemyState.IDLE: 
                destination = transform.position;
                agent.destination = destination;
                StartCoroutine(IdleRoutine());
                break;
            case EnemyState.PATROL:
                idWayPoint = Random.Range(0, gameManager.slimeWayPoints.Length);
                destination = gameManager.slimeWayPoints[idWayPoint].position;
                agent.destination = destination;
                StartCoroutine(PatrolRoutine());
                break;
            case EnemyState.ALERT:
                break;
        }
    }

    private IEnumerator IdleRoutine()
    {
        yield return new WaitForSeconds(gameManager.idleWaitTime);

        StayStill(50);
    }

    private IEnumerator PatrolRoutine()
    {
        yield return new WaitUntil(() => agent.remainingDistance <= 0);
        
        StayStill(30);
    }

    private int Rand()
    {
        int rand = Random.Range(0, 100);
        return rand;

    }

    private void StayStill(int stayThreshold)
    {
        if (Rand() <= stayThreshold)
        {
            ChangeState(EnemyState.IDLE);
        }
        else
        {
            ChangeState(EnemyState.PATROL);
        }
    }
}
