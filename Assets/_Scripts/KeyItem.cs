using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Valve.VR.InteractionSystem;

public class KeyItem : MonoBehaviour
{

    private bool attached = false;
    private int circleUsed = 0;

    public void Pickup() {
        attached = true;
    }

    public void Release() {
        attached = false;
    }

    private void Reposition(HandleKeyItem hole, Vector3 posit) {
        hole.has_key = true;
        Destroy(GetComponent<Throwable>());
        Destroy(GetComponent<Interactable>());
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);
        GetComponent<Rigidbody>().isKinematic = true;
        transform.position = posit;
        hole.AddKey();
    }

    void OnTriggerEnter(Collider c)
    {   
        HandleKeyItem buraco = c.gameObject.GetComponent<HandleKeyItem>();

        if(c.gameObject.tag == "buraco") {
            if(gameObject.tag == buraco.key_item.ToString() && !attached) {
                if(gameObject.tag == "circulo" && circleUsed == 0) {
                    Reposition(buraco, new Vector3(-0.7072f, 1.3668f, 0.3077f));
                    circleUsed++;
                }
            }
        }

        
    }
}
