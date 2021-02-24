using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class spawner : MonoBehaviour
{
    //OverlapSphere size; shared with the debugger wire sphere
    private int overlapSize = 10;
    float timer = 0;
    private byte instance = 0;
    private GameObject[] aiList = new GameObject[254];
    public Slider Progress;


    void Start(){
        Progress = GameObject.Find("Progress").GetComponent<Slider>();
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
    }

    void Spawn()
    {
        if (instance +1 >= byte.MaxValue)
        {
            instance = 0;
        }

        if (timer >= 5)
        {
            aiList[instance] = Instantiate(GameObject.Find("Librarian"), transform.position+(transform.forward*-5), Quaternion.identity);
            aiList[instance].name = "Librarian"+instance;
            instance++;
            timer = 0;
        }
    }

    private void OnDrawGizmos(){
     Gizmos.color = Color.red;
     //Use the same vars you use to draw your Overlap SPhere to draw your Wire Sphere.
     Gizmos.DrawWireSphere(transform.position, overlapSize);
    }

}
