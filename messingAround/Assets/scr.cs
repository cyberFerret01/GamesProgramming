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

    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {


        if (!nav.pathPending && nav.remainingDistance < 5)
            GoToNextPoint();


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


}
