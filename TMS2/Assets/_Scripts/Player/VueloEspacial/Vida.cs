using UnityEngine;

public class Vida : MonoBehaviour, BulletInteractuable
{
    public int maximunHp;
    public int currentHp;
    public bool canReceiveDamage=true;
    
    public VidaDisplayer displayer ;
    public Death death;
    public float timeOfInmunity;
    
    public int CurrentHP {
        set
        {
            if (currentHp>value) //recibi dano
            {
                if (!canReceiveDamage) return;
                canReceiveDamage = false;
                Invoke("SetToReceiveDamage",timeOfInmunity);
            }
            currentHp = value;
            displayer.modifyVisuals(currentHp,maximunHp);
            if(currentHp<=0)
                death.act();
        }
        get => currentHp;
    }
    void Start()
    {
        displayer = GetComponent<VidaDisplayer>();
    }
    public void recibeImpact()
    {
        CurrentHP -= 1;
    }


    private void SetToReceiveDamage()
    {
        canReceiveDamage = true;
    }
}
