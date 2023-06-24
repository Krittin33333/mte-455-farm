using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float minZoomDist;
    [SerializeField] private float maxZoomDist;

    [SerializeField] private float zoomspeed;
    [SerializeField] private float zoomModifier;

    [SerializeField] private float moveSpeed;

    private Camera cam;
    public CameraController instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Zoom();
        MovebyKB();
    }
    private void Zoom()
    {
        zoomModifier = Input.GetAxis("Mouse ScrollWheel");
        if (Input.GetKey(KeyCode.Z))
            zoomModifier = 0.01f;
        if (Input.GetKey(KeyCode.X))
            zoomModifier = -0.01f;

        float dist = Vector3.Distance(transform.position, cam.transform.position);

        if (dist < minZoomDist && zoomModifier > 0f)
            return;
        else if (dist > maxZoomDist && zoomModifier < 0f)
            return;

        cam.transform.position += cam.transform.forward * zoomModifier * zoomspeed;

    }
    private void MovebyKB()
    {
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        Vector3 dir = transform.forward * zInput + transform.right * xInput;
        transform.position += dir * moveSpeed * Time.deltaTime;
    }
}
