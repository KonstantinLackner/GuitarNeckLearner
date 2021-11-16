using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Note : MonoBehaviour
{
    public String note;
    private bool on;

    private Question question;
    
    // Start is called before the first frame update
    void Start()
    {
        Text text = GetComponentInChildren<Text>();
        text.fontSize = 60;
        GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);
        question = GameObject.Find("Question").GetComponent<Question>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (!on) {
            GetComponent<SpriteRenderer>().color = new Color(1, 0, 0, 100);
            GetComponentInChildren<Text>().text = note;
            on = true;
            if (note.Equals(question.note))
            {
                question.notesList.Add(this);
                question.increaseRightCount();
            }
        }
        else
        {
            resetColour();
        }
        
        // StartCoroutine(resetNote());
    }

    public void resetColour()
    {
        GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);
        GetComponentInChildren<Text>().text = "";
        on = false;
    }

    /*
    private IEnumerator resetNote()
    {
        yield return new WaitForSeconds(1);
        GetComponent<SpriteRenderer>().color = Color.white;
    }
    */
}
