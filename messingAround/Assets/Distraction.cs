using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Distraction : MonoBehaviour
{
    private int overlapSize = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        byte libsDistr = 0;
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, overlapSize);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.name.Contains("Lib")) libsDistr++;
            if (libsDistr > 11) Destroy(gameObject);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        //Use the same vars you use to draw your Overlap SPhere to draw your Wire Sphere.
        Gizmos.DrawWireSphere(transform.position, overlapSize);
    }
}
