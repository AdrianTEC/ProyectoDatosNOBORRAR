using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;




/// <summary>
/// The FormationController.
/// Handles the Formation functionalit.
/// </summary>
/// 
public static class FormationController 
{
    
    /// <summary>
    /// The CircleFormation function.
    /// Creates a Circle Formation.
    /// </summary>
  public static void CircleFormation(float ratio,Transform father ,string obj){
        
        GameObject tempObject = new GameObject("dummy");
        tempObject.transform.forward = father.forward;
        tempObject.transform.position =father.position;
        
        Vector3 targetPosition = Vector3.zero;
        List<Transform> dummyReference = new List<Transform>();

        for (int i = 0; i < 10; i++){
            
            GameObject instance = ObjectPooler.SharedInstance.GetPooledObject(obj);
            if (instance == null) continue;

            float angle = i * (2 * 3.14159f / 10);
            float x = Mathf.Cos(angle) * ratio;
            float y = Mathf.Sin(angle) * ratio;

            targetPosition = new Vector3(targetPosition.x + x, targetPosition.y + y, 0);
            
            instance.transform.parent  = tempObject.transform;
            instance.transform.forward = father.forward;
            instance.transform.localPosition= targetPosition;
            
            instance.SetActive(true);
            dummyReference.Add(instance.transform);
        }
        foreach (Transform diosPerdonamePorEsto in dummyReference){
            diosPerdonamePorEsto.parent = null;
        }
        GameObject.Destroy(tempObject);
    }
    

 
    /// <summary>
    /// The TriangleFormation function.
    /// Creates a Triangle Formation.
    /// </summary>

     public static void triangleFormation(int rows,string obj,Transform father ,float separation){
            GameObject tempObject = new GameObject("dummy");
            tempObject.transform.forward = father.forward;
            tempObject.transform.position =father.position;
            
            Vector3 center = Vector3.zero;
            List<Transform> dummyReference = new List<Transform>();
            for (int i = 1; i < rows; i++){
                for (int j = 0; j < i; j++){
                    
                    if ( i!=rows-1 && j != i - 1 ) continue;
                    
                    Vector3 newPosition = center + new Vector3(j * separation, -i * separation, 0);
                    Vector3 newPosition2 = center + new Vector3(-j * separation, -i * separation, 0);

                    GameObject instance1 = ObjectPooler.SharedInstance.GetPooledObject(obj);
                    if (instance1 == null) continue;
                    instance1.transform.parent = tempObject.transform;
                    instance1.transform.localPosition = newPosition;
                    instance1.transform.forward = father.forward;
                    instance1.SetActive(true);
                    dummyReference.Add(instance1.transform);

                    GameObject instance2 = ObjectPooler.SharedInstance.GetPooledObject(obj);
                    if (instance2 == null) continue;
                    instance2.transform.parent = tempObject.transform;
                    instance2.transform.localPosition = newPosition2;
                    instance2.transform.forward = father.forward;
                    instance2.SetActive(true);
                    dummyReference.Add(instance2.transform);


                }

                
            
            
            
            }    
            foreach (Transform diosPerdonamePorEsto in dummyReference){
                diosPerdonamePorEsto.parent = null;
            }
            GameObject.Destroy(tempObject);
    }


    /// <summary>
    /// The HalfCircleFormation Function.
    /// Creates a Half Circle Formation.
    /// </summary>
    /// <param name="numberOfPoints">The numberOfPoints in the half circle.</param>
    /// <param name="radius">The radius of the half circle.</param>
    /// <param name="obj"></param>
    /// <param name="father"></param>
    /// <returns></returns>
    private static  List<GameObject> halfCircleFormation(int numberOfPoints, int radius,string obj,Transform father)
    {
        int pieces = numberOfPoints - 1;

        List<GameObject> spheres = new List<GameObject>();

        for(int i = 0; i < numberOfPoints; i++){
            
            GameObject instance = ObjectPooler.SharedInstance.GetPooledObject(obj);
            
            if (instance == null) continue;
            
            float theta = Mathf.PI * i / pieces;
            float X = Mathf.Cos(theta) * radius;
            float Y = Mathf.Sin(theta) * radius;
                
            
            instance.transform.position =father.position + new Vector3(X, Y, 0);
            instance.transform.forward = father.forward;
            instance.SetActive(true);
            spheres.Add(instance);

        }
        return spheres;
    }

    /// <summary>
    /// The SphereFormation function.
    /// Creates a Sphere Formation.
    /// </summary>
    /// <param name="numberOfPoints">The numberOfPoints in the sphere.</param>
    /// <param name="radius">The radius of the sphere.</param>
    /// <param name="numberOfMeridians">The number numberOfMeridians in the sphere.</param>
    /// <param name="obj"></param>
    /// <param name="father"></param>
    public static void sphereFormation(int numberOfPoints, int radius, int numberOfMeridians,string obj,Transform father)
    {
        List<GameObject> spheres = halfCircleFormation(numberOfPoints, radius,obj,father);

        

        for(int i = 1; i < numberOfMeridians; i++)
        {
            float phi = 2 * Mathf.PI * (i / (float)numberOfMeridians);

            for(int j = 1; j < numberOfPoints; j++)
            {
                
                //GameObject instance = Instantiate(obj);
                GameObject instance = ObjectPooler.SharedInstance.GetPooledObject(obj);
                
                if (instance == null) continue;
                
                float x = spheres[j].transform.position.x;
                float y = spheres[j].transform.position.y * Mathf.Cos(phi) - spheres[j].transform.position.z * Mathf.Sin(phi);
                float z = spheres[j].transform.position.z * Mathf.Cos(phi) + spheres[j].transform.position.y * Mathf.Sin(phi);
                instance.transform.position =father.position + new Vector3(x, y, z);
                instance.transform.forward = father.forward;

                instance.SetActive(true);

            }

 
        }
    }

 
    
}