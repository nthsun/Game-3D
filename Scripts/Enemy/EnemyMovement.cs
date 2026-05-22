using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    Transform player;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
    UnityEngine.AI.NavMeshAgent nav;

	float originalSpeed;
	bool isRunningAway;
	Vector3 runAwayPosition;

	[HideInInspector] public FrostDebuff FrostDebuff;

	[Header("Components")]
	[SerializeField] UnityEngine.AI.NavMeshAgent navMeshAgent;
	[SerializeField] Animator animator;

	[SerializeField] float runAwayDistance = 10f;

    void Awake ()
    {
        player = GameObject.FindGameObjectWithTag ("Player").transform;
        playerHealth = player.GetComponent <PlayerHealth> ();
        enemyHealth = GetComponent <EnemyHealth> ();
        nav = GetComponent <UnityEngine.AI.NavMeshAgent> ();
    }
		
    void Update ()
    {
		if (!isRunningAway) {
			if(enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0)
			{
				nav.SetDestination (player.position);
			}
			else
			{
				nav.enabled = false;
			}
		}
    }

	public void Freeze()
	{
		//Stop animating
		animator.enabled = false;
		//Record the navmesh agent's speed (will be needed later)
		originalSpeed = navMeshAgent.speed;
		//Stop the navmesh agent
		navMeshAgent.speed = 	0f;
	}

	public void UnFreeze()
	{
		//Start animating again
		animator.enabled = true;
		//Set the speed back to it's original value
		navMeshAgent.speed = originalSpeed;
	}

	//This method is called when the enemy is hit by a stink attack
	public void Runaway()
	{
		//The enemy is now running away
		isRunningAway = true;
		//Get a vector from the player's position to the enemy's position
		Vector3 runVector = 5*(transform.localPosition - player.position);
		//Use the runVector to run directly away from the player
		navMeshAgent.SetDestination(runVector);
	}

	public void ComeBack()
	{
		//No longer running away
		isRunningAway = false;
	}

	public void setSpeed(float speed) {
		navMeshAgent.speed = speed;
	}
}
