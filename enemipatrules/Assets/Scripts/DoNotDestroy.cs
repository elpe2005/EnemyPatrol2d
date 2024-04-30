using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
   void Awake(){
    GameObject[] musicObj= GameObject.FindGameObjectsWithTag("GameMusic");
    if (musicObj.Length>1){
        Destroy(this.gameObject);
    }
    DontDestroyOnLoad(this.gameObject);
   }
}