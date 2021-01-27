
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyImageInRadar : MonoBehaviour
{
    public GameObject prefab;
    public Image senalador;
    public TextMeshProUGUI texto;
    private Canvas _canva;
    private RectTransform CanvasRect;
    private Camera _camera;

    void Start()
    {
        _camera = Camera.main;
        _canva = FindObjectOfType<Canvas>();
        CanvasRect = _canva.GetComponent<RectTransform>();
        var prefabObj= Instantiate(prefab, _canva.transform);
        
        senalador=prefabObj.GetComponent<Image>();
        texto = prefabObj.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
      
        
        Vector3 point = Camera.main.WorldToScreenPoint(transform.position);

            senalador.rectTransform.anchoredPosition= point;
          //  int distance = (int) Vector3.Distance(transform.position, target.position);
           // texto.text = distance + "m";
       
        
        
        
    }



    

    private void OnDestroy()
    {
        if(senalador!=null)
            Destroy(senalador.gameObject);
    }
}
