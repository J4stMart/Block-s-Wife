using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcDeerTrigger : EnvironmentDependent
{
    public float deerScore = 0.8f;
    public GameObject deer, npc;

    private bool canSpawnDeer = false, spawnedDeer = false, spawnedNpc = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!spawnedNpc)
        {
            npc.SetActive(true);
            spawnedNpc = true;
        }
        else if(canSpawnDeer && !spawnedDeer)
        {
            deer.GetComponent<Deer>().move = true;
            spawnedDeer = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        
    }

    protected override void ChangePlayerScore(float score)
    {
        if (score >= deerScore)
            canSpawnDeer = true;
    }
}
