
using _Scripts._Generales;
using UnityEngine;


namespace _Scripts.SeresVivos.Player{
    public class Movement : global::Player{
        
        [Header("movement constants")]
        public float velocidad=0.1f;
        public float multiplicator;
        public float gravity;
        public float propulseSpeed;
        public float maxTimeForDoubleTap = 1f;
        private readonly float pushPower = 2.0f;
        private float doubleTapTime;
        
        private string lastKeyPressed = "null";
        public bool apuntando;
        
        private bool propulsed;
        private Vector3 propulsedDir;
        
        
        private Vector3 forward, right;
        private static readonly int Speed = Animator.StringToHash("Speed");
        private audioManager manager;

        private static readonly int Attack = Animator.StringToHash("Attack");
        private static readonly int FireAttack = Animator.StringToHash("FireAttack");

        //-------------------------------------------------->
        //-------------------------------------------------->
        //-------------------------------------------------->
        private void Start(){
            if (Camera.main is{ }){
                Transform transform1 = Camera.main.transform;
                forward = transform1.forward;
            }

            manager = GetComponent<audioManager>();
            forward.y = 0;
            forward = Vector3.Normalize(forward);
            right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
        }

        private void Update(){
            optionalKeyPulsation();
            if (_animator.GetInteger(Attack)==0) doubleTapKey();
        }

        private void FixedUpdate(){
            if(GameInfo.InventoryIsOpen || GameInfo.gameIsPaused) return;
            
           
            if (apuntando) rotationsByMousePosition();
            if (propulsed) dodge(propulsedDir,propulseSpeed);
            
            
            keyPulsation();
            gravityAction();
        }
        //-------------------------------------------------->
        //-------------------------------------------------->
        //-------------------------------------------------->

        




        private void optionalKeyPulsation(){
            bool e = Input.GetKey(KeyCode.E);
            bool tab = Input.GetKeyDown(KeyCode.Tab);
            if (tab){
                apuntando = !apuntando;
                manager.PlaySoundFor(SoundType.config);
            }
            if (e) Interactuar();
        }
        /// <summary>
        /// dettects wasd pulsation
        /// </summary>
        private void keyPulsation(){
            bool w = Input.GetKey(KeyCode.W);
            bool a = Input.GetKey(KeyCode.A);
            bool s = Input.GetKey(KeyCode.S);
            bool d = Input.GetKey(KeyCode.D);
            if (w || a || s || d){
                Vector3 direction = new Vector3(0, 0, 0);
                if (w) direction += Vector3.forward;
                if (a) direction += -Vector3.right;
                if (s) direction += -Vector3.forward;
                if (d) direction += Vector3.right;
                move(direction, velocidad);
            }
            else
                _animator.SetFloat(Speed, 0);
        }


        /// <summary>
        /// verifies if double key was succes
        /// </summary>
        /// <param name="keyName"></param>
        /// <param name="direction"></param>
        /// <returns></returns>
        private void auxDoubleTapKey(string keyName, Vector3 direction){

            if (Time.time < doubleTapTime+ maxTimeForDoubleTap && lastKeyPressed.Equals(keyName)){
                lastKeyPressed = Random.Range(0,100).ToString();
                isometricDodgeMove(direction);
                return;
            }
            doubleTapTime = Time.time;
            lastKeyPressed = keyName;
        }
        
        
        
        /// <summary>
        /// dettects Double Keys
        /// </summary>
        /// <returns></returns>
        private void doubleTapKey(){
            bool w = Input.GetKeyDown(KeyCode.W);
            bool a = Input.GetKeyDown(KeyCode.A);
            bool s = Input.GetKeyDown(KeyCode.S);
            bool d = Input.GetKeyDown(KeyCode.D);
            switch (w){
                case false when !a && !s && !d:
                    return;
                case true:
                    auxDoubleTapKey("W", Vector3.forward);
                    break;
                default:
                {
                    if (a) auxDoubleTapKey("A", -Vector3.right);
                    else if (s) auxDoubleTapKey("S", -Vector3.forward);
                    else if (d) auxDoubleTapKey("D", Vector3.right);
                    break;
                }
            }
        }




        private void isometricDodgeMove(Vector3 dir){
            _animator.Play("roll");
            
            Vector3 rightMovement = right * (  dir.x);
            Vector3 upMovement = forward * (  dir.z);
            Vector3 heading = Vector3.Normalize(rightMovement + upMovement);
            propulsedDir = heading;
            propulsed = true;
            Invoke(nameof(stopPropulstion),.5f);
        }

        public void isometricMove(Vector3 dir, float speed){
            Vector3 rightMovement = right * (speed  * dir.x);
            Vector3 upMovement = forward * (speed* dir.z);
            Vector3 heading = Vector3.Normalize(rightMovement + upMovement);

            Transform transform1 = transform;

            if(!apuntando)
                transform1.forward = heading;
            
            controller.Move((rightMovement + upMovement) * (speed ));
        }

        public void dodge(Vector3 dir, float speed){
            controller.Move(dir* (speed ));
        }

        private void move(Vector3 dir, float speed){
            bool shift = Input.GetKey(KeyCode.LeftShift);
            if (shift&& (!_animator.GetBool(FireAttack) && _animator.GetInteger(Attack) == 0)){
                speed *= multiplicator;
                _animator.SetFloat(Speed, 1);
            }
            else
                _animator.SetFloat(Speed, .5f);
            isometricMove(dir, speed);
        }
        
        
        
        /// <summary>
        /// emulate gravity
        /// </summary>
        private void gravityAction(){
            if (controller.isGrounded) return;
            controller.Move(Vector3.down * (gravity ));
        }
        
        /// <summary>
        /// Controls push other objects
        /// </summary>
        /// <param name="hit"></param>
        private void OnControllerColliderHit(ControllerColliderHit hit){
            Rigidbody attachedRigidbody = hit.collider.attachedRigidbody;

            if (attachedRigidbody == null || attachedRigidbody.isKinematic) return;
            if (hit.moveDirection.y < -0.3) return;

            Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);
            attachedRigidbody.velocity = pushDir * pushPower;
        }


        /// <summary>
        /// rotates the player lo mousePosition
        /// </summary>
        private void rotationsByMousePosition(){
            if (Camera.main is{ }){
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                Plane plano = new Plane(Vector3.up, Vector3.zero);

                if (!plano.Raycast(ray, out float rayleng)) return;

                Vector3 pointInMap = ray.GetPoint(rayleng);
                Vector3 pointToSee = new Vector3(pointInMap.x, transform.position.y, pointInMap.z);

                transform.LookAt(pointToSee);
            }
        }

        private void stopPropulstion(){
            propulsed = false;
        }
        
        
    }
}
