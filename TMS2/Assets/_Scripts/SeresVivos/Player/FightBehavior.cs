using _Scripts._Generales;
using _Scripts._Objetos.Armas;
using UnityEngine;

namespace _Scripts.SeresVivos.Player{
    public class FightBehavior : MonoBehaviour{
        public Animator anim;
        private Equipment equipment;
        private Movement movement;
        private static readonly int Attack = Animator.StringToHash("Attack");
        private static readonly int FireAttack = Animator.StringToHash("FireAttack");
        private static readonly int Speed = Animator.StringToHash("Speed");


        private void Start(){
            equipment = GetComponent<Equipment>();
            movement = GetComponent<Movement>();
        }


        private void Update(){
            
            if(equipment.weaponClass==null||GameInfo.InventoryIsOpen|| GameInfo.gameIsPaused) return;
            
            if (Input.GetKey(KeyCode.Mouse0 )){
                
                if (equipment.weaponClass is MeleeWeapon){ 
                    //movement.apuntando = false;

                    if (anim.GetInteger(Attack) != 0 ||anim.GetFloat(Speed)>1) return;
                    anim.SetInteger(Attack, 1);
                    anim.Play(Attack);
                }
                else{
                    equipment.weaponClass.Attack();
                }
            }
            else{
                if (equipment.weaponClass is FireWeapon){
                    //movement.apuntando = true;
                    anim.SetBool(FireAttack,false);

                }
            }
        }
    }
}
