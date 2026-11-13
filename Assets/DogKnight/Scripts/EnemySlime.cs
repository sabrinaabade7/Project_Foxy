using System.Collections;
using UnityEngine;

public class EnemySlime : MonoBehaviour
{
    private Animator anim;

    [SerializeField] private int hp;
    private bool isDie;

    [SerializeField] private float corroutineTime;

    [SerializeField] private EnemyState state;

    [SerializeField] private const float idleWaitTime = 3f;
    [SerializeField] private const float patroWaitTime = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
        
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
        yield return new WaitForSeconds(1.5f);
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
        StopCoroutine(IdleRoutine());
        state = newState;
        
        switch (state)
        {
            case EnemyState.IDLE:
                StartCoroutine(IdleRoutine());
                break;
            case EnemyState.PATROL:
                StartCoroutine(PatrolRoutine());
                break;
            case EnemyState.ALERT:
                break;
        }
    }

    private IEnumerator IdleRoutine()
    {
        yield return new WaitForSeconds(idleWaitTime);

        if (Random.Range(0, 100) < 50)
        {
            ChangeState(EnemyState.IDLE);
        }
        else
        {
            ChangeState(EnemyState.PATROL);
        }
        
    }

    private IEnumerator PatrolRoutine()
    {
        yield return new WaitForSeconds(patroWaitTime);
        ChangeState(EnemyState.IDLE);
    }

}
