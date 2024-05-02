using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataToBattleSaver : MonoBehaviour
{
    public FightAreaEnemyData fightAreaEnemyData;
    public PlayerCharacterData playerCharacterData;
    public UnityEngine.Vector2 position;
    private void Awake() {
        DontDestroyOnLoad(transform.gameObject);
    }

    void Start()
    {

    }

    public void StartBattleScene(PlayerCharacterData PCD, FightAreaEnemyData FAED, UnityEngine.Vector2 position)
    {
        Debug.Log("Fight");
        fightAreaEnemyData = FAED;
        playerCharacterData = PCD;
        this.position = position;
        Debug.Log(fightAreaEnemyData.StormTrooperAmount);
        SceneManager.LoadScene("BattleScene");
    }
    public void SelfDestroy(){
        Destroy(this);
        Destroy(gameObject);
    }


}
