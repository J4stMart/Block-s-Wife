using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour
{
    [SerializeField]
    private TextMesh textGui;

    public GameObject deer;

    private bool inCollider;
    private BoxCollider2D collider;

    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inCollider && Input.GetKeyDown(KeyCode.P))
        {
            collider.enabled = false;

            var player = deer.transform.Find("Player");

            player.transform.parent = null;
            transform.SetParent(player);
            transform.localPosition = new Vector3(-0.7f, 0.05f);
            transform.Rotate(0, 0, 36, Space.Self);
            transform.localScale = new Vector3(-0.5f, 0.5f);

            deer.GetComponent<BoxCollider2D>().enabled = false;
            deer.GetComponent<DeerController2D>().JumpSky();
            StartCoroutine(disableDeer());

            player.GetComponent<PlayerController2D>().enabled = true;
            player.GetComponent<BoxCollider2D>().enabled = true;
            player.transform.localScale = new Vector3(Mathf.Abs(player.transform.localScale.x) * -1f, player.transform.localScale.y);
            player.GetComponent<PlayerController2D>().flipped = true;

            player.GetComponent<Player>().hasFlower = true;

            player.GetComponent<Player>().AddScore(0.2f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        textGui.text = "Press P to pick the flower";
        inCollider = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        textGui.text = "";
        inCollider = false;
    }

    private IEnumerator disableDeer()
    {
        yield return new WaitForSeconds(0.5f);

        deer.SetActive(false);
    }
}
