using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bush : EnvironmentDependent
{
    [SerializeField]
    private float min = 0, max = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void ChangePlayerScore(float score)
    {
        var scale = Mathf.Clamp(score, min, max);
        scale = (scale - min) / (max - min);

        transform.localScale = new Vector3(scale, scale);
    }
}
