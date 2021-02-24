﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WASDmove : MonoBehaviour
{
    //OverlapSphere size; shared with the debugger wire sphere
    private int overlapSize = 10;

    int speed = 10;
    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.Find("Camera");

        movement();

        //GameObject.Find("Area Light").transform.position = GameObject.Find("Camera").transform.position;

    }

    void movement() {

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(-transform.up * 30 * Time.deltaTime);
            //transform.position += Vector3.left * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(transform.up * 30 * Time.deltaTime);
            //transform.position += Vector3.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += transform.forward * speed * Time.deltaTime;

        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position -= transform.forward * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(-transform.up * 30 * Time.deltaTime);

        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(transform.up * 30 * Time.deltaTime);

        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        //Use the same vars you use to draw your Overlap SPhere to draw your Wire Sphere.
        Gizmos.DrawWireSphere(transform.position, overlapSize);
    }

}
