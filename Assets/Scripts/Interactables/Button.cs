using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : Interactable
{
[SerializeField]
    private GameObject door;
    private bool doorOpen;
    void Start(){

    }
    void Update(){

    }
    // Start is called before the first frame update
    protected override void Interact(){
        doorOpen =!doorOpen;
        door.GetComponent<Animator>().SetBool("IsOpen",doorOpen);
        Debug.Log("Interacted with"+ gameObject.name);
    }
}
