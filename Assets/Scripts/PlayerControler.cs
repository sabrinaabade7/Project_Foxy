using System;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    private CharacterController controller;
    private Animator anim;

    [Header("Player Configurations")] [SerializeField]
    private float movementSpeed;

    [Header("Cameras")] private Vector3 direction;
    private bool isWalk;

    private float horizontal;
    private float vertical;

    [Header("Attack")]
    [SerializeField] private ParticleSystem fxAttack;
    private bool isAttack;
    [SerializeField] private Transform hitbox;
    [Range(0.1f, 1f)] 
    [SerializeField] private float hitRange = 0.5f;
    [SerializeField] private Collider[] hitInfo;
    [SerializeField] private LayerMask hitMask;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        Inputs();
        Movecharacter();
        UpdateAnimator();

    }

    private void UpdateAnimator()
    {
        anim.SetBool("isWalk", isWalk);
    }

    private void Attack()
    {
        isAttack = true;
        anim.SetTrigger("Attack");
        fxAttack.Emit(1);
    }

    public void AttackDone()
    {
        isAttack = false;
    }

private void Movecharacter()
    {
         direction = new Vector3(horizontal, 0f, vertical).normalized;
                
                if (direction.magnitude >= 0.1f)
                {
                    float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
                    transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);
                    isWalk = true;
                }
                else
                {
                    isWalk = false;
                }
                
                controller.Move(direction * movementSpeed * Time.deltaTime);
               
    }

    private void Inputs()
    {
            horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");
                
                if (Input.GetButtonDown("Fire1") && !isAttack)
                {
                    Attack();
                }
                
    }
    
}

