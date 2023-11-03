using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemTracker : MonoBehaviour
{
    [SerializeField] GameObject Level1Door;
    [SerializeField] GameObject Level2Door;
    [SerializeField] GameObject Level3Door;
    [SerializeField] GameObject resetButton;
    
    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("winCount"))
        {
            PlayerPrefs.SetInt("winCount", 1);
        }
        if (PlayerPrefs.GetInt("winCount") == 1)
        {
            Level1Door.SetActive(true);
            Level2Door.SetActive(false);
            Level3Door.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("winCount") == 2)
        {
            Level1Door.SetActive(true);
            Level2Door.SetActive(true);
            Level3Door.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("winCount") == 3)
        {
            Level1Door.SetActive(true);
            Level2Door.SetActive(true);
            Level3Door.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("winCount") == 4)
        {
            Level1Door.SetActive(true);
            Level2Door.SetActive(true);
            Level3Door.SetActive(true);
            resetButton.SetActive(true);
        }
    }

}
