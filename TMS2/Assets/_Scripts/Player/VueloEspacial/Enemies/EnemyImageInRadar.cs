
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyImageInRadar : MonoBehaviour
{
    public GameObject prefab;
    public Image senalador;
    public TextMeshProUGUI texto;
    private Transform target;
    void Start()
    {
        var PrefabObj= Instantiate(prefab, FindObjectOfType<Canvas>().transform);
        target = GameObject.FindGameObjectWithTag("Player").transform;
        
        senalador = PrefabObj.GetComponent<Image>();
        texto = PrefabObj.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        
        

    }

    void Update()
    {
        Vector3 point = Camera.main.WorldToScreenPoint(transform.position);

        if(point.z>1)
        {
            senalador.transform.position = point;
            int distance = (int) Vector3.Distance(transform.position, target.position);
            texto.text = distance + "m";
        }
        else
        {
            texto.text = "";
        }
        
    



    }

    private void OnDestroy()
    {
        if(senalador!=null)
        Destroy(senalador.gameObject);
    }
}
