
using _Scripts._Generales;
using UnityEngine;


namespace _Scripts.SeresVivos.Player{
    public class Movement : global::Player{
        
        [Header("movement constants")]
        public int velocidad;
        public float multiplicator;
        public int gravity;
        public float propulseSpeed;

        private readonly float pushPower = 2.0f;
        private float doubleTapTime;
        
        private string lastKeyPressed = "null";
        public bool apuntando;
        
        private bool propulsed;
        private Vector3 propulsedDir;
        
        
        private Vector3 forward, right;
        private static readonly int Speed = Animator.StringToHash("Speed");
        private audioManager manager;
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
            if (_animator.GetInteger("Attack")==0) doubleTapKey();
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
        private bool auxDoubleTapKey(string keyName, Vector3 direction){
            Debug.Log(keyName +"  "+ lastKeyPressed +"   "  + (Time.time - doubleTapTime));

            if (Time.time < doubleTapTime+ .9f && lastKeyPressed.Equals(keyName)){
                lastKeyPressed = Random.Range(0,100).ToString();
                isometricDodgeMove(direction);
                return true;
            }
            doubleTapTime = Time.time;
            lastKeyPressed = keyName;
            return false;
        }
        
        
        
        /// <summary>
        /// dettects Double Keys
        /// </summary>
        /// <returns></returns>
        private bool doubleTapKey(){
            bool doublePressed= false;
            bool w = Input.GetKeyDown(KeyCode.W);
            bool a = Input.GetKeyDown(KeyCode.A);
            bool s = Input.GetKeyDown(KeyCode.S);
            bool d = Input.GetKeyDown(KeyCode.D);
            if(w||a||s||d){
                
                
                if (w) doublePressed      = auxDoubleTapKey("W", Vector3.forward);
                else if (a) doublePressed = auxDoubleTapKey("A", -Vector3.right);
                else if (s) doublePressed = auxDoubleTapKey("S", -Vector3.forward);
                else if (d) doublePressed = auxDoubleTapKey("D", Vector3.right);
                

            }
            return doublePressed;
        }




        private void isometricDodgeMove(Vector3 dir){
            _animator.Play("roll");
            propulsedDir = transform.forward ;
            propulsed = true;
            Invoke(nameof(stopPropulstion),.5f);
        }

        public void isometricMove(Vector3 dir, float speed){
            Vector3 rightMovement = right * (speed * Time.deltaTime * dir.x);
            Vector3 upMovement = forward * (speed * Time.deltaTime * dir.z);
            Vector3 heading = Vector3.Normalize(rightMovement + upMovement);

            Transform transform1 = transform;

            if(!apuntando)
                transform1.forward = heading;
            controller.Move((rightMovement + upMovement) * (speed * Time.deltaTime));
        }

        public void dodge(Vector3 dir, float speed){
            controller.Move(dir* (speed * Time.deltaTime));
        }

        private void move(Vector3 dir, float speed){
            bool shift = Input.GetKey(KeyCode.LeftShift);
            if (shift&& (!_animator.GetBool("FireAttack") && _animator.GetInteger("Attack") == 0)){
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
            controller.Move(Vector3.down * (gravity * Time.deltaTime));
        }
        
        /// <summary>
        /// Controls push other objects
        /// </summary>
        /// <param name="hit"></param>
        private void OnControllerColliderHit(ControllerColliderHit hit){
            Rigidbody body = hit.collider.attachedRigidbody;

            if (body == null || body.isKinematic) return;
            if (hit.moveDirection.y < -0.3) return;

            Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);
            body.velocity = pushDir * pushPower;
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

/*
       private bool auxDoubleTapKey(string keyName, Vector3 direction){
            if (Time.time < doubleTapTime + 1.5f && lastKeyPressed.Equals(keyName)){
                lastKeyPressed = "null";
                isometricDodgeMove(direction);
                return true;
            }
            lastKeyPressed = keyName;
            return false;
        }

        private bool doubleTapKey(){
            bool doublePressed= false;
            bool w = Input.GetKeyDown(KeyCode.W);
            bool a = Input.GetKeyDown(KeyCode.A);
            bool s = Input.GetKeyDown(KeyCode.S);
            bool d = Input.GetKeyDown(KeyCode.D);
          
            if (w) doublePressed = auxDoubleTapKey("W", Vector3.forward);
            if (a) doublePressed = auxDoubleTapKey("A", -Vector3.right);
            if (s) doublePressed = auxDoubleTapKey("S", -Vector3.forward);
            if (d) doublePressed = auxDoubleTapKey("D", Vector3.right);
            doubleTapTime = Time.time;
            return doublePressed;
        }
*/