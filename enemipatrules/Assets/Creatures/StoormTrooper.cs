using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoormTrooper : Gunslinger
{
    public StoormTrooper(){
        this.Health = 50f;
        this.Accuracy = 20f;
        this.Damage = 10f;
        this.Armor = 0.2f;
        this.sprite = Resources.Load<Sprite>("Tusken_Raider_24");
        this.redSprite = Resources.Load<Sprite>("Tusken_Raider_24_red");
    }
}
