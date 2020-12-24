
using UnityEngine;
using UnityEngine.UI;

public class EnemyImageInRadar : MonoBehaviour
{
    public GameObject prefab;
    public Image senalador;
    void Start()
    {
        senalador = Instantiate(prefab, FindObjectOfType<Canvas>().transform).GetComponent<Image>();
        GetComponent<enemySpaceAttack>().senal = senalador;

    }

    void Update()
    {
        Vector3 point = Camera.main.WorldToScreenPoint(transform.position);

        if(point.z>0)
            senalador.transform.position = point;




    }
}
