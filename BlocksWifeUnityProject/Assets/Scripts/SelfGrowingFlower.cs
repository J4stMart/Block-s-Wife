using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfGrowingFlower : EnvironmentDependent
{
    private SpriteRenderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        renderer.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void ChangePlayerScore(float score)
    {
        if (score >= 1)
        {
            renderer.enabled = true;
        }
    }
}
