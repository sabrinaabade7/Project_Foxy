using UnityEngine;

public enum EnemyState
{
   IDLE,
   ALERT,
   EXPLORE,
   PATROL,
   FOLLOW,
   FURY
}


public class GameManager : MonoBehaviour
{
    public Transform player;
    
    [Header("Slime AI")] 
    public Transform[] slimeWayPoints;
    public float idleWaitTime;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
