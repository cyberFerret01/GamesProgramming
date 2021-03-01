using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEditor;
public class spawner : MonoBehaviour
{
    //OverlapSphere size; shared with the debugger wire sphere
    private int overlapSize = 10;
    float timer = 0;
    float timePassed = 0;
    private byte instance = 0;
    private GameObject[] aiList = new GameObject[254];
    public Slider Progress;

    bool winMsg = false;
    bool loseMeg = false;
 

    public static Color[] bookShelfOG = new Color[12];


    void Start(){

        //intro();

        for (int i = 0; i < 12; i++)
        {
            GameObject shelf = GameObject.Find("bookcase" + i);
            int col = Random.Range(1, 4);
            // make switch

            switch (col)
            {
                case 1:
                    bookShelfOG[i] = Color.red;
                    break;
                case 2:
                    bookShelfOG[i] = Color.green;
                    break;
                case 3:
                    bookShelfOG[i] = Color.blue;
                    break;
                default:
                    bookShelfOG[i] = Color.blue;
                    break;
             }
            shelf.gameObject.GetComponent<Renderer>().material.color = bookShelfOG[i];


        }

        Progress = GameObject.Find("Progress").GetComponent<Slider>();
        Progress.maxValue = 200;
        Progress.value = 100;
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
                    Progress.value += 20;
                    aiList[i] = null;
                }
            }
        }

        timer += Time.deltaTime;

        Spawn();
        timerRest();
       // winLoseCon();

        if(Mathf.Floor(timer%8) ==0) Progress.value -= 1;
    }
    /*
   void intro() {
        EditorUtility.DisplayDialog("", "Buttons: Up(Forward),Down(Back),Left/Right(Look),E - sabotage", "ok", "no");
        EditorUtility.DisplayDialog("", "Distract the librarians and sabotage the library", "ok", "no");
    }
   void winLoseCon() {
        if (Progress.value > Progress.maxValue - 1 && !loseMeg)
        {
            EditorUtility.DisplayDialog("", "you Lose!", "ok", "no");
            loseMeg = true;
        }
        if (Progress.value < Progress.minValue + 1 && !winMsg)
        {
            EditorUtility.DisplayDialog("", "you Win!", "ok", "no");
            winMsg = true;
        }
    }
    */
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

        if (timePassed +2 < timer)
        {
            aiList[instance] = Instantiate(GameObject.Find("Librarian"), transform.position+(transform.forward*-5), Quaternion.identity);
            aiList[instance].name = "Librarian"+instance;
            instance++;
            timePassed = timer;
            //Debug.Log(timer);
        }
    }

    private void OnDrawGizmos(){
     Gizmos.color = Color.red;
     //Use the same vars you use to draw your Overlap SPhere to draw your Wire Sphere.
     Gizmos.DrawWireSphere(transform.position, overlapSize);
    }

}
