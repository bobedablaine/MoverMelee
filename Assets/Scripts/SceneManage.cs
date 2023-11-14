using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManage : MonoBehaviour
{
    [SerializeField] GameObject pauseScreen;
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject settingsScreen;
    
    private void Start()
    {
        settingsScreen.SetActive(false);
    }
    
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadHub()
    {
        SceneManager.LoadScene("Hub");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ResumeScene()
    {
        pauseScreen.SetActive(false);
        Time.timeScale = 1;
    }

    public void SettingsStartScene()
    {
        mainMenu.SetActive(false);
        settingsScreen.SetActive(true);
    }

    public void SettingsScene()
    {
        pauseScreen.SetActive(false);
        settingsScreen.SetActive(true);
    }

    public void BackScene()
    {
        settingsScreen.SetActive(false);
        pauseScreen.SetActive(true);
    }

    public void BackStartScene()
    {
        settingsScreen.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void ResetPrefs()
    {
        //PlayerPrefs.SetInt("winCount", 1);
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("MainMenu");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
