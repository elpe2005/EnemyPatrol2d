using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Fighter
{
    // Klassen ärvs av Jedi, Gunslinger och Support
    public float Health;
    public float Armor;
    public Sprite sprite;
    public Sprite redSprite;

    public virtual bool Attack1(Fighter target){return false;}
    public virtual void Attack2(Fighter target){}
    public void Protect(){
        Health += 10;
    }

}
