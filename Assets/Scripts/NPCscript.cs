using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCscript : MonoBehaviour
{
    string[] npcLines = {"", "Good luck on your first journey traveller, you must go above me.", "You did it, hopefully the next one goes even smoother on the left.", "I wish you the best of luck with the boss on the right.", "You did it all, There is nothing left... except that button."};
    [SerializeField] Text npcWords;
    [SerializeField] GameObject dialogue;
    // Start is called before the first frame update
    void Start()
    {
        dialogue.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            npcWords.text = npcLines[PlayerPrefs.GetInt("winCount")];
        }
        dialogue.SetActive(true);
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        dialogue.SetActive(false);
    }
}
