using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaplingTrigger : MonoBehaviour
{
    private Tree parentScript;

    // Start is called before the first frame update
    void Start()
    {
        parentScript = gameObject.GetComponentInParent<Tree>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        parentScript.OnTriggerEnterSapling(collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        parentScript.OnTriggerExitSapling(collision);
    }
}
