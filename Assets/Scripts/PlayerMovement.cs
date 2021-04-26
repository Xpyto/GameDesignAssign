using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 2f;    //Movespeed of the player
    public Transform movePoint;     //The point on the grid the player is moving towards
    public LayerMask Boundary;      //check if there is a boundary


    // Start is called before the first frame update
    void Start()
    {
        movePoint.parent = null;
<<<<<<< HEAD
<<<<<<< HEAD
        isGrounded = true;
        timeFlow = 1;
        isMoving = false;
=======
>>>>>>> parent of ce01eff (PlayerMechanics)
=======
>>>>>>> parent of ce01eff (PlayerMechanics)
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< HEAD
<<<<<<< HEAD
        if(!dead){
        if(isMoving){
            if(timeFlow > 0){
                timeFlow -= Time.deltaTime;
            }else{
                timeFlow = 0;
            }
        }

        if(timeFlow == 0){
            isMoving = false;
            timeFlow = 1;
        }
        
        
        Debug.Log(isGrounded);
        //Debug.Log(timeFlow);
=======
>>>>>>> parent of ce01eff (PlayerMechanics)
=======
>>>>>>> parent of ce01eff (PlayerMechanics)

        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

        if(Vector3.Distance(transform.position, movePoint.position) <= 0.02f){

            if(Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f){
                if(!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), 0.2f, Boundary)){
                movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
                }
            /*}else if(Input.GetAxisRaw("Vertical")== 1f){
                if(!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f,Input.GetAxisRaw("Vertical"), 0f), 0.2f, Boundary)){ 
                movePoint.position += new Vector3(0f,Input.GetAxisRaw("Vertical"), 0f);
                }*/
<<<<<<< HEAD
<<<<<<< HEAD
            }else{
                isMoving = false;
                timeFlow = 1;
            }
        }

        if(!isGrounded && timeFlow == 1){
            timeFlow -= Time.deltaTime;
            isMoving = true;
            FallDown();
            
        }
        }

        
    }

    public void FallDown(){
        
        movePoint.position -= new Vector3(0f,1f, 0f);
        
    }

    private void OnTriggerStay2D(Collider2D collider){
        isGrounded = (collider != null && (((1 << collider.gameObject.layer) & boundaryFloor) != 0));
        
    }
    private void OnTriggerExit2D(Collider2D collision){
        isGrounded = false;
    }

    private void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.CompareTag("death")){
            dead = true;
        }
=======
            }
        }
>>>>>>> parent of ce01eff (PlayerMechanics)
=======
            }
        }
>>>>>>> parent of ce01eff (PlayerMechanics)
    }
}
