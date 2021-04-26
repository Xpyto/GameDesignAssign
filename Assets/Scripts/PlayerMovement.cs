using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 5f;    //Movespeed of the player
    public Transform movePoint;     //The point on the grid the player is moving towards
    [SerializeField] private LayerMask boundaryFloor;      //check if there is a boundary
    [SerializeField] private LayerMask deathFloor;
    float timeFlow;

    public bool isMoving;

    public bool isGrounded;

    public bool dead;


    // Start is called before the first frame update
    void Start()
    {
        dead = false;
        movePoint.parent = null;
        isGrounded = true;
        timeFlow = 3;
        isMoving = false;
    }

    // Update is called once per frame
    void Update()
    {
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
            timeFlow = 3;
        }
        
        
        Debug.Log(isGrounded);
        Debug.Log(timeFlow);

        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

        if(Vector3.Distance(transform.position, movePoint.position) <= 0.01f && isGrounded){

            if(Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f){
                if(!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), 0.2f, boundaryFloor)){
                movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
                isMoving = true;
                }
            /*}else if(Input.GetAxisRaw("Vertical")== 1f){
                if(!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f,Input.GetAxisRaw("Vertical"), 0f), 0.2f, Boundary)){ 
                movePoint.position += new Vector3(0f,Input.GetAxisRaw("Vertical"), 0f);
                }*/
            }else{
                isMoving = false;
                timeFlow = 3;
            }
        }

        if(!isGrounded && timeFlow == 3){
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
    }
}
