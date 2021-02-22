using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr : MonoBehaviour
{
    public Rigidbody PlayerRB;
    private Transform target;
    // Start is called before the first frame update
    void Start()
    {
        PlayerRB = GetComponent<Rigidbody>();
        target = GameObject.Find("Capsule").transform;
    }

    // Update is called once per frame
    private Quaternion _lookRotation;
    private Vector3 _direction;
    private byte partrol = 0;

    int[] array = new int[] { 0, 1, 2, 3 };
    // Update is called once per frame
    void Update()
    {
        string partrolTarget = "bookcase" + array[partrol];
        target = GameObject.Find(partrolTarget).transform;
        Vector3 t =  target.transform.position;
        Vector3 s = transform.position;

        if (Vector3.Distance(t, s) < 5)
        {
            partrol++;
            if (partrol == array.Length) partrol = 0;
        }

        //find the vector pointing from our position to the target
        _direction = (target.position - transform.position).normalized;

        //create the rotation we need to be in to look at the target
        _lookRotation = Quaternion.LookRotation(_direction);
        // StartCoroutine(move());

        float step = 90; // calculate distance to move
        transform.rotation = Quaternion.Slerp(transform.rotation, _lookRotation, Time.deltaTime * 10000);
       StartCoroutine(move()); 

       
      
    }



IEnumerator move(){


        transform.position += Vector3.up * 8 * Time.deltaTime;
 
        transform.position += transform.forward *2 * Time.deltaTime;
        transform.rotation = Quaternion.Euler(0, 0, 0);

        if (Mathf.Approximately(PlayerRB.velocity.y, 0)) {
            yield return new WaitForSeconds(1);
        }
    }
}
