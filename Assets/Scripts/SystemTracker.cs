using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemTracker : MonoBehaviour
{
    public int LevelCount = 1;
    [SerializeField] GameObject Level1Door;
    
    BoxCollider2D level1Col;
    // Start is called before the first frame update
    void Start()
    {
        level1Col = Level1Door.GetComponent<BoxCollider2D>();   
    }

    // Update is called once per frame
    void Update()
    {
           
    }

    // void OnCollisionEnter2D(Collision2D col)
    // {
    //     if (col.gameObject.CompareTag("Player"));
    // }
}
