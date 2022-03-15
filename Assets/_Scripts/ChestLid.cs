using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestLid : MonoBehaviour
{

    [SerializeField]
    private float speed = 1f;
    [SerializeField]
    private float max_angle = 90f;

    private bool open = false;
    private float angle = 0f;
    private int current_keys = 0;
    private int max_keys = 4;

    // Rotate the lid until it`s angle is equal to max_angle
    private void OpenLid() {
        if(angle < max_angle) {
            angle += speed;
            transform.Rotate(new Vector3(0, -speed, 0));
        }
    }

    public void AddKey() {
        current_keys++;
        Debug.Log(current_keys);
        if(current_keys == max_keys) {
            open = true;
        }
    }

    // Call OpenLid() at a fixed rate if the lid is open
    private void FixedUpdate() {
        if(open) {
            OpenLid();
        }
    }
    
}
