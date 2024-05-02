using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FightStarter : MonoBehaviour
{
    float time;
    void Start()
    {
        time = Time.fixedTime;
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if((Time.fixedTime - time) > 5){
            Debug.Log("Du vidror den");
            if (other.gameObject.CompareTag("FightArea")) 
            { 
                Debug.Log("Test");
                FightSetup(other);
            } 
        }

    }
    public void FightSetup(Collider2D other){
        //Get information angående fienderna
        FightAreaEnemyData FAED = other.gameObject.GetComponent<FightAreaEnemyData>();
        PlayerCharacterData PCD = gameObject.GetComponent<PlayerCharacterData>();

        Debug.Log(PCD.playerList[0]);
        Vector2 position = gameObject.transform.position;

        //Skicka in spelaren i fighten
        DataToBattleSaver DBS = GameObject.Find("SceneSaver").GetComponent<DataToBattleSaver>();
        DBS.StartBattleScene(PCD,FAED, position);

    }
}
