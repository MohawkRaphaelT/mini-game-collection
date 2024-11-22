using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml.Serialization;
using UnityEngine;
namespace MiniGameCollection.Games2024.Team07{
public class Interact : MonoBehaviour
{
    AudioManager audioManager;

    //door collision code -cc   
    private Transform door;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
        // Start is called before the first frame update
    void Start()
    {
        //gets attached gameobject -cc
        door = this.transform.Find("Door");
    }
    private void OnTriggerEnter(Collider collider){
        //sets door obj as inactive after collision -cc
        door.gameObject.SetActive(false);
        audioManager.PlaySFX(audioManager.button);
        }
    /*
    private void OnTriggerExit(Collider collider){
        //reactivates door after set time -cc
        Invoke("SetDoorTrue", 5f);
    }
    void SetDoorTrue(){
        door.gameObject.SetActive(true);
    }
    */
}
}

