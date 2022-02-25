using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class HandleKeyItem : MonoBehaviour
{
    enum Key_item_expected {estrela, quadrado, circulo, triangulo};
    bool has_key = false;

    [SerializeField]
    private Key_item_expected key_item; 

    void OnTriggerEnter(Collider c)
    {
        Debug.Log(c.gameObject.tag + " has collided with " + key_item);
        // TODO: check if object is being held and only accept if it isnt
        if(c.gameObject.tag == key_item.ToString()) {
            has_key = true;
            // TODO: teleport to correct position and disable "throwable"
            c.gameObject.GetComponent<Throwable>().enabled = false;
        }
        
    }
}
