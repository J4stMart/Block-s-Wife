using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : EnvironmentDependent
{
    [SerializeField]
    private TextMesh textGui;

    [SerializeField]
    private float saplingScore = 0.2f;
    [SerializeField]
    private float treeScore = 1.1f;

    public Player player;

    private bool inColliderTree = false, inColliderSapling = false;
    private GameObject sapling, tree;

    // Start is called before the first frame update
    void Start()
    {
        sapling = transform.Find("Sapling").gameObject;
        tree = transform.Find("Tree").gameObject;
        tree.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        /*if (inColliderTree && Input.GetKeyDown(KeyCode.Z))
        {
            Destroy(gameObject);
        }*/

        if (inColliderSapling && Input.GetKeyDown(KeyCode.X))
        {
            GrowTree();
            player.AddScore(0.2f);
        }
    }

    private void GrowTree()
    {
        sapling.SetActive(false);
        tree.SetActive(true);
    }

    public void OnTriggerEnterSapling(Collider2D collision)
    {
        textGui.text = "Press X to grow the tree";
        inColliderSapling = true;
    }

    public void OnTriggerExitSapling(Collider2D collision)
    {
        textGui.text = "";
        inColliderSapling = false;
    }

   /* public void OnTriggerEnterTree(Collider2D collision)
    {
        textGui.text = "Press Z to destroy the tree";
        inColliderTree = true;
    }

    public void OnTriggerExitTree(Collider2D collision)
    {
        textGui.text = "";
        inColliderTree = false;
    }*/

    protected override void ChangePlayerScore(float score)
    {
        if (score >= treeScore)
            GrowTree();

        if (!tree.activeSelf)
            sapling.SetActive(score > saplingScore);
    }
}
