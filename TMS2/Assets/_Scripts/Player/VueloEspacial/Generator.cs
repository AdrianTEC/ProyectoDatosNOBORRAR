using UnityEngine;
using Random = UnityEngine.Random;
public enum TypesOfGeneration
{
    spherical,
    point,
}

public enum OverTimeGeneration
{
    OverTime,
    OnStart
}
public class Generator : MonoBehaviour
{
    public TypesOfGeneration generationType;
    public OverTimeGeneration overTimeGeneration;
    public float Time = 5;
    private int instancias;
    public int InstanciasPorOleada;
    public int TiempoEntreOleadas;
    
    public int cuantity;
    public GameObject[] prefabs;
    public int maximunRadio;

    void Start()
    {
        if(overTimeGeneration==OverTimeGeneration.OnStart)
            Time = 0;

        switch (generationType)
        {
            case TypesOfGeneration.spherical:
                generateSpherical();
                break;
            case TypesOfGeneration.point:
                generateOnOrigin();
                break;

        }
        
        
        
        
    }
    
    void generateOnOrigin()
    {
        if (cuantity <= 0) return;
        if (instancias>= InstanciasPorOleada)
        {
            instancias = 0;
            Invoke("generateOnOrigin", TiempoEntreOleadas);
        }
        
        GameObject ast= Instantiate(prefabs[Random.Range(0, prefabs.Length - 1)],transform);
        ast.transform.position = transform.position;
        cuantity--;
        Invoke("generateOnOrigin",Time);


    }

    void generateSpherical()
    {
        if (cuantity <= 0 ) return;

        var pos = transform.position;
        
        
        
        
        
        Vector3 Pos= new Vector3(Random.Range(pos.x-maximunRadio,pos.x+maximunRadio),Random.Range(pos.y-maximunRadio,pos.y+maximunRadio),Random.Range(pos.z-maximunRadio,pos.z+maximunRadio));
        
        GameObject ast= Instantiate(prefabs[Random.Range(0, prefabs.Length - 1)]);
        ast.transform.position = Pos;
        ast.transform.parent = transform;
        cuantity--;
        Invoke("generateSpherical",Time);
    }
    
 
}

