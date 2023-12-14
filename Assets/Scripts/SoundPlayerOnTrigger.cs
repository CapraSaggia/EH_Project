using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SoundPlayerOnTrigger : MonoBehaviour
{
    AudioSource audio;
    
    void Start(){
        audio = GetComponent<AudioSource>();
    }
    void OnTriggerEnter(Collider other){
        audio.Play();
    }
}
