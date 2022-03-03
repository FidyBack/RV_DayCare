using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class StarCollider : MonoBehaviour
{
    void OnTriggerEnter(Collider c) {
        gameObject.GetComponent<Rigidbody>().useGravity = true;
    }
}
