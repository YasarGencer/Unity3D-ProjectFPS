using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavBaker : MonoBehaviour {

    public static NavBaker Instance;
    private GameObject[] _surfaces;
    public GameObject[] _objectsToRotate;
    
    void Awake(){
        if(Instance == null)
            Instance = this;
        FindAll();
        BAKE();
    }
    void FindAll(){
        _surfaces = GameObject.FindGameObjectsWithTag(TagManager.Instance.TagStaticNavSurface());
        _objectsToRotate = GameObject.FindGameObjectsWithTag(TagManager.Instance.TagDynamicNavSurface());
        Debug.Log("Surface Info Gathered Succesfully");
    }
    public void BAKE(){
        for (int j = 0; j < _objectsToRotate.Length; j++) {
            _objectsToRotate[j].transform.localRotation = Quaternion.Euler (new Vector3 (0, 50*Time.deltaTime, 0) + _objectsToRotate[j].transform.localRotation.eulerAngles);
        }
        for (int i = 0; i < _surfaces.Length; i++) {
            _surfaces[i].GetComponent<NavMeshSurface>().BuildNavMesh();    
        }
        Debug.Log("Surface (re)baked Succesfully");
    }
}