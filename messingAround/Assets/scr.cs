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


        if (!nav.pathPending && nav.remainingDistance < 5)
            GoToNextPoint();

       // StartCoroutine(move());
    }


    int[] array = new int[] { 0, 1, 2, 3 };


        void GoToNextPoint(){
        if (partrol > 3){

            partrol = 0;
        }


        string partrolTarget = "bookcase" + array[partrol];
        target = GameObject.Find(partrolTarget).transform;

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
