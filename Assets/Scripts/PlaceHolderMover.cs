using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceHolderMover : MonoBehaviour
{
    public Transform startPosition;
    public Transform endPosition;
    public float movementSpeed;
    public float stopDistance=0.1f;
    Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = startPosition.position;
    }

    // Update is called once per frame
    void Update()
    {
        direction = endPosition.position-transform.position;
        float distance = direction.magnitude;
        direction = direction.normalized;

        Debug.DrawLine(transform.position, transform.position+direction, Color.red);
        if(distance<stopDistance){
            Transform tmp;
            tmp = startPosition;
            startPosition = endPosition;
            endPosition = tmp;
        }
        transform.Translate(direction*Time.deltaTime*movementSpeed);
    }
}
