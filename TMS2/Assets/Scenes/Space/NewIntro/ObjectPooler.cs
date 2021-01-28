using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class ObjectPoolItem {
  public GameObject objectToPool;
  public int amountToPool;
  public bool shouldExpand;
  public string objectTag;
}

public class ObjectPooler : MonoBehaviour {

	public static ObjectPooler SharedInstance;
  public List<ObjectPoolItem> itemsToPool;
  public Dictionary<string,List<GameObject>> pooledObjects;

	void Awake() {
		SharedInstance = this;
        pooledObjects = new Dictionary<string, List<GameObject>>();
        foreach (ObjectPoolItem item in itemsToPool) {
            pooledObjects.Add(item.objectTag,new List<GameObject>());
      
            for (int i = 0; i < item.amountToPool; i++) {
        
                GameObject obj = Instantiate(item.objectToPool);
                obj.SetActive(false);
                pooledObjects[item.objectTag].Add(obj);
            }
        }
	}

	// Use this for initialization
  void Start () {
 
  }
	
  public GameObject GetPooledObject(string objectType) {
    
    
    List<GameObject> currentList = pooledObjects[objectType];

    for (int i = 0; i < currentList.Count; i++)
    {
      if (!currentList[i].activeInHierarchy ) 
        return pooledObjects[objectType][i];
      
    }
    return null;
  }


}
