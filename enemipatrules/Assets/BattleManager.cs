using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    public Button button1;
    public Button button2;
    public Button button3;
    public Button button4;


    private List<Fighter> enemyList;
    private List<Fighter> playerList;

    private int CharacterSwitchNumber = 1;
    public UnityEngine.Vector2 position;

    public FightAreaEnemyData fightAreaEnemyData;
    public DataToBattleSaver dataToBattleSaver;
    public PlayerCharacterData playerCharacterData;

    public SpriteRenderer playerSprite;
    public SpriteRenderer enemySprite;

    // Setup
    void Start()
    {
        dataToBattleSaver = GameObject.Find("SceneSaver").GetComponent<DataToBattleSaver>();


        playerList = dataToBattleSaver.playerCharacterData.playerList;
        playerCharacterData = dataToBattleSaver.playerCharacterData;

        enemyList = new List<Fighter>();
        for(int stormTrooperCount = 0; stormTrooperCount < dataToBattleSaver.fightAreaEnemyData.StormTrooperAmount; stormTrooperCount++){
            enemyList.Add(new StoormTrooper());
        }
        for(int i = 0; i < dataToBattleSaver.fightAreaEnemyData.DroidAmount; i++){
            enemyList.Add(new Droid());
        }
        position = dataToBattleSaver.position;
        fightAreaEnemyData = dataToBattleSaver.fightAreaEnemyData;

        playerSprite = GameObject.Find("PlayerSprite").GetComponent<SpriteRenderer>();
        enemySprite = GameObject.Find("EnemySprite").GetComponent<SpriteRenderer>();
        UpdateSprites();

        dataToBattleSaver.SelfDestroy();

        button1.onClick.AddListener(OnClick1);
        button2.onClick.AddListener(OnClick2);
        button3.onClick.AddListener(OnClick3);
        button4.onClick.AddListener(OnClick4);

    }


    //Fighting
    void EnemyTurn(){
        try{
            if(enemyList[0].Attack1(playerList[0])){
                TurnRed(false);
            }
            Debug.Log(playerList[0].Health);
        }
        catch
        {
            Debug.Log("Abow");
        }
        if(!enemyList.Any()){
            Debug.Log("Du vann");
            FightOver();
        }
        //UpdateSprites();
    }

    void OnClick1() //Attack1
    {
        Debug.Log("Button is pressed");
        try{
            if(playerList[0].Attack1(enemyList[0])){
                TurnRed(true);
            }
            Debug.Log(enemyList[0].Health);
            if(enemyList[0].Health <= 0){
                enemyList.Remove(enemyList[0]);
            }
        }
        catch{
            Debug.Log("Abow knas");
        }
        EnemyTurn();
    }
    void OnClick2() //Attack2
    {
        try{
            playerList[0].Attack2(enemyList[0]);
            if(enemyList[0].Health <= 0){
                enemyList.Remove(enemyList[0]);
            }
            EnemyTurn();
        }
        catch{
            Debug.Log("Abow han kunde inte Attack2");
        }
    }
    void OnClick3() //Protect
    {
        try{
            playerList[0].Protect();
            EnemyTurn();
        }
        catch{
            Debug.Log("Ojdå");
        }
    }
    void OnClick4() //Switch Character
    {
        if(playerList.Count >= 2){
            if(playerList.Count <= CharacterSwitchNumber){
                CharacterSwitchNumber = 1;
            }
            Fighter temp = playerList[0];
            playerList[0] = playerList[CharacterSwitchNumber];
            playerList[CharacterSwitchNumber] = temp;
            CharacterSwitchNumber++;
            Debug.Log("Du kör nu " + playerList[0]);
        }
        UpdateSprites();
    }
    void FightOver(){
        //Send back to the overworld
        BattleToOverworldSaver bos = GameObject.Find("ToOverworldSaver").GetComponent<BattleToOverworldSaver>();

        List<int> list = playerCharacterData.KilledEnemies;
        bos.StartOverworldScene(playerList, list, fightAreaEnemyData, position);
    }


    //Graphics
    void UpdateSprites(){
        playerSprite.sprite = playerList[0].sprite;
        enemySprite.sprite = enemyList[0].sprite;

    }
    private async void TurnRed(bool target) //true = fiende, false = player
    { //Tills senare: gör motsvarande röd sprite och byt til den.
        if(target){
            Debug.Log("Bror blev röd");
            enemySprite.sprite = enemyList[0].redSprite;
            await Task.Delay(50);
            enemySprite.sprite = enemyList[0].sprite;
        }
        if(!target){
            playerSprite.sprite = playerList[0].redSprite;
            await Task.Delay(50);
            playerSprite.sprite = playerList[0].sprite;
        }
        UpdateSprites();
    }
}