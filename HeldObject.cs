using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class HeldObject : MonoBehaviour
{
    [HideInInspector]
    public Controller parent;
    public bool dropOnRelease;

    public GameObject lines;
    public void showLines()
    {
        //lines = GetComponent<GameObject>();
        //lines.SetActive(true);
    }
    public void hideLines()
    {
        //lines = GetComponent<GameObject>();
        //lines.SetActive(false);
    }

}

    


