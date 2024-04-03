using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float panSpeed = 30f;
    public float panBorderThickness = 10f;
    public float scrollSpeed = 5f;
    public float minY = 10f;
    public float maxY = 80f;
    private bool pan = true;
    // Update is called once per frame
    void Update()
    {
        if(GameManager.gameover)
        {
            enabled = false;
            return;
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            pan = !pan;
        }

        if(!pan)
        {
            return;
        }

        if(Input.GetKey(KeyCode.W) || Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }

        if(Input.GetKey(KeyCode.S) || Input.mousePosition.y <= panBorderThickness)
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }

        if(Input.GetKey(KeyCode.A) || Input.mousePosition.x <= panBorderThickness)
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }

        if(Input.GetKey(KeyCode.D) || Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");

        Vector3 pos = transform.position;

        pos.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;
        pos.y = Math.Clamp(pos.y, minY, maxY);

        // transform.position = pos;
        //ADD SOME CLAMPS FOR PANNING
        pos.x = Math.Clamp(pos.x, -30, 100);
        pos.z = Math.Clamp(pos.z, -100, -15);
        transform.position = pos;

    }
}
