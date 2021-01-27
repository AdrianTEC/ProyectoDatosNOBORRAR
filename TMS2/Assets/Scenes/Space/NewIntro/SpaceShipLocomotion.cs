using Cinemachine;
using UnityEngine;
using DG.Tweening;
public class SpaceShipLocomotion : MonoBehaviour
{
    [Header("Flight Values")]

    public float XY_SPEED;
    public float forwardSPEED;
    public float MaxDistance=1.1f;
    
    [Header("SpinMovementVariables")]
    
    public float _doubleTapTime;
    public float _immunityTime=.4f;



    private string lastKeyPressed="";
    private CinemachineDollyCart _cart;
    private Vector3 ScreenBounds;
    private Camera cam;
    private Rigidbody _rigidbody;
    private Transform _playerModel;
    private Collider _collider;
    
    
    void Start()
    {
        ScreenBounds = new Vector3(Screen.width, Screen.height, 0);
        cam = Camera.main;
        _rigidbody = GetComponent<Rigidbody>();
        _cart = transform.parent.GetComponent<CinemachineDollyCart>();
        _cart.m_Speed = forwardSPEED;
        _playerModel = transform.GetChild(0);
        _collider = GetComponent<Collider>();
    }
    void Update()
    {
        DoubleTapKey();
        KeyPulsations();
    }
    private void KeyPulsations()
    {
        bool w = Input.GetKey(KeyCode.W);
        bool a = Input.GetKey(KeyCode.A);
        bool s = Input.GetKey(KeyCode.S);
        bool d = Input.GetKey(KeyCode.D);
        bool shift = Input.GetKey(KeyCode.LeftShift);

        if (w || a || s || d)
        { 
            Vector3 direction= new Vector3(0,0,0);
            if (w) direction += Vector3.up;
            if (a) direction +=  -Vector3.right;
            if (s) direction +=  -Vector3.up;
            if (d) direction += Vector3.right;
            Move(direction);
        }

    }
    private bool AuxDoubleTapKey(string keyName, Vector3 direction)
    {
        if (Time.time < _doubleTapTime + 1.5f&& lastKeyPressed.Equals(keyName))
        {
            lastKeyPressed = "";
            SpinMove(direction.x+direction.y);
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
            if      (W)doublePressed=AuxDoubleTapKey("W", Vector3.up);
            else if (A)doublePressed=AuxDoubleTapKey("A",-Vector3.right);
            else if (S)doublePressed=AuxDoubleTapKey("S",-Vector3.up);
            else if (D)doublePressed=AuxDoubleTapKey("D", Vector3.right);

            _doubleTapTime = Time.time;
        }
        
        return doublePressed;

    }
    private void Move(Vector3 direction)
    {
        Vector3 traslation = direction * (XY_SPEED * Time.deltaTime);
        Vector3 realPosition = transform.position;
        Vector3 newRelativePosition=  cam.WorldToScreenPoint(realPosition + traslation);
        
        bool conditionInX = newRelativePosition.x < ScreenBounds.x*(1-MaxDistance) || newRelativePosition.x > ScreenBounds.x*MaxDistance;
        bool conditionInY = newRelativePosition.y < 0 || newRelativePosition.y > ScreenBounds.y*MaxDistance;
        
        
        if(conditionInX || conditionInY) return;

        
        transform.Translate(traslation);
        //_rigidbody.AddForce(direction,ForceMode.VelocityChange);
        
        
        //correction for keeping the object between the screen bounds
        
       
    }
    private void SpinMove(float dir)
    {
        if (!DOTween.IsTweening(_playerModel))
        {
            
            _collider.enabled = false;
            _playerModel.DOLocalRotate(new Vector3(_playerModel.localEulerAngles.x, _playerModel.localEulerAngles.y, 360 * -dir), _immunityTime, RotateMode.LocalAxisAdd).SetEase(Ease.OutSine);
            Invoke("enableCollisions",_immunityTime);
        }
    }
    
    
    //auxMethodForTimer

    private void enableCollisions()
    {
        _collider.enabled = true;
    }
}   

