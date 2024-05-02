using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Droid : Gunslinger
{
    public Droid(){
        this.Health = 15f;
        this.Accuracy = 30f;
        this.Damage = 10f;
        this.Armor = 0.1f;
    }
}
