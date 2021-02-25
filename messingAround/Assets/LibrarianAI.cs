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
    private string partrolTarget = "bookcase0";
    private bool regularPatrol = true;
    private GameObject [] newstop = new GameObject[3];
    private Color actualColor = Color.red;
    private int q = 0;


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
            int caseNo = 1;
            //FSM
            //when hitting player stop
            /*
                * below
                * Make it public
                * Once reached stop
                * Once all librarains are their delete capsule and go back to work
                */
            if (hitCollider.name.Contains("Capsule")) nav.velocity = Vector3.zero;
            if (hitCollider.name.Contains("book") && hitCollider.name == partrolTarget && q >1)
            {
                newstop[1].gameObject.GetComponent<Renderer>().material.color = actualColor;
            }

                if (hitCollider.name.Contains("book") && hitCollider.name == partrolTarget) {

                //bookcase(00)
                string[] str = hitCollider.name.Split('e');

                //Debug.Log(str[1]);

                try{
                    caseNo = int.Parse(str[1]);
                }
                catch {
                    Debug.LogError("Lib found non bookcase");
                }

                Color [] duplicatedArray = spawner.bookShelfOG;

                actualColor = duplicatedArray[caseNo];
                if (hitCollider.gameObject.GetComponent<Renderer>().material.color == actualColor){
                    //Debug.Log("Correct colour");
                }else{
                    Debug.Log("Wrong colour");

                    for (int j =0; j < duplicatedArray.Length; j++) {

                        if (actualColor == duplicatedArray[j] && j != caseNo) {
                            string imGoinTo = "bookcase" + j;
                            //Debug.LogWarning(imGoinTo);
                            newstop[0] = GameObject.Find(imGoinTo);
                            newstop[1] = hitCollider.gameObject;
                            regularPatrol = false;
                            
                            break;
                        }
                    
                    }


                    //go to correct shelf
                    //come back
                    //correct colour
                }


            }
            

            }


        if (!nav.pathPending && nav.remainingDistance < overlapSize-1)
        GoToNextPoint();

        //To do: reimpliment
       //StartCoroutine(move()); old bounce behaviour
    }




    void GoToNextPoint() {
        if (regularPatrol)
        {
            if (partrol % 2 == 0)
            {

                partrolTarget = "bookcase" + Random.Range(0, 11);
                target = GameObject.Find(partrolTarget).transform;

            }
            else
            {
                target = GameObject.Find("Home").transform;
            }

            nav.destination = target.position;
            partrol++;
        }else{

            nav.destination = newstop[q].transform.position;
            q++;
            if (q == 2){

                regularPatrol = true; 
            }


        }
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
