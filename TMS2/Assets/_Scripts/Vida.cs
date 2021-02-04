using System;
using _Scripts._Generales;
using UnityEngine;

namespace _Scripts{
    public class Vida : MonoBehaviour, IDamageInteractuable
    {
        public int maximunHp;
        private int currentHp;
        public bool canReceiveDamage=true;
        private ExtraBehavior extraBehavior;
        public VidaDisplayer displayer ;
        public Death death;
        public float timeOfInmunity;
        private audioManager audioManager;

        private void Start()
        {
            currentHp = maximunHp;
            extraBehavior = GetComponent<ExtraBehavior>();
            audioManager  = GetComponent<audioManager>();
        }

        private int CurrentHp { 
            set
            {
                if (currentHp>value) //recibi dano
                {
                    if (!canReceiveDamage) return;
                    canReceiveDamage = false;
                    extraBehavior?.act();
                    audioManager?.PlaySoundFor(SoundType.damage);
                    Invoke(nameof(setToReceiveDamage),timeOfInmunity);
                }
                currentHp = value;
                if(displayer!=null)
                    displayer.modifyVisuals(currentHp,maximunHp);
                if(currentHp<=0)
                    death.act();
            }
            get => currentHp;
        }
   
        public void recibeImpact(int damage)
        {
            CurrentHp -= damage;
        }


        private void setToReceiveDamage()
        {
            canReceiveDamage = true;
        }
    }
    public interface IDamageInteractuable
    {
	
        void recibeImpact(int damage);
    }
}