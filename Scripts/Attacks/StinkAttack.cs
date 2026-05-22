//This script handles the stink attack. The stink attack is an area of effect (AoE) attack with a long cooldown. When fired, this attack
//launches a projectile that will explode and target all of the enemies in a radius, forcing them to run away. This attack only 
//fires when you release the trigger.

using UnityEngine;

public class StinkAttack : MonoBehaviour
{
	[Header("Weapon Specs")]
	public float Cooldown = 5f;								//Cooldown of the attack

	[SerializeField] float range = 5f;						//Range of the attack

	[Header("Weapon References")]
	[SerializeField] StinkProjectile stinkProjectile;		//Reference to the stink projectile
	[SerializeField] Renderer targetReticule;				//Reference to the targetting reticule

	[Header("Reticule Colors")]
	[SerializeField] Color invalidTargetTint = Color.red;   //Color of invalid targets           
	[SerializeField] Color notReadyTint = Color.yellow;     //Color when the attack isn't ready           
	[SerializeField] Color readyTint = Color.green;			//Color of a valid target

	float timeOfLastAttack = -10f;							//The time when the attack was last made, initialized with a dummy value
	float timerAttack = 0f;
	Vector3 targetPosition;									//The position of a target
	bool inRange = false;									//Is the target in range of the attack?

	void Awake() {
		timerAttack = Cooldown;
	}

	//Called from PlayerAttack script
	public void Fire()
	{
		timerAttack = 0f;
		//If the target is in range, launch the projectile
		if(inRange)
			LaunchProjectile();
	}

	void OnEnable() {
		GameObject environment = GameObject.FindGameObjectWithTag ("Environment");
		ScenesManager.ChangeLayersRecursively (environment.transform, "Default");
	}

	void OnDisable()
	{
//		GameObject[] effects = GameObject.FindGameObjectsWithTag ("Effect");
//
//		foreach (GameObject effect in effects) {
//			effect.SetActive (false);
//		}
	}

	void Update()
	{
		timerAttack += Time.deltaTime;
		//Assume the target isn't in range
		inRange = false;
		//If we don't have a MouseLocation script in the scene or if the position of the mouse isn't valid, leave Update()
		if (Input.mousePosition == null)
			return;

		Plane plane = new Plane(Vector3.up,0);
		float dist;
		targetPosition = Input.mousePosition;

		Ray ray = Camera.main.ScreenPointToRay(targetPosition);
		if (plane.Raycast (ray, out dist)) {
			Vector3 point = ray.GetPoint (dist);
			targetPosition = point;
		}

		//Grab the current position of the mouse

		//Find the distance between the mouse and the player
		float distance = Vector3.Distance(targetPosition, transform.position);
		//If the distance is smaller than the range, then the attack is in range
		if (distance <= range)
			inRange = true;

		UpdateReticule();

		if (Input.GetButton("Fire1"))
		{
			if (timerAttack >= Cooldown) {
				Fire();
			}
		}
	}

	//This method updates the position and color of the reticule
	void UpdateReticule()
	{
		
		targetReticule.transform.position = targetPosition;


		//Debug.Log (Input.mousePosition);
		//If the attack isn't in range, set invalid tint
		if (!inRange)
			targetReticule.material.SetColor("_TintColor", invalidTargetTint);
		//If attack is on cooldown, set not ready tint
		else if (timeOfLastAttack + Cooldown > Time.time)
			targetReticule.material.SetColor("_TintColor", notReadyTint);
		//Otherwise, set ready tint
		else
			targetReticule.material.SetColor("_TintColor", readyTint);
	}

	//This method launches the projectile
	void LaunchProjectile()
	{
		//record the time of the attack
		timeOfLastAttack = Time.time;
		//Turn the projectile on
		stinkProjectile.gameObject.SetActive(true);
		//Send the projectile on its way towards the target
		stinkProjectile.StartPath(transform.position, targetPosition);
	}
}
