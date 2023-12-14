using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Public variables
    public Transform MeshTransform;
    public Rigidbody rb;
    // Private variables
    [SerializeField] private float movementSpeed=5f;
    [SerializeField] private float rotationSpeed=5f;
    [SerializeField] private float jumpSpeed=5f;

    [SerializeField] private Vector2 inputVector;

    private Vector3 lastMoveDirection;


    private void Update(){
        handleMove();
        if(Input.GetKeyDown(KeyCode.Space))
            Jump();
    }

    private void handleMove(){
        inputVector = ReturnInputVector();

        float moveDistance = movementSpeed*Time.deltaTime;

        Vector3 moveDir = new Vector3(inputVector.x, 0, inputVector.y);
        if(moveDir != lastMoveDirection){
            lastMoveDirection = moveDir;
        }

        transform.position += moveDir * moveDistance;

        MeshTransform.right = Vector3.Slerp(MeshTransform.right, moveDir, rotationSpeed*Time.deltaTime);
    }

    private Vector2 ReturnInputVector(){

        //set move direction to zero
        Vector2 input = Vector2.zero; // (0,0)
        
        if(Input.GetKey(KeyCode.W)){
            //Player should move forward
            input.x += 1;
        }
        if(Input.GetKey(KeyCode.S)){
            //Player should move backwards
            input.x += -1;
        }
        if(Input.GetKey(KeyCode.A)){
            //Player should move left
            input.y += 1;
        }
        if(Input.GetKey(KeyCode.D)){
            //Player should move right
            input.y += -1;
        }

        return input;
    }

    private void Jump(){
        rb.AddForce(transform.up*jumpSpeed, ForceMode.Impulse);
    }
}
