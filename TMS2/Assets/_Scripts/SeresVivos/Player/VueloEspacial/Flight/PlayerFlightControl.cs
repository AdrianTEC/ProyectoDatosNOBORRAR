using System;
using _Scripts;
using UnityEngine;
using TMPro;

[Serializable]
public class PlayerFlightControl : MonoBehaviour
{
	public GameObject actual_model; //"Ship GameObject", "Point this to the Game Object that actually contains the mesh for the ship. Generally, this is the first child of the empty container object this controller is placed in."
	[Header("WeaponSystem")]
	public Transform weapon_hardpoint_1; //"Weapon Hardpoint", "Transform for the barrel of the weapon"
	public GameObject bullet; //"Projectile GameObject", "Projectile that will be fired from the weapon hardpoint."

	[Header("Visualization")]
	
	public TextMeshProUGUI Velocidad;
	public TextMeshProUGUI VelocidadRelativa;
	
	[Header("Movement")]

	public float aceleracion=0.5f;
	
	//"Core Movement", "Controls for the various speeds for different operations."
	public float Normalspeed = 20.0f; //"Base Speed", "Primary flight speed, without afterburners or brakes"
	public float afterburner_speed = 180f; //Afterburner Speed", "Speed when the button for positive thrust is being held down"
	private float currentSpeed;
	public float thrust_transition_speed = 5f; //Thrust Transition Speed", "How quickly afterburners/brakes will reach their maximum effect"
	public float turnspeed = 15.0f; //"Turn/Roll Speed", "How fast turns and rolls will be executed "
	public float rollSpeedModifier = 7; //"Roll Speed", "Multiplier for roll speed. Base roll is determined by turn speed"
	public float pitchYaw_strength = 0.5f; //"Pitch/Yaw Multiplier", "Controls the intensity of pitch and yaw inputs"

	//"Banking", "Visuals only--has no effect on actual movement"
	
	public bool useBanking = true; //Will bank during turns. Disable for first-person mode, otherwise should generally be kept on because it looks cool. Your call, though.
	public float bankAngleClamp = 360; //"Bank Angle Clamp", "Maximum angle the spacecraft can rotate along the Z axis."
	public float bankRotationSpeed = 3f; //"Bank Rotation Speed", "Rotation speed along the Z axis when yaw is applied. Higher values will result in snappier banking."
	public float bankRotationMultiplier = 1f; //"Bank Rotation Multiplier", "Bank amount along the Z axis when yaw is applied."
	
	public float screenClamp = 500; //"Screen Clamp (Pixels)", "Once the pointer is more than this many pixels from the center, the input in that direction(s) will be treated as the maximum value."

	private float normalF;
	private float amplification = 30;
	private float normal;
	private float risky ;
	private float pitchSoundConstant;
	
	[HideInInspector]
	public float roll, yaw, pitch; //Inputs for roll, yaw, and pitch, taken from Unity's input system.
	[HideInInspector]
	public bool afterburner_Active = false; //True if afterburners are on.
	
	float distFromVertical; //Distance in pixels from the vertical center of the screen.
	float distFromHorizontal; //Distance in pixel from the horizontal center of the screen.

	Vector2 mousePos = new Vector2(0,0); //Pointer position from CustomPointer
	
	float DZ = 0; //Deadzone, taken from CustomPointer.
	float currentMag = 0f; //Current speed/magnitude
	bool roll_exists = true;
	private Camera _camera;
	private Rigidbody rb;

	private Vida life;

	private AudioSource _audioSource;
	private audioManager _manager;
	
	//---------------------------------------------------------------------------------
	
	void Start() {
		_camera = Camera.main;
		rb = GetComponent<Rigidbody>();
		mousePos = new Vector2(0,0);	
		DZ = CustomPointer.instance.deadzone_radius;
		normalF = Camera.main.fieldOfView;
		roll = 0; //Setting this equal to 0 here as a failsafe in case the roll axis is not set up.
		currentSpeed = Normalspeed;

		pitchSoundConstant = 3 / afterburner_speed;

		_audioSource = GetComponent<AudioSource>();
		_manager = GetComponent<audioManager>();
		life = GetComponent<Vida>();
		normal= afterburner_speed / 3;
		risky = 2 * afterburner_speed / 3;
	}

		
	void updateCursorPosition() {

		mousePos = CustomPointer.pointerPosition;
		
		float distV = Vector2.Distance(mousePos, new Vector2(mousePos.x, Screen.height / 2));
		float distH = Vector2.Distance(mousePos, new Vector2(Screen.width / 2, mousePos.y));
		
		if (Mathf.Abs(distV) < DZ)
			distV = 0;
		else 
			distV -= DZ; 
			
		if (Mathf.Abs(distH) < DZ)
			distH = 0;	
		else 
			distH -= DZ;
			
		//Clamping distances to the screen bounds.	
		distFromVertical = Mathf.Clamp(distV, 0, (Screen.height));
		distFromHorizontal = Mathf.Clamp(distH,	0, (Screen.width));	
	
		//If the mouse position is to the left, then we want the distance to go negative so it'll move left.
		if (mousePos.x < Screen.width / 2 && distFromHorizontal != 0) {
			distFromHorizontal *= -1;
		}
		//If the mouse position is above the center, then we want the distance to go negative so it'll move upwards.
		if (mousePos.y >= Screen.height / 2 && distFromVertical != 0) {
			distFromVertical *= -1;
		}
		

	}


