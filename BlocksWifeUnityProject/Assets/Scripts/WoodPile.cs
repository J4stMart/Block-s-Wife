using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodPile : MonoBehaviour
{
    [SerializeField]
    private TextMesh textGui;

    public Player player;

    private bool inCollider;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (inCollider && Input.GetKeyDown(KeyCode.G))
        {
            player.hasWood = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        textGui.text = "Press G to grab some wood";
        inCollider = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        textGui.text = "";
        inCollider = false;
    }
}
