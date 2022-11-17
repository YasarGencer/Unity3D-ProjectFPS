using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavBaker : MonoBehaviour {

    public static NavBaker Instance;
    public GameObject[] surfaces;
    public GameObject[] objectsToRotate;
    
    void Awake(){
        if(Instance == null)
            Instance = this;
        FindAll();
        BAKE();
    }
    void FindAll(){
        surfaces = GameObject.FindGameObjectsWithTag(TagManager.Instance.TagStaticNavSurface());
        objectsToRotate = GameObject.FindGameObjectsWithTag(TagManager.Instance.TagDynamicNavSurface());
        Debug.Log("Surface Info Gathered Succesfully");
    }
    public void BAKE(){
        for (int j = 0; j < objectsToRotate.Length; j++) {
            objectsToRotate[j].transform.localRotation = Quaternion.Euler (new Vector3 (0, 50*Time.deltaTime, 0) + objectsToRotate[j].transform.localRotation.eulerAngles);
        }
        for (int i = 0; i < surfaces.Length; i++) {
            surfaces[i].GetComponent<NavMeshSurface>().BuildNavMesh();    
        }
        Debug.Log("Surface (re)baked Succesfully");
    }
}