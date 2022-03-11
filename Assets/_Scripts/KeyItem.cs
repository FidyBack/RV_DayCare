using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Valve.VR.InteractionSystem;

public class KeyItem : MonoBehaviour
{

    private bool attached = false;

    public void Pickup() {
        attached = true;
    }

    public void Release() {
        attached = false;
    }

    void OnTriggerEnter(Collider c)
    {   
        HandleKeyItem buraco = c.gameObject.GetComponent<HandleKeyItem>();

        if(c.gameObject.tag == "buraco") {
            if(gameObject.tag == buraco.key_item.ToString() && !attached) {
                buraco.has_key = true;
                Destroy(GetComponent<Throwable>());
                Destroy(GetComponent<Interactable>());
                GetComponent<Rigidbody>().useGravity = false;
                GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                GetComponent<Rigidbody>().isKinematic = true;
                transform.position = buraco.hole_transform.position;
                
                buraco.AddKey();

            }
        }

        
    }
}
