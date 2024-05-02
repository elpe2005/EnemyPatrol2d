using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerCharacterData : MonoBehaviour
{
    public List<Fighter> playerList;
    public List<int> KilledEnemies;

    void Start(){
        playerList = new List<Fighter>();
        if(playerList.Count <= 0){
            playerList.Add(new HanSolo());
        }
        playerList.Add(new StoormTrooper());
        
    }
    public void UpdateList(List<int> list){
        KilledEnemies = list;

    }
    public void testWrite(){
        Debug.Log("Vi nådde player");
    }
    public void WriteList(){
        try{
            foreach (int i in KilledEnemies){
                Debug.Log(i);
            }
        }
        catch (Exception e) {
            Debug.Log("Listan kunde inte skrivas ut. Finns gissningsvis inte" + e);
        }
        
    
    }
}
