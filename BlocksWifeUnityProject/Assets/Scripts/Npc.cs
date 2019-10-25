using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc : MonoBehaviour
{
    [SerializeField]
    private TextMesh textGui;

    [SerializeField]
    private Dialogue dialogue1, dailogue2;
    public GameObject woman;

    public Player player;

    private bool inCollider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(inCollider && Input.GetKeyDown(KeyCode.T))
        {
            if (player.hasFlower)
                player.StartDialogue(dailogue2);
            else
                player.StartDialogue(dialogue1);

            if (woman.activeSelf)
                player.makeBridge = true;

            textGui.text = "";
            inCollider = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            textGui.text = "Press t to talk";
            inCollider = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            textGui.text = "";
            inCollider = false;
        }
    }
}
