using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Question : MonoBehaviour
{
    private String[] notes = {"A", "A#", "B", "C", "C#", "D", "D#", "E", "F", "F#", "G", "G#"};
    private String[] notesNoSharps = {"A", "B", "C", "D", "E", "F", "G"};
    public String note;
    public int rightCount;
    public List<Note> notesList;
    private bool sharps;

    // Start is called before the first frame update
    void Start()
    {
        notesList = new List<Note>();
        sharps = true;
        GenerateRandomNote();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void increaseRightCount()
    {
        rightCount++;
        if (rightCount == 6)
        {
            StartCoroutine(noteCountAndNoteReset());
        }
    }

    public void GenerateRandomNote()
    {
        String currentNote = note;
        if (sharps)
        {
            int randomNoteIndex = Random.Range(0, 11);
            note = notes[randomNoteIndex];
        }
        else
        {
            int randomNoteIndex = Random.Range(0, 6);
            note = notesNoSharps[randomNoteIndex];
        }
        
        GetComponentInChildren<Text>().text = note;
        rightCount = 0;
        
        if (note.Equals(currentNote))
        {
            GenerateRandomNote();
        }
    }
    
    private IEnumerator noteCountAndNoteReset()
    {
        yield return new WaitForSeconds(1);
        rightCount = 0;
        foreach (var note in notesList)
        {
            note.resetColour();
        }

        notesList = new List<Note>();
        GenerateRandomNote();
    }

    private void OnMouseUp()
    {
        if (sharps)
        {
            sharps = false;
            GameObject.Find("questionBackground").GetComponent<SpriteRenderer>().color = new Color(0, 0.9f, 1, 1);
            GameObject.Find("SharpsToggle").GetComponent<Text>().text = "no sharps";
        }
        else
        {
            sharps = true;
            GameObject.Find("questionBackground").GetComponent<SpriteRenderer>().color = Color.white;
            GameObject.Find("SharpsToggle").GetComponent<Text>().text = "sharps";
        }
    }
}
