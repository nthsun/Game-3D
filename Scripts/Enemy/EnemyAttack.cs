using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour
{
    public float timeBetweenAttacks = 0.5f;
    public int attackDamage = 10;

	[HideInInspector] public SlimeDebuff SlimeDebuff;
	[SerializeField] Animator animator;						//Reference to the animator component

    Animator anim;
    GameObject player;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
    bool playerInRange;
    float timer;
	float effectsDisplayTime = 0.5f;

    void Awake ()
    {
        player = GameObject.FindGameObjectWithTag ("Player");
        playerHealth = player.GetComponent <PlayerHealth> ();
        enemyHealth = GetComponent<EnemyHealth>();
        anim = GetComponent <Animator> ();
    }


    void OnTriggerEnter (Collider other)
    {
		//Debug.Log ("OnTriggerEnter");
        if(other.gameObject == player)
        {
            playerInRange = true;
        }
    }


    void OnTriggerExit (Collider other)
    {
		//Debug.Log ("OnTriggerExit");
        if(other.gameObject == player)
        {
            playerInRange = false;
        }
    }


    void Update ()
    {
        timer += Time.deltaTime;
		//Debug.Log (timer + ", " + timeBetweenAttacks + ", " + playerInRange);

		if (timer >= timeBetweenAttacks && playerInRange && enemyHealth.currentHealth > 0 && Time.timeScale != 0) {
			Attack ();
		}

		if(timer >= timeBetweenAttacks * effectsDisplayTime)
		{
			anim.SetBool ("IsAttack", false);
		}

        if(playerHealth.currentHealth <= 0)
        {
            anim.SetTrigger ("PlayerDead");
        }
    }


	void Attack ()
    {
        timer = 0f;
		anim.SetBool ("IsAttack", true);
		if(playerHealth.currentHealth > 0&&enemyHealth.currentHealth>0)
        {
            playerHealth.TakeDamage (attackDamage);
        }

		//StartCoroutine(setMove());
		//Invoke("setMove", timeBetweenAttacks);
	}

//	void setMove()
//	{
//		anim.SetBool ("IsAttack", false);
//	}

	IEnumerator setMove() {
		anim.SetBool ("IsAttack", true);
		yield return new WaitForSeconds(timeBetweenAttacks);
		anim.SetBool ("IsAttack", false);
	}

	public void Defeated()
	{
		//If a slime debuff exists on the enemy, remove it
		if (SlimeDebuff != null)
			SlimeDebuff.ReleaseEnemy();
	}
}
