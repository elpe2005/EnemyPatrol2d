using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightAreaEnemyData : MonoBehaviour
{
    public int ID;
    public int StormTrooperAmount;
    public int DroidAmount;
    public void SelfDestroy(){
        Destroy(this);
        Destroy(gameObject);
    }
}
