using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float scrollSpeed;
    [SerializeField] private float vertScrollRange;
    [SerializeField] private float horScrollRange;
    [SerializeField] private float zoomSpeed;
    [SerializeField] private float maxCameraZoom;
    [SerializeField] private float minCameraZoom;

    private Camera cam;
    private float vertAxis;
    private float horAxis;
    private float zoom;

    private void Awake()
    {
        cam = GetComponent<Camera>();
    }

    private void Update()
    {
        vertAxis = Input.GetAxis("Vertical");
        horAxis = Input.GetAxis("Horizontal");
        zoom = Input.mouseScrollDelta.y;
        cam.orthographicSize = math.clamp(cam.orthographicSize -= zoom * zoomSpeed * Time.deltaTime, maxCameraZoom, minCameraZoom);
    }

    private void FixedUpdate()
    {
        transform.Translate(new Vector3(horAxis, vertAxis) * Time.fixedDeltaTime * cam.orthographicSize);
    }
}
