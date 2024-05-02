using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Gunslinger : Fighter
{
    public float Damage;
    public float Accuracy;

    public override bool Attack1(Fighter target){
        if(Random.Range(0,100) < Accuracy){
            target.Health -= Damage * (1-target.Armor);
            return true;
        }
        else{
            Debug.Log("Missed the target");
            return false;
        }
    }

}
