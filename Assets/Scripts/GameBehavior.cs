using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBehavior : MonoBehaviour
{
    public GameOverScript GameOverScreen;
    public GameObject[] Entities;
    public GameObject player;

    public void GameOver(){
        GameOverScreen.Setup();
    }

<<<<<<< HEAD
<<<<<<< HEAD
    void Update(){
        if(player.dead){
            GameOver();
        }

        /*if(player.isMoving){
            foreach(GameObject E in Entities){
                Debug.Log("Moving");
                E.GetComponent<EntityMovement>().MovePhysics();
            }
        }*/
=======
    void TimeMove(){
        
>>>>>>> parent of ce01eff (PlayerMechanics)
=======
    void TimeMove(){
        
>>>>>>> parent of ce01eff (PlayerMechanics)
    }
}
