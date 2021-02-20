using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(move());
        
    }



IEnumerator move(){


        transform.position += Vector3.up * 5 * Time.deltaTime;
 
        transform.position += Vector3.forward * 2 * Time.deltaTime;
        transform.rotation = Quaternion.Euler(0, 180, 0);
        yield return new WaitForSeconds(5);
}
}
