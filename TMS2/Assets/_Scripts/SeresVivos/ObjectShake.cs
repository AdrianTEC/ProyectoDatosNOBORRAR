using UnityEngine;
using System.Collections;
using _Scripts._Generales;

/// http://www.mikedoesweb.com/2012/camera-shake-in-unity/

public class ObjectShake : MonoBehaviour,ExtraBehavior  {

    private Vector3 originPosition;
    private Quaternion originRotation;
    public float shake_decay = 0.002f;
    public float shake_intensity = .3f;

    private float temp_shake_intensity = 0;

 
	
    void Update (){
        if (!(temp_shake_intensity > 0)) return;
        transform.position = originPosition + Random.insideUnitSphere * temp_shake_intensity;
        transform.rotation = new Quaternion(
            originRotation.x + Random.Range (-temp_shake_intensity,temp_shake_intensity) * .2f,
            originRotation.y + Random.Range (-temp_shake_intensity,temp_shake_intensity) * .2f,
            originRotation.z + Random.Range (-temp_shake_intensity,temp_shake_intensity) * .2f,
            originRotation.w + Random.Range (-temp_shake_intensity,temp_shake_intensity) * .2f);
        temp_shake_intensity -= shake_decay;
    }
	
    void Shake(){
        var transform1 = transform;
        originPosition = transform1.position;
        originRotation = transform1.rotation;
        temp_shake_intensity = shake_intensity;

    }

    public void act(){
        Shake ();
    }
}