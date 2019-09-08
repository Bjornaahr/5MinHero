using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlane : MonoBehaviour
{

    [SerializeField]
    Transform plane;

    [SerializeField]
    float offsetY, offsetX, distance, smoothTime;

    private Vector3 velocity = Vector3.zero;
    Vector3 targetPos;


    // Start is called before the first frame update
    void Start()
    {
        plane = GameObject.FindGameObjectWithTag("Plane").transform;
    }

    private void FixedUpdate()
    {
        //Check if the plane is at a position so we can fix the camera y position
        if (plane.position.y > 20f)
        {
            targetPos = new Vector3(plane.position.x + offsetX, plane.position.y + offsetY, distance);
        }
        else
        {
            targetPos = new Vector3(plane.position.x + offsetX, 15, distance);
        }

        //Lerps towards plane
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, smoothTime);
    }
}
