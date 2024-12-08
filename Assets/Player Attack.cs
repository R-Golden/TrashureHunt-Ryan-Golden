using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    private float AttackNb = 3;
    private bool CanAttack = true;
    private bool Canattackagain = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }



    private void Attack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Swing");
        }
    }

}
