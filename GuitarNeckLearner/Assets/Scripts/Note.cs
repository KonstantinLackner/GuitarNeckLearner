using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Note : MonoBehaviour
{
    public String note;
    private bool on;
    
    // Start is called before the first frame update
    void Start()
    {
        Text text = GetComponentInChildren<Text>();
        text.fontSize = 60;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (!on) {
            GetComponent<SpriteRenderer>().color = Color.red;
            GetComponentInChildren<Text>().text = note;
            on = true;
        }
        else
        {
            GetComponent<SpriteRenderer>().color = Color.white;
            GetComponentInChildren<Text>().text = "";
            on = false;
        }
        
        // StartCoroutine(resetNote());
    }

    /*
    private IEnumerator resetNote()
    {
        yield return new WaitForSeconds(1);
        GetComponent<SpriteRenderer>().color = Color.white;
    }
    */
}
