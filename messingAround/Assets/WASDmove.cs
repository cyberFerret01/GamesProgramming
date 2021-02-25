using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WASDmove : MonoBehaviour
{
    //OverlapSphere size; shared with the debugger wire sphere
    private int overlapSize = 5;
        int speed = 10;
    Rigidbody playerRigidBody;
    Color book = Color.red;
    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = gameObject.AddComponent<Rigidbody>(); // Add the rigidbody.
        playerRigidBody.mass = short.MaxValue;
        playerRigidBody.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
       // playerRigidBody.useGravity = false;
        playerRigidBody.drag = 1;
        playerRigidBody.constraints = RigidbodyConstraints.FreezeRotation;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(playerRigidBody.collisionDetectionMode);
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, overlapSize);
        foreach (var hitCollider in hitColliders){

            if (hitCollider.name.Contains("book")) {
                if (Input.GetKey(KeyCode.E)){
                    moveBooks(hitCollider);
                    //hitCollider.gameObject.GetComponent<Renderer>().material.color = Color.red;
                    //hitCollider.gameObject.
                }
            }

        }


            movement();

        //GameObject.Find("Area Light").transform.position = GameObject.Find("Camera").transform.position;

    }

    void moveBooks(Collider bookIn) {

        Color booknew = bookIn.gameObject.GetComponent<Renderer>().material.color;
        bookIn.gameObject.GetComponent<Renderer>().material.color = book;
        book = booknew;
        

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

            playerRigidBody.AddForce(transform.forward*10 - playerRigidBody.velocity, ForceMode.VelocityChange);
           // playerRigidBody.AddForce(playerRigidBody.position + transform.forward); -- misses collisions


        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            playerRigidBody.AddForce(transform.forward * -10 - playerRigidBody.velocity, ForceMode.VelocityChange);
            //transform.position -= transform.forward * speed * Time.deltaTime;
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
