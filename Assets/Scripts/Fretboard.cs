using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fretboard : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        LinkedList<Transform> strings = new LinkedList<Transform>();
        foreach (Transform child in transform)
        {
            strings.AddLast(child);
        }
        
        LinkedList<Note> notes = new LinkedList<Note>();
        foreach (Transform stringTransform in strings)
        {
            foreach (Transform child in stringTransform)
            {
                notes.AddLast(child.GetComponent<Note>());
            }
        }

        foreach (var note in notes)
        {
            note.GetComponentInChildren<Text>().text = "";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
