using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class scr : MonoBehaviour
{

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

        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 7);
        foreach (var hitCollider in hitColliders)
        {
            //FSM

            /*
                * below
                * Make it public
                * Once reached stop
                * Once all librarains are their delete capsule and go back to work
                */
            if(hitCollider.gameObject == GameObject.Find("Capsule")) nav.destination = GameObject.Find("Capsule").transform.position;

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
