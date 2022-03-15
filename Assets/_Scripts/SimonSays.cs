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
    private bool already_played = false;

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
        }
        return c;
    }

    IEnumerator PlaySequence(Colors[] c) {
        yield return new WaitForSeconds(2.5f);
        for(int i = 0; i < sequence_size; i++){
            if     (c[i] == Colors.red   ) playRed.Invoke();
            else if(c[i] == Colors.blue  ) playBlue.Invoke();
            else if(c[i] == Colors.green ) playGreen.Invoke();
            else if(c[i] == Colors.yellow) playYellow.Invoke();
            yield return new WaitForSeconds(.6f);
        }
    }

    IEnumerator PlaySequenceWin() {
        for(int i = 0; i < 10; i++){
            playRed.Invoke();
            playBlue.Invoke();
            playGreen.Invoke();
            playYellow.Invoke();
            yield return new WaitForSeconds(.2f);
        }
    }

    IEnumerator Welcome() {
        for(int i = 0; i < 2; i++){
            playRed.Invoke();
            yield return new WaitForSeconds(.25f);
            playBlue.Invoke();
            yield return new WaitForSeconds(.25f);
            playGreen.Invoke();
            yield return new WaitForSeconds(.25f);
            playYellow.Invoke();
            yield return new WaitForSeconds(.25f);
        }
    }

    void OnTriggerEnter(Collider collider) {
        if(collider.gameObject.tag != "Player") return;

        StartCoroutine(Welcome());

        Colors[] c = GenerateNewSequence();
        expected = c;
        StartCoroutine(PlaySequence(c));
    }

    public void ReceiveInput(string input) {
        if(already_played) {
            return;
        }

        if(input != expected[index].ToString()) {
            index = 0;
            playRed.Invoke();
            playBlue.Invoke();
            playGreen.Invoke();
            playYellow.Invoke();
            StartCoroutine(PlaySequence(expected));
            flagErro = 0;
            return;
        }
        if(index == sequence_size-1) {
            Instantiate(triangle, spawn_position.position, Quaternion.identity);
            StartCoroutine(PlaySequenceWin());
            already_played = true;
        } else {
            index++;
        }
    }
}
