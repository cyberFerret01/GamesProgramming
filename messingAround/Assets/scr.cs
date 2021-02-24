using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class scr : MonoBehaviour
{

    private Transform target;
    private Quaternion _lookRotation;
    private Vector3 _direction;
    private byte partrol = 0;

    public Transform[] points;
    private NavMeshAgent nav;
    private int destPoint;


    public Rigidbody PlayerRB;
    

    // Start is called before the first frame update
    void Start()
    {
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


            if (!nav.pathPending && nav.remainingDistance < 5)
            GoToNextPoint();

       // StartCoroutine(move());
    }


    int[] array = new int[] { 0, 1, 2, 3, 4, 5, 6,7,8,9,10,11 };


    void GoToNextPoint() {
        if (partrol % 2 == 0)
        {
            string partrolTarget = "bookcase" + Random.Range(0, 11);
            target = GameObject.Find(partrolTarget).transform;
        }
        else {

        target = GameObject.Find("Home").transform;
        }

        nav.destination = target.position;
        partrol++;
    }

    IEnumerator move()
    {


        transform.position += Vector3.up * 8 * Time.deltaTime;

        transform.position += transform.forward * 2 * Time.deltaTime;
        transform.rotation = Quaternion.Euler(0, 0, 0);

        if (Mathf.Approximately(PlayerRB.velocity.y, 0))
        {
            yield return new WaitForSeconds(1);
        }
    }
}
