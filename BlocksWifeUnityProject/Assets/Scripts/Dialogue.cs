using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Sentence
{
    public bool left;
    public string text;
}

[System.Serializable]
public class Dialogue {

    public string nameLeft, nameRight;
	//[TextArea(3, 10)]
	public Sentence[] sentences;

}
