using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SimonSays : MonoBehaviour
{
    public int sequence_size = 5;
    private int index = 0;
    public enum Colors {red, blue, green, yellow};
    private Colors[] expected;

    public GameObject triangle;
    public Transform spawn_position;

    public UnityEvent playRed;
    public UnityEvent playBlue;
    public UnityEvent playGreen;
    public UnityEvent playYellow;

    Colors[] GenerateNewSequence() {
        Colors[] c = new Colors[sequence_size];
        for(int i = 0; i < sequence_size; i++){
            c[i] = (Colors)Random.Range(0, 4);
            Debug.Log(c[i]);
        }
        return c;
    }

    void PlaySequence(Colors[] c) {
        for(int i = 0; i < sequence_size; i++){
            if     (c[i] == Colors.red   ) playRed.Invoke();
            else if(c[i] == Colors.blue  ) playBlue.Invoke();
            else if(c[i] == Colors.green ) playGreen.Invoke();
            else if(c[i] == Colors.yellow) playYellow.Invoke();
        }
    }

    void OnTriggerEnter(Collider collider) {
        if(collider.gameObject.tag != "Player") return;

        Colors[] c = GenerateNewSequence();
        expected = c;
        PlaySequence(c);
    }

    public void ReceiveInput(string input) {
        if(input != expected[index].ToString()) {
            index = 0;
            PlaySequence(expected);
            return;
        }
        if(index == sequence_size) {
            Instantiate(triangle, spawn_position.position, Quaternion.identity);
        }
    }
}
