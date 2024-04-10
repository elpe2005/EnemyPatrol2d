using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FieldOfView : MonoBehaviour
{
    public float radius = 5f;
    [Range (0,360)]public float angle;
    public LayerMask targetLayer;   // Med Enums ska jag då göra så att jag kan ändra state så när FOV ser player så stängs patrol av och Chase börjar, om player går utanför FOV så kommer den gå tillbaka till patrol. 
    public LayerMask obstructionLayer;   // Med Enums ska jag då göra så att jag kan ändra state så när FOV ser player så stängs patrol av och Chase börjar, om player går utanför FOV så kommer den gå tillbaka till patrol. 
    public GameObject playerRef;   // Med Enums ska jag då göra så att jag kan ändra state så när FOV ser player så stängs patrol av och Chase börjar, om player går utanför FOV så kommer den gå tillbaka till patrol. 
    public bool CanSeePlayer { get; private set; }   // Med Enums ska jag då göra så att jag kan ändra state så när FOV ser player så stängs patrol av och Chase börjar, om player går utanför FOV så kommer den gå tillbaka till patrol. 
    void Start()   // Med Enums ska jag då göra så att jag kan ändra state så när FOV ser player så stängs patrol av och Chase börjar, om player går utanför FOV så kommer den gå tillbaka till patrol. 
    {   // Med Enums ska jag då göra så att jag kan ändra state så när FOV ser player så stängs patrol av och Chase börjar, om player går utanför FOV så kommer den gå tillbaka till patrol. 
        playerRef = GameObject.FindGameObjectWithTag("Player");   // Med Enums ska jag då göra så att jag kan ändra state så när FOV ser player så stängs patrol av och Chase börjar, om player går utanför FOV så kommer den gå tillbaka till patrol. 
        StartCoroutine(FOVCheck());   // Med Enums ska jag då göra så att jag kan ändra state så när FOV ser player så stängs patrol av och Chase börjar, om player går utanför FOV så kommer den gå tillbaka till patrol. 
    }   // Med Enums ska jag då göra så att jag kan ändra state så när FOV ser player så stängs patrol av och Chase börjar, om player går utanför FOV så kommer den gå tillbaka till patrol. 
    private IEnumerator FOVCheck()   // Med Enums ska jag då göra så att jag kan ändra state så när FOV ser player så stängs patrol av och Chase börjar, om player går utanför FOV så kommer den gå tillbaka till patrol. 
    {   // Med Enums ska jag då göra så att jag kan ändra state så när FOV ser player så stängs patrol av och Chase börjar, om player går utanför FOV så kommer den gå tillbaka till patrol. 
        WaitForSeconds wait = new WaitForSeconds(0.1f);   // Med Enums ska jag då göra så att jag kan ändra state så när FOV ser player så stängs patrol av och Chase börjar, om player går utanför FOV så kommer den gå tillbaka till patrol. 
   // Med Enums ska jag då göra så att jag kan ändra state så när FOV ser player så stängs patrol av och Chase börjar, om player går utanför FOV så kommer den gå tillbaka till patrol. 
        while (true)   // Med Enums ska jag då göra så att jag kan ändra state så när FOV ser player så stängs patrol av och Chase börjar, om player går utanför FOV så kommer den gå tillbaka till patrol. 
        {
            yield return wait;
            //if(AiState.Patrol == AiState.Patrol)
            {
                FOV();
            }
        }
    }
        private void FOV()
        {
            Collider2D[] rangeCheck = Physics2D.OverlapCircleAll(transform.position, radius, targetLayer);
            if (rangeCheck.Length!= 0)
            {
                Transform target = rangeCheck[0].transform;
                Vector2 directionToTarget = (target.position - transform.position).normalized;

                if(Vector2.Angle(transform.up, directionToTarget) < angle / 2)
                {
                    float distanceToTarget = Vector2.Distance(transform.position, target.position);

                    if(!Physics2D.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionLayer))
                        CanSeePlayer = true;
                    else 
                        CanSeePlayer = false;
                }
                else
                    CanSeePlayer = false;
            }
            else if (CanSeePlayer)
                    CanSeePlayer = false; /* om CanSeePlayer är true så ska den stoppa patrulscriptet och börja AIChase scriptet, 
                    Kanske även fixar så om CanSeePlayer blir false så ska fienden gå tillbaka till patrulscriptet */
        }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        UnityEditor.Handles.DrawWireDisc(transform.position, Vector3.forward, radius);

        Vector3 angle01 = DirectionFromAngle(-transform.eulerAngles.z, -angle / 2); 
        Vector3 angle02 = DirectionFromAngle(-transform.eulerAngles.z, angle / 2);

        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position + angle01 * radius);
        Gizmos.DrawLine(transform.position, transform.position + angle02 * radius);

        if (CanSeePlayer){
            Gizmos.color = Color.green;
            Gizmos.DrawLine(transform.position, playerRef.transform.position);
        }
    }
    private Vector2 DirectionFromAngle(float eulerY, float angleInDegrees)
    {
        angleInDegrees += eulerY;

        return new Vector2(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }
}
