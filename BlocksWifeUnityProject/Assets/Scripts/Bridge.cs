using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour
{
    [SerializeField]
    private TextMesh textGui;

    public Player player;
    public GameObject bridge;

    private bool inCollider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(inCollider && Input.GetKeyDown(KeyCode.B))
        {
            if(!player.hasWood)
            {
                textGui.text = "You need wood to build a bridge";
                StartCoroutine(ClearText());
            }
            else
            {
                bridge.SetActive(true);
                textGui.text = "";
                this.enabled = false;
                player.AddScore(0.2f);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        textGui.text = "Press B to build a bridge";
        inCollider = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        textGui.text = "";
        inCollider = false;
    }

    private IEnumerator ClearText()
    {
        yield return new WaitForSeconds(5f);
        textGui.text = "";
    }
}
