using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour
{
    // Reset the game when button is clicked
    public void ResetGame()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    // toggle the pause menu when esc is pressed
    [SerializeField] private GameObject pauseMenu;
    void TogglePauseMenu()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Escape key was pressed");
            pauseMenu.SetActive(!pauseMenu.activeSelf);
        }
    }

    void Update()
    {
        TogglePauseMenu();
    }
}