	void updateBanking() {

		//Load rotation information.
		Quaternion newRotation = transform.rotation;
		Vector3 newEulerAngles = newRotation.eulerAngles;
		
		//Basically, we're just making it bank a little in the direction that it's turning.
		newEulerAngles.z += Mathf.Clamp((-yaw * turnspeed * Time.deltaTime ) * bankRotationMultiplier, - bankAngleClamp, bankAngleClamp);
		newRotation.eulerAngles = newEulerAngles;
		
		//Apply the rotation to the gameobject that contains the model.
		actual_model.transform.rotation = Quaternion.Slerp(actual_model.transform.rotation, newRotation, bankRotationSpeed * Time.deltaTime);
	
	}

	
	void Update() {
	
		if (Input.GetMouseButtonDown(0)) {
			FireShot();
		}
		var relativeSpeed =  currentSpeed*100;
		var TotalSpeed = 11000 + relativeSpeed;
		
		Velocidad.text =TotalSpeed.ToString();
		VelocidadRelativa.text = relativeSpeed .ToString();

		var newPitch = currentSpeed * pitchSoundConstant;
		if (newPitch > 3) newPitch = 3;
		_audioSource.pitch =newPitch ;
		
		
		
		Color myColor;
		if (currentSpeed < normal) 
			myColor = new Color(0, 1, 0.2271903f);
		else if (currentSpeed > normal && currentSpeed < risky) 
			myColor = new Color(1, 0.9476305f, 0);	
		else 
			myColor= Color.red;
		
		VelocidadRelativa.color=myColor;
		Velocidad.color = myColor;


	}
	
	#region SPEED CONTROL

	

	void FixedUpdate () {
		
		if (actual_model == null) {
			Debug.LogError("(FlightControls) Ship GameObject is null.");
			return;
		}
		
		
		updateCursorPosition();
		
		//Clamping the pitch and yaw values, and taking in the roll input.
		pitch = Mathf.Clamp(distFromVertical, -screenClamp - DZ, screenClamp  + DZ) * pitchYaw_strength;
		yaw   = Mathf.Clamp(distFromHorizontal, -screenClamp - DZ, screenClamp  + DZ) * pitchYaw_strength;
		if (roll_exists)
			roll = (Input.GetAxis("Roll") * -rollSpeedModifier);
			
		
		//Getting the current speed.
		currentMag = rb.velocity.magnitude;
		
		//If input on the thrust axis is positive, activate afterburners.
		if (Input.GetKey(KeyCode.S)) {
			afterburner_Active = true;
				if(currentSpeed>-20)
					currentSpeed-=1f;
				
		} 
		if (Input.GetKey(KeyCode.W)) {
			afterburner_Active = true;
				
			var value= _camera.fieldOfView;

			if (value > normalF - amplification)
				_camera.fieldOfView -= aceleracion;
			if (currentSpeed < afterburner_speed)
				currentSpeed+=aceleracion;
			currentMag = Mathf.Lerp(currentMag, currentSpeed, thrust_transition_speed * Time.deltaTime);
				
		} 

		else {
			afterburner_Active = false;
				
			if(currentSpeed>Normalspeed)
				currentSpeed--;
			if(currentSpeed<Normalspeed)
				currentSpeed++;
			
			currentMag = Mathf.Lerp(currentMag, currentSpeed, thrust_transition_speed * Time.deltaTime);
				
			var value= _camera.fieldOfView;
				
			if (value < normalF )
				_camera.fieldOfView += aceleracion;
		}

		var rspeed = 20;
		if (Input.GetKey(KeyCode.D)) yaw += rspeed;
		if (Input.GetKey(KeyCode.A)) yaw -= rspeed;
		if (Input.GetKey(KeyCode.E)) roll -= rspeed;
		if (Input.GetKey(KeyCode.Q)) roll += rspeed;
		
		//Apply all these values to the rigidbody on the container.
		rb.AddRelativeTorque(
			(pitch * turnspeed * Time.deltaTime),
			(yaw * turnspeed * Time.deltaTime),
			(roll * turnspeed *  (rollSpeedModifier / 2) * Time.deltaTime));
		
		rb.velocity = (transform.forward * Mathf.Sign(currentSpeed)) * currentMag; //Apply speed
		
		if (useBanking)
			updateBanking(); //Calculate banking.
		
	}		
	#endregion

	
	public void FireShot()
	{

		_manager.PlaySoundFor(SoundType.attack);
		
		GameObject shot1 = Instantiate(bullet, weapon_hardpoint_1.position, Quaternion.identity);
		
		Ray vRay;

		vRay = Camera.main.ScreenPointToRay(!CustomPointer.instance.center_lock ? CustomPointer.pointerPosition : new Vector2(Screen.width / 2f, Screen.height / 2f));


		RaycastHit hit;
		
		//If we make contact with something in the world, we'll make the shot actually go to that point.
		Bullet bulletInfo = shot1.GetComponent<Bullet>();
		
		if (Physics.Raycast(vRay, out hit)) {
			bulletInfo.Propulse(hit);
		} else {
			bulletInfo.Propulse(vRay.direction);
		}
	
	}

	private void OnCollisionEnter(Collision other)
	{
		
		if(other.gameObject.CompareTag("Bullet")) return;
		int multiplier;
		if (currentSpeed > normal)
		{
			
			if (other.gameObject.CompareTag("enemy"))
				multiplier = 10;
			else
				multiplier = 100;
			life.CurrentHP -= (int)( (currentSpeed/afterburner_speed ) * multiplier);
		}
	}
}