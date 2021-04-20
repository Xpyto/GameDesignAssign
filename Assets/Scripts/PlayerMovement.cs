using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 5f;    //Movespeed of the player
    public Transform movePoint;     //The point on the grid the player is moving towards
    public LayerMask Boundary;      //check if there is a boundary
    public int checkGround;

    // Start is called before the first frame update
    void Start()
    {
        movePoint.parent = null;
        checkGround = 0;
        
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

        if(Vector3.Distance(transform.position, movePoint.position) <= 0.01f){

            if(checkGround == 2){
                movePoint.position -= new Vector3(0f,1f,0f);
            }
             else if(Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f){
                if(!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), 0.2f, Boundary)){
                movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
                }
            }else if(Input.GetAxisRaw("Vertical")== 1f){
                if(!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f,Input.GetAxisRaw("Vertical"), 0f), 0.2f, Boundary)){ 
                movePoint.position += new Vector3(0f,Input.GetAxisRaw("Vertical"), 0f);
                }
            }
        }

    }

    void OnCollisionEnter2D(Collision2D collision){
        Debug.Log(collision.collider.name);
    }

    
}
