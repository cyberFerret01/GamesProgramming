using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LibrarianAI : MonoBehaviour
{
    private int overlapSize = 3;
    private Transform target;
    private uint partrol = 0;
    private NavMeshAgent nav;
    public Rigidbody PlayerRB;

  
    

    // Start is called before the first frame update
    void Start()
    {
        int col = Random.Range(1, 4);
        // make switch
        if(col == 1) GetComponent<Renderer>().material.color =  Color.red;
        if(col == 2) GetComponent<Renderer>().material.color = Color.green;
        if(col == 3) GetComponent<Renderer>().material.color = Color.blue;

        nav = GetComponent<NavMeshAgent>();
        PlayerRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        Collider[] hitColliders = Physics.OverlapSphere(transform.position, overlapSize);
        foreach (var hitCollider in hitColliders)
        {
            //FSM
            //when hitting player stop
            /*
                * below
                * Make it public
                * Once reached stop
                * Once all librarains are their delete capsule and go back to work
                */
            if (hitCollider.name.Contains("Capsule")) nav.velocity = Vector3.zero;
            //if (hitCollider.name.Contains("book")) Debug.Log(hitCollider.gameObject.GetComponent<Renderer>().material.color);
            

            }


        if (!nav.pathPending && nav.remainingDistance < 2)
        GoToNextPoint();

        //To do: reimpliment
       //StartCoroutine(move()); old bounce behaviour
    }




    void GoToNextPoint() {
        if (partrol % 2 == 0){

            string partrolTarget = "bookcase" + Random.Range(0, 11);
            target = GameObject.Find(partrolTarget).transform;

        }else{
            target = GameObject.Find("Home").transform;
        }

        nav.destination = target.position;
        partrol++;
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        //Use the same vars you use to draw your Overlap SPhere to draw your Wire Sphere.
        Gizmos.DrawWireSphere(transform.position, overlapSize);
    }

    /*IEnumerator move()
    {


        transform.position += Vector3.up * 8 * Time.deltaTime;

        transform.position += transform.forward * 2 * Time.deltaTime;
        transform.rotation = Quaternion.Euler(0, 0, 0);

        if (Mathf.Approximately(PlayerRB.velocity.y, 0))
        {
            yield return new WaitForSeconds(1);
        }
    }*/
}
