using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private float smoothTimeY = 0.1f;
    [SerializeField]
    private float smoothTimeX = 0.1f;

    [SerializeField]
    private GameObject player;
    [SerializeField]
    private bool enforceBounds = true;

    [SerializeField]
    private BoxCollider2D bounds;

    private Vector2 minCameraPosition, maxCameraPosition;
    private Vector2 velocity;

    private Camera camera;

    // Start is called before the first frame update
    void Start()
    {
        camera = GetComponent<Camera>();
        UpdateBounds();
    }

    // Update is called once per frame
    void Update()
    {
        float posX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref velocity.x, smoothTimeX);
        float posY = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref velocity.y, smoothTimeY);

        if (enforceBounds)
        {
            posX = Mathf.Clamp(posX, minCameraPosition.x, maxCameraPosition.x);
            posY = Mathf.Clamp(posY, minCameraPosition.y, maxCameraPosition.y);
        }

        transform.position = new Vector3(posX, posY, transform.position.z);

    }

    private void UpdateBounds()
    {
        minCameraPosition = new Vector2(bounds.bounds.min.x + camera.orthographicSize * camera.aspect, bounds.bounds.min.y + camera.orthographicSize);
        maxCameraPosition = new Vector2(bounds.bounds.max.x - camera.orthographicSize * camera.aspect, bounds.bounds.max.y - camera.orthographicSize);
    }
}
