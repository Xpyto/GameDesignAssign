using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityMovement : MonoBehaviour
{
    int count = 0;
    float moveSpeed = 5f;
    bool isGround;

    public PlayerMovement playerMain;
    public Transform movePoint;
    // Start is called before the first frame update
    void Start()
    {
        movePoint.parent = null;
        isGround = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(playerMain.isMoving){
            MovePhysics();
        }
    }

    private void OnTriggerExit2D(Collider2D collider){
        if(collider.gameObject.CompareTag("Floor")){
            isGround = false;
        
    }

    private void OntriggerStay2D(Collider2D collision){
        if(collision.gameObject.CompareTag("boxFloor")){
        isGround = true;
        }
    }

    public void MovePhysics(){
        Debug.Log(isGround);
        if(!isGround){
        if(count == 0){
            count = 1;  
        }else{
            transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);
            count = 0;
        }
        }else{
            movePoint.position = transform.position;
        }
    }
}
