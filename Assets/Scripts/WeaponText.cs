using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponText : MonoBehaviour
{
    string instructions = "Press 'f' while over a weapon to pick it up";
    [SerializeField] Text weapontext;
    [SerializeField] GameObject textbox;

    // Start is called before the first frame update
    void Start()
    {
        weapontext.text = instructions;
        textbox.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        textbox.SetActive(true);
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        textbox.SetActive(false);
    }
}
