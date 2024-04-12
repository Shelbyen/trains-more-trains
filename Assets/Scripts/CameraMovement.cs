using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float scrollSpeed;
    [SerializeField] private Vector2 maxScrollRange;
    [SerializeField] private Vector2 minScrollRange;
    [SerializeField] private float zoomSpeed;
    [SerializeField] private float maxCameraZoom;
    [SerializeField] private float minCameraZoom;

    private Camera cam;
    private float vertAxis;
    private float horAxis;
    private float zoom;
    bool zoomlock = false;

    private void Awake()
    {
        cam = GetComponent<Camera>();
    }

    public void ZoomLock(bool _zoomlock)
    {
        zoomlock = _zoomlock;
    }

    private void Update()
    {
        vertAxis = Input.GetAxis("Vertical");
        horAxis = Input.GetAxis("Horizontal");
        if (!zoomlock) zoom = Input.mouseScrollDelta.y;
        cam.orthographicSize = math.clamp(cam.orthographicSize -= zoom * zoomSpeed * Time.deltaTime, maxCameraZoom, minCameraZoom);
        cam.transform.position = new Vector3(math.clamp(cam.transform.position.x, minScrollRange.x + cam.orthographicSize * 2, maxScrollRange.x - cam.orthographicSize * 2), math.clamp(cam.transform.position.y, minScrollRange.y + cam.orthographicSize / 16 * 9 * 2, maxScrollRange.y - cam.orthographicSize / 16 * 9 * 2), -10);
    }

    private void FixedUpdate()
    {
        transform.Translate(new Vector3(horAxis, vertAxis) * Time.fixedDeltaTime * cam.orthographicSize);
    }
}
