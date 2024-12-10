using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlAttack : MonoBehaviour
{
    public AudioSource aud;
    public AudioClip clip;
    public Animator animator;
    private GameObject attackArea = default;

    private bool attacking = false;

    private float TimetoAttack = 0.25f;
    private float Timer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        attackArea = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            animator.SetBool("IsAttack", true);
            Debug.Log("testattack");
           
            Attack();
        }

        if (attacking)
        {
            Timer += Time.deltaTime;
            if (Timer >= TimetoAttack)
            {
                Timer = 0f; 
                attacking = false;
                attackArea.SetActive(attacking);
                animator.SetBool("IsAttack", false);
                aud.PlayOneShot(clip);
            }
        }
    }

    private void Attack()
    {
        attacking = true;
        attackArea.SetActive(attacking);
    }
}
