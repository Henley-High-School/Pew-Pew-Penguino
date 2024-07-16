using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class SceneLoader : MonoBehaviour
{
    public GameObject settingsScreen;
    public GameObject startScreen;
    public GameObject controlsScreen;
    public GameObject bgImage;

    // Start is called before the first frame update
    void Start()
    {
        startScreen.SetActive(true); 
        settingsScreen.SetActive(false);
        controlsScreen.SetActive(false);

    }

    public void NewGameButton()
    {
        bgImage.SetActive(false);
        startScreen.SetActive(false);
        SceneManager.LoadScene("L1.Australia");
        
    }

    public void SettingsButton()
    {
        settingsScreen.SetActive(true);
        startScreen.SetActive(false);
        controlsScreen.SetActive(false);
    }

    public void LoadGameButton()
    {
        Debug.Log("Load Game");
    }

    public void ControlsButton()
    {
        controlsScreen.SetActive(true); 
        settingsScreen.SetActive(false);
    }

    public void StartScreenButton()
    {
        startScreen.SetActive(true);
        controlsScreen.SetActive(false);
        settingsScreen.SetActive(false);
    }




}
