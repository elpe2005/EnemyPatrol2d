using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleToOverworldSaver : MonoBehaviour
{
    public List<Fighter> playerList;
    public Vector2 position;
    public List<int> list;
    public int FAEDid;
    private void Awake() {
        DontDestroyOnLoad(transform.gameObject);
    }
    public void StartOverworldScene(List<Fighter> PlayerList, List<int> list, FightAreaEnemyData fightAreaEnemyData, Vector2 position){
        this.playerList = PlayerList;
        this.list = list;
        this.FAEDid = fightAreaEnemyData.ID;
        this.position = position;
        SceneManager.LoadScene("SampleScene");
    }
    public void SelfDestroy(){
        Destroy(this);
        Destroy(gameObject);
    }
}
