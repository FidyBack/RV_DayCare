using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimonSaysButtons : MonoBehaviour
{
    // Color for when the button is off
    [SerializeField]
    private Color offColor;

    // Color for when the button is on
    [SerializeField]
    private Color onColor;

    public void PlayColor()
    {
        // Change the color of the button
        GetComponent<Renderer>().material.color = onColor;
        // Play the sound
        // GetComponent<AudioSource>().Play();

        // Wait for the sound to finish playing
        StartCoroutine(WaitForSound());
    }

    IEnumerator WaitForSound()
    {
        // yield return new WaitForSeconds(GetComponent<AudioSource>().clip.length);
        yield return new WaitForSeconds(.5f);
        // Change the color of the button
        GetComponent<Renderer>().material.color = offColor;
    }

    void Start()
    {
        // Change the color of the button
        GetComponent<Renderer>().material.color = offColor;
    }


}
