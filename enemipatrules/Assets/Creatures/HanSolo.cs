using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HanSolo : Gunslinger
{
    public HanSolo(){
        this.Health = 70f;
        this.Damage = 20f;
        this.Accuracy = 90f;
        this.Armor = 0f;
        this.sprite = Resources.Load<Sprite>("Han_Solo_28");
        this.redSprite = Resources.Load<Sprite>("Han_Solo_Red");
    }
}
