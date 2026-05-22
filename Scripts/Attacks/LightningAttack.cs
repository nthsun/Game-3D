//This script handles the lightning attack. The lightning attack is an instant line attack that does a moderate
//amount of damage with a small cooldown.

using UnityEngine;

public class LightningAttack : MonoBehaviour
{
	[Header("Weapon Specs")]
	public float Cooldown = 1f;						//The cooldown of the attach

	[SerializeField] int damage = 20; 				//How much damage the attack does
	[SerializeField] float range = 20.0f;			//How far the attack can shoot
	[SerializeField] LayerMask strikeableMask; 		//Layermask that determines what the attack can hit

	[Header("Weapon References")]
	[SerializeField] LightningBolt lightningBolt;	//Reference to the lightningBolt script on the lightning bolt game object
	[SerializeField] AVPlayer lightningHit;			//Reference to the AVPlayer (Audio Visual Player) on the lightning hit game object

	float timerFiring = 0f;

	int shootableMask;

	void Awake ()
	{
		shootableMask = LayerMask.GetMask ("Shootable");
	}

	void OnEnable() {
		timerFiring = Cooldown;

		GameObject environment = GameObject.FindGameObjectWithTag ("Environment");
		ScenesManager.ChangeLayersRecursively (environment.transform, "Shootable");
	}

	public void Update() {
		timerFiring += Time.deltaTime;
		if (Input.GetButton("Fire1"))
		{
			if (timerFiring >= Cooldown) {
				Fire();
			}
		}
	}

	//Called from PlayerAttack script
	public void Fire()
	{
		timerFiring = 0f;
		//Create a ray from the current position and extending straight forward
		Ray ray = new Ray(transform.position, transform.forward);
		//Create a RaycastHit variable which will store information about the raycast
		RaycastHit hit;

		if(Physics.Raycast (ray, out hit, range, shootableMask))
		{
			lightningHit.transform.position = hit.point;
			//...and play the effect...
			lightningHit.Play();
			//...then set the end point of the lightning bolt..
			lightningBolt.EndPoint = hit.point;
			//...then try to get a reference to an EnemyHealth script...
			EnemyHealth enemyHealth = hit.collider.GetComponent<EnemyHealth>();

			if(enemyHealth != null)
			{
				enemyHealth.TakeDamage (damage, hit.point);
			}

		}
		else
		{
			//...place the end of the bolt at maximum range
			lightningBolt.EndPoint = ray.GetPoint(range);
		}


//		//If our raycast hits something...
//		if (Physics.Raycast(ray, out hit, range, strikeableMask))
//		{
//			//...move the lightning hit game object to the point of the hit...
//			lightningHit.transform.position = hit.point;
//			//...and play the effect...
//			lightningHit.Play();
//			//...then set the end point of the lightning bolt..
//			lightningBolt.EndPoint = hit.point;
//			//...then try to get a reference to an EnemyHealth script...
//			EnemyHealth enemyHealth = hit.collider.GetComponent<EnemyHealth>();
//			//...if the script exists...
//			if (enemyHealth != null)
//			{	
//				//...tell the enemy to take damage
//				enemyHealth.TakeDamage(damage);
//			}
//		}
		//Otherwise, if our raycast doesn't hit anything...

		//Turn the lightning bolt game object on
		lightningBolt.gameObject.SetActive(true);
	}
}
	