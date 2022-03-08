using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Valve.VR.InteractionSystem;

public class StarCollider : MonoBehaviour
{
    
    public UnityEvent putOnPlace;

    void OnTriggerEnter(Collider c) {
        gameObject.GetComponent<Rigidbody>().useGravity = true;
        gameObject.GetComponent<Collider>().isTrigger = false;
        putOnPlace.Invoke();
    }
}
