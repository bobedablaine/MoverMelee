using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCscript : MonoBehaviour
{
    string[] npcLines = {"Good luck on your first journey traveller.", "You did it, hopefully the next one goes even smoother."};
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
            npcWords.text = npcLines[0];
        }
        dialogue.SetActive(true);
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        dialogue.SetActive(false);
    }
}
