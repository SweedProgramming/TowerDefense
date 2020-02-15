﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    private bool doMovement = true;

    public float panBorderThickess = 10f;
    public float panSpeed = 30f;

    public float scrollSpeed = 5f;
    public float minY = 10;
    public float maxY = 80;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
            doMovement = !doMovement;

        if (!doMovement)
        {
            return;
        }

        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickess)
        {
            
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThickess)
        {

            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);

        }
        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickess)
        {

            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("a") || Input.mousePosition.y <= panBorderThickess)
        {

            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");

        Vector3 pos = transform.position;

        pos.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        transform.position = pos;
    }
}