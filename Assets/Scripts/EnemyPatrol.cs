using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public Transform[] checkPoints;
    public float movementSpeed;
    public float stopDistance=0.1f;
    private Transform target;
    private Vector3 direction;
    private int index = 0;
    private bool turnBack = false;

    AudioSource jingleToPlay;
    // Start is called before the first frame update
    void Start()
    {
        target = checkPoints[0];
        jingleToPlay = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
            
        direction = target.position-transform.position;
        float distance = direction.magnitude;
        direction = direction.normalized;

        Debug.DrawLine(transform.position, transform.position+direction, Color.red);
        if(distance<stopDistance){
            jingleToPlay.Play();
            if(index==checkPoints.Length-1)
                turnBack = true;
            else if(index==0)
                turnBack = false;

            if(!turnBack)
                index++;
            else
                index--;

            target = checkPoints[index];
        }
        transform.Translate(direction*Time.deltaTime*movementSpeed);
    }
}
