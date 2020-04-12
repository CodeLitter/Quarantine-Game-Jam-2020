using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    public Camera camera;

    private void Awake()
    {
        camera = Camera.main;
    }

    private void LateUpdate()
    {
        Vector3 forward = Vector3.ProjectOnPlane(camera.transform.forward, -Vector3.up);
        transform.transform.rotation = Quaternion.LookRotation(forward, Vector3.up);
    }
}
