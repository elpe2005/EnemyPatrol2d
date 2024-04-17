using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour
{
    EnemyPatrol patrolScript;
    AiChase chaseScript;
    FieldOfView fovScript;
    void Start()
    {
        fovScript = GetComponent<FieldOfView>();
        patrolScript = GetComponent<EnemyPatrol>();
        chaseScript = GetComponent<AiChase>();
        chaseScript. enabled = false;
    }
    void Update()
    {
       if(fovScript.CanSeePlayer){        
        chaseScript.enabled = true;
        patrolScript.enabled = false;
       }
    }
}
