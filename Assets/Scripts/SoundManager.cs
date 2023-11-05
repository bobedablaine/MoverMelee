using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SoundManager : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("volume"))
        {
            PlayerPrefs.SetFloat("volume", 0.5f);
            LoadVolume();
        }
        else
            LoadVolume();
        
    }

    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
        SaveVolume();
    }

    public void LoadVolume()
    {
        
        volumeSlider.value = PlayerPrefs.GetFloat("volume");
    }

    private void SaveVolume()
    {
        PlayerPrefs.SetFloat("volume", volumeSlider.value);
    }
    
}
