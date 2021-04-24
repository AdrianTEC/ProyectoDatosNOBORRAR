using Cinemachine;
using DG.Tweening;
using UnityEngine;

namespace _Scripts.SeresVivos.Player.VueloEspacial{
    public class SpaceShipLocomotion : MonoBehaviour
    {
        [Header("Flight Values")]

        public float xySpeed;
        public float forwardSpeed;
        public float maximunSpeed;
        private float currentSpeed;
   
    
        [Header("SpinMovementVariables")]
    
        public float doubleTapTime;
        public float immunityTime=.4f;

        [Header("Movement Limits ")]
        public float XmaxDistance=1.1f;
        public float YmaxDistance=1.1f;
        public float Yoffset=1.1f;
        public Vector2 relativePositionBetweenBounds;

        [Header("Camera look at correction ")]
    
        private string lastKeyPressed="";
        private CinemachineDollyCart cart;
        private Transform playerModel;
        private Collider colliderB;

        private void Start(){

            currentSpeed = forwardSpeed;
            relativePositionBetweenBounds = Vector2.zero;
            cart = transform.parent.GetComponent<CinemachineDollyCart>();
            cart.m_Speed = forwardSpeed;
            playerModel = transform.GetChild(0);
            colliderB = GetComponent<Collider>();
        
        }
        void Update()
        {
            cart.m_Speed = currentSpeed;
            doubleTapKey();
            keyPulsations();
            lookToMouse();
        }
        private void keyPulsations()
        {
            bool w = Input.GetKey(KeyCode.W);
            bool a = Input.GetKey(KeyCode.A);
            bool s = Input.GetKey(KeyCode.S);
            bool d = Input.GetKey(KeyCode.D);
            bool shift = Input.GetKey(KeyCode.LeftShift);

            //SpeedController
            if (shift){if (currentSpeed < maximunSpeed)currentSpeed++; }
            else{if (currentSpeed > forwardSpeed) currentSpeed--; }
            //MovementController
            if (!w && !a && !s && !d) return;
            Vector3 direction= new Vector3(0,0,0);
            if (w) direction += Vector3.up;
            if (a) direction +=  -Vector3.right;
            if (s) direction +=  -Vector3.up;
            if (d) direction += Vector3.right;
            move(direction);

        }
        // ReSharper disable Unity.PerformanceAnalysis
        private bool auxDoubleTapKey(string keyName, Vector3 direction)
        {
            if (Time.time < doubleTapTime + 1.5f&& lastKeyPressed.Equals(keyName))
            {
                lastKeyPressed = "";
                spinMove(direction.x+direction.y);
                return true;
            }
            lastKeyPressed = keyName;
            return false;
        }

        private bool doubleTapKey(){
            bool doublePressed;
            bool w = Input.GetKeyDown(KeyCode.W);
            bool a = Input.GetKeyDown(KeyCode.A);
            bool s = Input.GetKeyDown(KeyCode.S);
            bool d = Input.GetKeyDown(KeyCode.D);

            switch (w){
                case false when !a && !s && !d:
                    return false;
                case true:
                    doublePressed=auxDoubleTapKey("W", Vector3.up);
                    break;
                default:
                {
                    if (a)doublePressed=auxDoubleTapKey("A",-Vector3.right);
                    else if (s)doublePressed=auxDoubleTapKey("S",-Vector3.up);
                    else doublePressed=auxDoubleTapKey("D", Vector3.right);
                    break;
                }
            }

            doubleTapTime = Time.time;

            return doublePressed;

        }

    
    
    
    
    
        /// <summary>
        /// Moves the ship and verify her location  
        /// </summary>
        /// <param name="direction"></param>
        private void move(Vector3 direction){
            Transform transform1= transform;
            Vector3 translation = direction * (xySpeed * Time.deltaTime);
            Vector2 newRelativePosition = relativePositionBetweenBounds + new Vector2(translation.x, translation.y);

            if (newRelativePosition.x < -XmaxDistance || newRelativePosition.x> XmaxDistance) return;
            if (newRelativePosition.y-Yoffset < -YmaxDistance || newRelativePosition.y> YmaxDistance) return;

            relativePositionBetweenBounds += new Vector2(translation.x, translation.y);
        
            //Translation Here
            transform1 .Translate(translation);
        
        }

        private void lookToMouse(){
        
        
            Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            Plane farPlane = new Plane(Vector3.forward, Vector3.zero);
            RaycastHit hit;
            float raylenght;


            if (Physics.Raycast(cameraRay, out hit)){
                Vector3 pointToLook = hit.point;
                Debug.DrawLine(cameraRay.origin,pointToLook,Color.red);
                transform.LookAt(pointToLook);
                return;
            }
            if (farPlane.Raycast(cameraRay, out raylenght)){
                Vector3 pointToLook = cameraRay.GetPoint(raylenght);
                Debug.DrawLine(cameraRay.origin,pointToLook,Color.red);
                transform.LookAt(pointToLook);
            }
       
       
        }




        private void spinMove(float dir){
            if (DOTween.IsTweening(playerModel)) return;
            colliderB.enabled = false;
            var localEulerAngles = playerModel.localEulerAngles;
            playerModel.DOLocalRotate(new Vector3(localEulerAngles.x, localEulerAngles.y, 360 * -dir), immunityTime, RotateMode.LocalAxisAdd).SetEase(Ease.OutSine);
            Invoke(nameof(enableCollisions),immunityTime);
        }
    
    
        //auxMethodForTimer

        private void enableCollisions()
        {
            colliderB.enabled = true;
        }
    }
}   

