using System.Collections;
using UnityEngine;

public class EnemySlime : MonoBehaviour
{
    private Animator anim;

    [SerializeField] private int hp;
    private bool isDie;

    [SerializeField] private float corroutineTime;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
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
        
    }

}
