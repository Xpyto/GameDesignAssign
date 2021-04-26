using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBehavior : MonoBehaviour
{
    public GameOverScript GameOverScreen;
    public GameObject[] Entities;
    public PlayerMovement player;

    public void GameOver(){
        GameOverScreen.Setup();
    }

    void Update(){
        if(player.dead){
            GameOver();
        }
    }
    
}
