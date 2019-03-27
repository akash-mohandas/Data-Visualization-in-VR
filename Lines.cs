using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lines : MonoBehaviour {

    // Use this for initialization
    public GameObject lines;
    public void showLines()
    {
        lines.SetActive(true);
    }
    public void hideLines()
    {
        lines.SetActive(false);
    }
}
