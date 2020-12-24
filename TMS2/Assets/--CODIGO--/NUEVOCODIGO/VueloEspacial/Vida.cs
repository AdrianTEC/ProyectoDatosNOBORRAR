using UnityEngine;

public class Vida : MonoBehaviour, BulletInteractuable
{
    public int maximunHp;
    public int currentHp;
    public bool canReceiveDamage=true;
    
    public VidaDisplayer displayer ;
    
    public int CurrentHP {
        set
        {
            if (currentHp>value) //recibi dano
            {
                if (!canReceiveDamage) return;
                canReceiveDamage = false;
                Invoke("SetToReceiveDamage",1);
            }
            currentHp = value;
            displayer.modifyVisuals(currentHp,maximunHp);
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
