using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OverwroldFromBattleStarter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        try{
            BattleToOverworldSaver bos = GameObject.Find("ToOverworldSaver").GetComponent<BattleToOverworldSaver>();
            PlayerCharacterData playerCharacterData = GameObject.Find("Player").GetComponent<PlayerCharacterData>();
            GameObject player = GameObject.Find("Player");
            playerCharacterData.playerList = bos.playerList;
            player.transform.position = bos.position;
            playerCharacterData.testWrite();
            playerCharacterData.WriteList();
            Debug.Log("Test igen");
            List<int> tempList = new List<int>();
            try{
                foreach (int i in bos.list){
                    tempList.Add(i);
                }
            }
            catch {

            }
            tempList.Add(bos.FAEDid);
            
            Debug.Log("hola");
            playerCharacterData.UpdateList(tempList);
            Debug.Log("Görgen");

            foreach(GameObject temp in GameObject.FindGameObjectsWithTag("FightArea")){
                FightAreaEnemyData tempObj = temp.GetComponent<FightAreaEnemyData>();
                Debug.Log(tempObj.ID);
                foreach (int i in playerCharacterData.KilledEnemies){
                    if(i == tempObj.ID){
                        tempObj.SelfDestroy();
                    }
                }
            }
            bos.SelfDestroy();
        }
        catch(Exception e)
        {
            //Inget att göra
            Debug.Log("Abow, kunde inte skicka över datan");
            Debug.Log(e);
        }
    }


}
