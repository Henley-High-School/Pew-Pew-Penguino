using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour

{

    public GameObject pauseMenu;
    public GameObject controlsScreen;

    private bool paused = false;
    
    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
       
        
    }

    // Update is called once per frame
    void Update()
    {
        if (paused==false)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Pause();
                
             
            }
        }
        else if (paused == true)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                UnPause();
                
            }
        }


        
    }

    // keep this as separate method to open pause menu, but also actually pause time, enemy etc
    public void Pause()
    {
        pauseMenu.SetActive(true);
        controlsScreen.SetActive(false);
        paused = true;
        Debug.Log("Pause");
    }

    public void UnPause()
    {
        pauseMenu.SetActive(false);
        controlsScreen.SetActive(false);
        paused = false;
        Debug.Log("UnPause");
    }

    public void ResumeButton()
    {
        pauseMenu.SetActive(false);
        paused = false;
    }

    public void ControlsButton()
    {
        pauseMenu.SetActive(false);
        controlsScreen.SetActive(true);
    }

    public void ExitButton()
    {
        SceneManager.LoadScene("L0.StartScene");
    }

    public void NewGameButton()
    {
        SceneManager.LoadScene("L1.Australia");
    }



}
