using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Valve.VR.InteractionSystem;

public class KeyItem : MonoBehaviour
{

    private bool attached = false;
    private int circleUsed, starUsed, coneUsed, cubeUsed = 0;

    public void Pickup() {
        attached = true;
    }

    public void Release() {
        attached = false;
    }

    private void Reposition(HandleKeyItem hole, Vector3 posit, Vector3 rotat) {
        hole.has_key = true;
        Destroy(GetComponent<Throwable>());
        Destroy(GetComponent<Interactable>());
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);
        GetComponent<Rigidbody>().isKinematic = true;
        transform.position = posit;
        transform.rotation = Quaternion.Euler(rotat);
        hole.AddKey();
    }

    void OnTriggerEnter(Collider c)
    {   
        HandleKeyItem buraco = c.gameObject.GetComponent<HandleKeyItem>();

        if(c.gameObject.tag == "buraco") {
            if(gameObject.tag == buraco.key_item.ToString() && !attached) {
                if(gameObject.tag == "circulo" && circleUsed == 0) {
                    Reposition(buraco, new Vector3(-0.7072f, 1.3668f, 0.3077f), new Vector3(0, 0, 0));
                    circleUsed++;
                }
                if(gameObject.tag == "estrela" && starUsed == 0) {
                    Reposition(buraco, new Vector3(-0.7065f, 1.3612f, 0.1064f), new Vector3(-3f, 0, 70f));
                    starUsed++;
                }
                if(gameObject.tag == "triangulo" && coneUsed == 0) {
                    Reposition(buraco, new Vector3(-0.722f, 1.3225f, -0.0954f), new Vector3(0, 0, -30.5f));
                    coneUsed++;
                }
                if(gameObject.tag == "quadrado" && cubeUsed == 0) {
                    Reposition(buraco, new Vector3(-0.6929f, 1.363f, -0.296f), new Vector3(0, 0, -22f));
                    cubeUsed++;
                }
            }
        }

        
    }
}
