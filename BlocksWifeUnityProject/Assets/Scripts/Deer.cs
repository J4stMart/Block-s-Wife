using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deer : EnvironmentDependent
{
    public BoxCollider2D collider;
    public MountDeer mount;

    public float environmentScore = 0.8f;
    public bool move = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x > 7.7f && move)
        {
            transform.Translate(Vector3.left * 2.5f * Time.deltaTime);
        }
        else if(transform.position.x <= 7.7f)
        {
            mount.enabled = true;
            collider.enabled = true;
            this.enabled = false;
        }
    }

    protected override void ChangePlayerScore(float score)
    {
        if (score >= environmentScore)
        {
            GetComponent<SpriteRenderer>().enabled = true; 
        }
    }
}
