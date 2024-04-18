using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public Transform[] patrolPoints;
    public int targetPoint;
    public float speed;
    void Start()
    {
        targetPoint = 0;
    }
    void Update()
    {
        if (transform.position == patrolPoints[targetPoint].position)
        {
            increaseTargetInt();
        }
        transform.position = Vector3.MoveTowards(transform.position, patrolPoints[targetPoint].position,speed * Time.deltaTime); 
        Vector2 dir = patrolPoints[targetPoint].position - transform.position;
        float deg = Mathf.Atan2(dir.y,dir.x);
        transform.rotation = Quaternion.Euler(0,0, math.degrees(deg - MathF.PI/2) );
    }
    void increaseTargetInt()
    {
        targetPoint++;
        if (targetPoint >= patrolPoints.Length)
        {
            targetPoint = 0;
        }
    }
}
