using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject spawnObject;
    public Vector3 spawnPoint;
    public int maxX = 10;
    public int timeTilNextSpawn = 1;
    int x = 0;
    float timer = 0;
    public byte instance = 0;
    GameObject[] aiList = new GameObject[255];

    void Start(){
     
        timer = 0;
        spawnPoint.x = x;
    }

    private void Update(){
       
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 10);
        foreach (var hitCollider in hitColliders){

            for (int i = 0; i < (instance - 2); i++) {

                if (aiList[i] == null){
                    continue;

                }else if(hitCollider.name == aiList[i].name){
                    Destroy(aiList[i]);
                    aiList[i] = null;
                }
            }
        }

        if (instance > 254) instance = 0;
        timer += Time.deltaTime;
        Spawn();
    }

    void Spawn()
    {
        if (timer >= timeTilNextSpawn)
        {
            x = Random.Range(0, maxX);
            spawnPoint.x = x;
            aiList[instance] = Instantiate(GameObject.Find("Librarian"), transform.position+(transform.forward*-5), Quaternion.identity);
            aiList[instance].name = "Librarian"+instance;
            instance++;
            timer = 0;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
     //Use the same vars you use to draw your Overlap SPhere to draw your Wire Sphere.
     Gizmos.DrawWireSphere(transform.position, 10);
    }

}
