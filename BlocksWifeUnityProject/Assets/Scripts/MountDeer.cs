using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MountDeer : MonoBehaviour
{
    [SerializeField]
    private TextMesh textGui;

    public GameObject player;
    public BoxCollider2D collider;
    public DeerController2D controller;

    private bool inCollider;
    private PlayerController2D controllerPlayer;

    // Start is called before the first frame update
    void Start()
    {
        controllerPlayer = player.GetComponent<PlayerController2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inCollider && Input.GetKeyDown(KeyCode.M))
        {
            collider.isTrigger = false;
            controller.enabled = true;

            controllerPlayer.enabled = false;
            player.GetComponent<BoxCollider2D>().enabled = false;
            player.transform.SetParent(gameObject.transform);
            player.transform.localPosition = new Vector3(0.1f, 0.082f, 0);
            if (controllerPlayer.flipped)
                player.transform.localScale = new Vector3(player.transform.localScale.x * -1f, player.transform.localScale.y);

            textGui.text = "";
            inCollider = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            textGui.text = "Press m to ride the deer";
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
