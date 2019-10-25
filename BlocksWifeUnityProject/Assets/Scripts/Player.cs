using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : EnvironmentDependent
{
    [SerializeField]
    private SpriteRenderer spriteRenderer;

    public DialogueManager manager;
    public bool hasFlower = false, hasWood = false;
    public bool makeBridge = false;

    private float score = 0;

    // Start is called before the first frame update
    void Start()
    {
        EventManager.UpdateScore(score);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            AddScore(0.1f);
        } 
    }

    protected override void ChangePlayerScore(float score)
    {
        var color = spriteRenderer.color;
        color.g = score;
        color.b = score;
        spriteRenderer.color = color;
    }

    public void StartDialogue(Dialogue dialogue)
    {
        manager.StartDialogue(dialogue);
    }

    public void AddScore(float add)
    {
        score += add;

        if (score > 1)
            score = 1;

        EventManager.UpdateScore(score);
    }
}
