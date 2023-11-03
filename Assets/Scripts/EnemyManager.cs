using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EnemyManager : MonoBehaviour
{

    public int numOfEnemies = 0;
    [SerializeField] GameObject winScreen;
    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "LevelOne")
            numOfEnemies = 1;
        else if (SceneManager.GetActiveScene().name == "LevelTwo")
            numOfEnemies = 3;
        else if (SceneManager.GetActiveScene().name == "LevelThree")
            numOfEnemies = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (numOfEnemies <= 0)
        {
            Win();
        }
    }

    void Win()
    {
        winScreen.SetActive(true);
        if (SceneManager.GetActiveScene().name == "LevelOne" && PlayerPrefs.GetInt("winCount") <= 1)
            PlayerPrefs.SetInt("winCount", 2);
        else if (SceneManager.GetActiveScene().name == "LevelTwo" && PlayerPrefs.GetInt("winCount") == 2)
            PlayerPrefs.SetInt("winCount", 3);
        else if (SceneManager.GetActiveScene().name == "LevelThree" && PlayerPrefs.GetInt("winCount") == 3)
            PlayerPrefs.SetInt("winCount", 4);
    }
}
