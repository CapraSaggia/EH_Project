using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public Transform targetPosition;
    public float movementSpeed;
    public float rotationSpeed=2;
    public float stopDistance=0.1f;
    public MeshRenderer mesh;
    Vector3 direction;
    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        direction = targetPosition.position-transform.position;
        float distance = direction.sqrMagnitude;  
        direction = direction.normalized;

        Debug.DrawLine(transform.position, transform.position+direction, Color.red);

        // if(distance<=stopDistance)
        //     stop=true;
        // else
        //     stop=false;

        if(distance>=stopDistance/*!stop*/)
            transform.Translate(mesh.transform.up*Time.deltaTime*movementSpeed);

        mesh.transform.up = Vector3.Slerp(mesh.transform.up, direction, rotationSpeed*Time.deltaTime);
    }
}
