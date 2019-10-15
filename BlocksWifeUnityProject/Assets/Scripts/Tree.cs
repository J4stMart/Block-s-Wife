using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    [SerializeField]
    private BoxCollider2D collider;
    [SerializeField]
    private TextMesh textGui;

    private bool inCollider = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(inCollider && Input.GetKeyDown(KeyCode.Z))
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        textGui.text = "Press Z to destroy the tree";
        inCollider = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        textGui.text = "";
        inCollider = false;
    }
}
