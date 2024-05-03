using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour
{
    EnemyPatrol patrolScript;
    AiChase chaseScript;
    void Start()
    {
        patrolScript = GetComponent<EnemyPatrol>();
        chaseScript = GetComponent<AiChase>();
        chaseScript.enabled = false;
    }
    void Update()
    {
       
    }
}
