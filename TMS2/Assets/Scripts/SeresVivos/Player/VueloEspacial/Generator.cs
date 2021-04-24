using UnityEngine;
using Random = UnityEngine.Random;
public enum TypesOfGeneration
{
    spherical,
    point,
    longitudinal
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
    public bool randomRotation;
    public int longitude; //only for longitudinal generation

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
            case  TypesOfGeneration.longitudinal:
                generateLongitudinal();
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
        
        GameObject ast= Instantiate(prefabs[Random.Range(0, prefabs.Length )]);
        ast.transform.position = Pos;
        ast.transform.parent = transform;
        if(randomRotation) ast.transform.rotation= Quaternion.Euler(Random.Range(0,90),Random.Range(0,90),Random.Range(0,90));
        cuantity--;
        Invoke("generateSpherical",Time);
    }


    private void generateLongitudinal(){
        Vector3 centre = transform.position;
        
        if (cuantity <= 0) return;
        for (int z= 0; z< longitude; z++){
         
            for (int y = 0; y < maximunRadio; y++){
        
                for (int x = 0; x < maximunRadio; x++){
                    if(cuantity<=0)
                        break;

                    int value=120;
                    float zsep = Random.Range(-value,value);
                    float ysep = Random.Range(-value,value);
                    float xsep = Random.Range(-value,value);
                    
                    
                    GameObject ast= Instantiate(prefabs[Random.Range(0, prefabs.Length - 1)] );
                    ast.transform.position = centre+ new Vector3(x*xsep,y*ysep,z*zsep);
                    ast.transform.parent= transform;
                    cuantity--;
                    
                    
                    
                } 
                
            }
            
            
            
            
        }


}

}

