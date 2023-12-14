using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    [SerializeField] float MovementSpeed = 0.1f;
    public Vector3 StartPosition;
    public Vector3 EndPosition;
    private Vector3 DirectionVector;
    private bool arrived = false;

    void Awake(){
        DirectionVector = EndPosition - StartPosition;
        DirectionVector = DirectionVector.normalized;
    }
    void Update()
    {

        MovePlatform();

        ChangeDirection();

    }

    private void MovePlatform(){
        if(arrived){
            transform.Translate(-DirectionVector*Time.deltaTime*MovementSpeed);
        }else{
            transform.Translate(DirectionVector*Time.deltaTime*MovementSpeed);
        }
    }

    private void ChangeDirection(){
        if(Vector3.Distance(transform.position, StartPosition)<0.1f){
            arrived = false;
        }else if (Vector3.Distance(transform.position, EndPosition)<0.1f){
            arrived = true;
        }
    }
}
