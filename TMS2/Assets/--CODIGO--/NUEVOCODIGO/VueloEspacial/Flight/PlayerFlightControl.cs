﻿using UnityEngine;
using TMPro;

[System.Serializable]
public class PlayerFlightControl : MonoBehaviour
{

	//"Objects", "For the main ship Game Object and weapons"));
	public GameObject actual_model; //"Ship GameObject", "Point this to the Game Object that actually contains the mesh for the ship. Generally, this is the first child of the empty container object this controller is placed in."
	public Transform weapon_hardpoint_1; //"Weapon Hardpoint", "Transform for the barrel of the weapon"
	public GameObject bullet; //"Projectile GameObject", "Projectile that will be fired from the weapon hardpoint."
	
	public TextMeshProUGUI Velocidad;
	
	
	//"Core Movement", "Controls for the various speeds for different operations."
	public float Normalspeed = 20.0f; //"Base Speed", "Primary flight speed, without afterburners or brakes"
	public float afterburner_speed = 180f; //Afterburner Speed", "Speed when the button for positive thrust is being held down"

	private float currentSpeed;
	
	
	public float thrust_transition_speed = 5f; //Thrust Transition Speed", "How quickly afterburners/brakes will reach their maximum effect"
	public float turnspeed = 15.0f; //"Turn/Roll Speed", "How fast turns and rolls will be executed "
	public float rollSpeedModifier = 7; //"Roll Speed", "Multiplier for roll speed. Base roll is determined by turn speed"
	public float pitchYaw_strength = 0.5f; //"Pitch/Yaw Multiplier", "Controls the intensity of pitch and yaw inputs"

	//"Banking", "Visuals only--has no effect on actual movement"
	
	public bool use_banking = true; //Will bank during turns. Disable for first-person mode, otherwise should generally be kept on because it looks cool. Your call, though.
	public float bank_angle_clamp = 360; //"Bank Angle Clamp", "Maximum angle the spacecraft can rotate along the Z axis."
	public float bank_rotation_speed = 3f; //"Bank Rotation Speed", "Rotation speed along the Z axis when yaw is applied. Higher values will result in snappier banking."
	public float bank_rotation_multiplier = 1f; //"Bank Rotation Multiplier", "Bank amount along the Z axis when yaw is applied."
	
	public float screen_clamp = 500; //"Screen Clamp (Pixels)", "Once the pointer is more than this many pixels from the center, the input in that direction(s) will be treated as the maximum value."

	private float normalF;
	private float amplification = 30;

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
	//---------------------------------------------------------------------------------
	
	void Start() {
		_camera = Camera.main;
		rb = GetComponent<Rigidbody>();
		mousePos = new Vector2(0,0);	
		DZ = CustomPointer.instance.deadzone_radius;
		normalF = Camera.main.fieldOfView;
		roll = 0; //Setting this equal to 0 here as a failsafe in case the roll axis is not set up.
		currentSpeed = Normalspeed;
	}

	#region SPEED CONTROL

	

	void FixedUpdate () {
		
		if (actual_model == null) {
			Debug.LogError("(FlightControls) Ship GameObject is null.");
			return;
		}
		
		
		updateCursorPosition();
		
		//Clamping the pitch and yaw values, and taking in the roll input.
		pitch = Mathf.Clamp(distFromVertical, -screen_clamp - DZ, screen_clamp  + DZ) * pitchYaw_strength;
		yaw   = Mathf.Clamp(distFromHorizontal, -screen_clamp - DZ, screen_clamp  + DZ) * pitchYaw_strength;
		if (roll_exists)
			roll = (Input.GetAxis("Roll") * -rollSpeedModifier);
			
		
		//Getting the current speed.
		currentMag = rb.velocity.magnitude;
		
		//If input on the thrust axis is positive, activate afterburners.
			if (Input.GetKey(KeyCode.W)) {
				afterburner_Active = true;
				
				var value= _camera.fieldOfView;

				if (value > normalF - amplification)
					_camera.fieldOfView -= 1;
				if (currentSpeed < afterburner_speed)
					currentSpeed+=0.5f;
				currentMag = Mathf.Lerp(currentMag, currentSpeed, thrust_transition_speed * Time.deltaTime);
				
			} 

			else {
				afterburner_Active = false;
				
				if(currentSpeed>Normalspeed)
					currentSpeed--;
				
				currentMag = Mathf.Lerp(currentMag, currentSpeed, thrust_transition_speed * Time.deltaTime);
				
				var value= _camera.fieldOfView;
				
				if (value < normalF )
					_camera.fieldOfView += 1;
			}
				
		//Apply all these values to the rigidbody on the container.
		rb.AddRelativeTorque(
			(pitch * turnspeed * Time.deltaTime),
			(yaw * turnspeed * Time.deltaTime),
			(roll * turnspeed *  (rollSpeedModifier / 2) * Time.deltaTime));
		
		rb.velocity = transform.forward * currentMag; //Apply speed
		
		if (use_banking)
			updateBanking(); //Calculate banking.
		
	}		
	#endregion
	
		
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
		newEulerAngles.z += Mathf.Clamp((-yaw * turnspeed * Time.deltaTime ) * bank_rotation_multiplier, - bank_angle_clamp, bank_angle_clamp);
		newRotation.eulerAngles = newEulerAngles;
		
		//Apply the rotation to the gameobject that contains the model.
		actual_model.transform.rotation = Quaternion.Slerp(actual_model.transform.rotation, newRotation, bank_rotation_speed * Time.deltaTime);
	
	}

	
	void Update() {
	
		if (Input.GetMouseButtonDown(0)) {
			fireShot();
		}

		var value = 11000+ currentSpeed*100;
		Velocidad.text =value.ToString();

	}
	
	
	public void fireShot() {
	
		GameObject shot1 = Instantiate(bullet, weapon_hardpoint_1.position, Quaternion.identity);
		
		Ray vRay;

		vRay = Camera.main.ScreenPointToRay(!CustomPointer.instance.center_lock ? CustomPointer.pointerPosition : new Vector2(Screen.width / 2f, Screen.height / 2f));


		RaycastHit hit;
		
		//If we make contact with something in the world, we'll make the shot actually go to that point.
		if (Physics.Raycast(vRay, out hit)) {
			shot1.transform.LookAt(hit.point);
			shot1.GetComponent<Rigidbody>().AddForce((shot1.transform.forward) * 900f,ForceMode.VelocityChange);
		
		//Otherwise, since the ray didn't hit anything, we're just going to guess and shoot the projectile in the general direction.
		} else {
			shot1.GetComponent<Rigidbody>().AddForce((vRay.direction) * 900f,ForceMode.VelocityChange);
		}
	
	}
	

}