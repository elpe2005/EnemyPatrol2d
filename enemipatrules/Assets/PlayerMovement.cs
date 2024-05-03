using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class PlayerMovement : MonoBehaviour
{
    public Vector2 Speed = new Vector2(1,1);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float InputX = Input.GetAxis ("Horizontal");
        float InputY = Input.GetAxis ("Vertical");

        Vector3 movement = new Vector3 (Speed.x * InputX, Speed.y * InputY, 0);
        movement *= Time.deltaTime;

        transform.Translate(movement);
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag.CompareTo("Walls") == 0)
        {
            Debug.Log($"Walls");
        }
    }
    
}
