using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class spawner : MonoBehaviour
{
    //OverlapSphere size; shared with the debugger wire sphere
    private int overlapSize = 10;
    float timer = 0;
    float timePassed = 0;
    private byte instance = 0;
    private GameObject[] aiList = new GameObject[254];
    public Slider Progress;


    void Start(){
        Progress = GameObject.Find("Progress").GetComponent<Slider>();
        Progress.value = Progress.maxValue;
        timer = 0;

    }

    private void Update(){

        Collider[] hitColliders = Physics.OverlapSphere(transform.position, overlapSize);
        foreach (var hitCollider in hitColliders){

            for (int i = 0; i < (instance - 2); i++) {

                if (aiList[i] == null){
                    continue;

                }else if(hitCollider.name == aiList[i].name){
                    Destroy(aiList[i]);
                    Progress.value += 10;
                    aiList[i] = null;
                }
            }
        }

        timer += Time.deltaTime;
        Spawn();
        timerRest();

        
       
    }

    void timerRest() {

        //stops timers/counters from going beyond their max val

        if (instance + 1 >= byte.MaxValue)  instance = 0;

        if (timer + 10 >= float.MaxValue){
            timer = 0;
            timePassed = 0;
        }


    }

    void Spawn()
    {

        /*
         * time 1 second
         * spawn
         * time passed = 1
         * is 10 less than 1
         */

        if (timePassed +5 < timer)
        {
            aiList[instance] = Instantiate(GameObject.Find("Librarian"), transform.position+(transform.forward*-5), Quaternion.identity);
            aiList[instance].name = "Librarian"+instance;
            instance++;
            timePassed = timer;


            if (Mathf.Floor(timer % 10) == 0) Progress.value -= 10;
            Debug.Log(timer);
        }
    }

    private void OnDrawGizmos(){
     Gizmos.color = Color.red;
     //Use the same vars you use to draw your Overlap SPhere to draw your Wire Sphere.
     Gizmos.DrawWireSphere(transform.position, overlapSize);
    }

}
