using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Valve.VR.InteractionSystem;

public class KeyItem : MonoBehaviour
{

    private bool attached = false;
    public UnityEvent putOnPlace;

    public void Pickup() {
        attached = true;
    }

    public void Release() {
        attached = false;
    }

    void OnTriggerEnter(Collider c)
    {
        HandleKeyItem buraco = c.gameObject.GetComponent<HandleKeyItem>();
        // Debug.Log(gameObject.tag + " " + buraco.key_item + " " + attached);
        if(gameObject.tag == buraco.key_item.ToString() && !attached) {
            buraco.has_key = true;
            Destroy(gameObject.GetComponent<Throwable>());
            Destroy(gameObject.GetComponent<Interactable>());
            gameObject.GetComponent<Rigidbody>().useGravity = false;
            gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
            putOnPlace.Invoke();

        }
        
    }
}
