using System;
using UnityEngine;

public class Movement : Player
{
    #region Atributos

        public int velocidad;
        public int gravity;
        private float pushPower = 2.0f;
        private float _doubleTapTime;
        private string lastKeyPressed="";
        public float dodgeDistance=150;
        private Vector3 forward, right;

        private void Start()
        {
            var transform1 = Camera.main.transform;
            forward = transform1.forward;
            forward.y = 0;
            forward = Vector3.Normalize(forward);
            right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
        }

        void FixedUpdate()
        {
            bool doublePress=DoubleTapKey();
            if(!doublePress) KeyPulsation();
            GravityAction();
        }


    

        #endregion
    #region Movimiento

    private bool AuxDoubleTapKey(string keyName, Vector3 direction)
    {
        if (Time.time < _doubleTapTime + 1.5f&& lastKeyPressed.Equals(keyName))
        {
            lastKeyPressed = "";
            IsometricDodgeMove(direction);
            return true;
        }
        lastKeyPressed = keyName;
        return false;
    }
    public bool DoubleTapKey()
    {
        bool doublePressed=false;
        var W = Input.GetKeyDown(KeyCode.W);
        var A = Input.GetKeyDown(KeyCode.A);
        var S = Input.GetKeyDown(KeyCode.S);
        var D = Input.GetKeyDown(KeyCode.D);

        if (W || A || S || D)
        {
            if      (W)doublePressed=AuxDoubleTapKey("W", Vector3.forward);
            else if (A)doublePressed=AuxDoubleTapKey("A",-Vector3.right);
            else if (S)doublePressed=AuxDoubleTapKey("S",-Vector3.forward);
            else if (D)doublePressed=AuxDoubleTapKey("D", Vector3.right);

            _doubleTapTime = Time.time;
        }
        
        return doublePressed;

    }

        void IsometricDodgeMove(Vector3 dir)
        {
            var rightMovement = right * (dodgeDistance * Time.deltaTime *dir. x);
            var upMovement = forward * (dodgeDistance * Time.deltaTime *dir.z);
            var heading = Vector3.Normalize(rightMovement + upMovement);
            transform.forward = heading;
            //transform.Translate(Vector3.forward*4);
            
            controller.Move(transform.forward *  (dodgeDistance * Time.deltaTime));

            
        }
        void IsometricMove(Vector3 dir,float speed)
        {
            var rightMovement = right * (speed * Time.deltaTime *dir. x);
            var upMovement = forward * (speed * Time.deltaTime *dir.z);
            var heading = Vector3.Normalize(rightMovement + upMovement);
            
            var transform1 = transform;
       
            
            transform1.forward = heading;
            controller.Move((rightMovement+upMovement) * (speed * Time.deltaTime));
        }


        void Move(Vector3 dir,float speed)
        {
            //_animator.SetBool(MOVING, true);
            _animator.SetFloat("Walking",1);
            IsometricMove(dir,speed);
        }

        #endregion
    #region MouseRotation

        void rotationsByMousePosition()
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            var plano = new Plane(Vector3.up, Vector3.zero);

            float rayleng;

            if (!plano.Raycast(ray, out rayleng)) return;

            var pointInMap = ray.GetPoint(rayleng);
            var pointToSee = new Vector3(pointInMap.x, transform.position.y, pointInMap.z);

            transform.LookAt(pointToSee);

        }


        #endregion
    #region Keys
    void KeyPulsation()
    {
        var W = Input.GetKey(KeyCode.W);
        var A = Input.GetKey(KeyCode.A);
        var S = Input.GetKey(KeyCode.S);
        var D = Input.GetKey(KeyCode.D);
        var E = Input.GetKey(KeyCode.E);

            
        if (W||A||S||D)
        {    
            Vector3 direction= new Vector3(0,0,0);
            if (W) direction +=  Vector3.forward;
            if (A) direction += -Vector3.right;
            if (S) direction += -Vector3.forward;
            if (D) direction +=  Vector3.right;
            Move(direction,velocidad);
        }
        else
            //_animator.SetBool(MOVING, false);
            _animator.SetFloat("Walking",0);
        if (E) Interactuar();
        
    }
    #endregion
    #region Gravedad
    void GravityAction()
    {
        if(controller.isGrounded) return;
        controller.Move(Vector3.down * (gravity * Time.deltaTime));
    }  
    #endregion
    #region Empuje
        private void OnControllerColliderHit(ControllerColliderHit hit)
        {
            Rigidbody body = hit.collider.attachedRigidbody;

            if (body == null || body.isKinematic)return;
            if (hit.moveDirection.y < -0.3) return;

            Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);
            body.velocity = pushDir * pushPower;
        }
    #endregion
 
}

