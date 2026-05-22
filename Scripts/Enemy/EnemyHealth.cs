using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;
    public float sinkSpeed = 2.5f;
    public int scoreValue = 10;
    public AudioClip deathClip;


    Animator anim;
    AudioSource enemyAudio;
    ParticleSystem hitParticles;
    CapsuleCollider capsuleCollider;
	EnemyAttack enemyAttack;
	ItemManager itemManager;
    bool isDead;
    bool isSinking;
	float timer=0f;
	float effectsDisplayTime = 0.3f;

	//public GameObject[] items;

    void Awake ()
    {
        anim = GetComponent <Animator> ();
        enemyAudio = GetComponent <AudioSource> ();
        hitParticles = GetComponentInChildren <ParticleSystem> ();
        capsuleCollider = GetComponent <CapsuleCollider> ();
		enemyAttack = GetComponent<EnemyAttack>();
		itemManager = GetComponent<ItemManager> ();
        currentHealth = startingHealth;
    }


    void Update ()
    {
		timer += Time.deltaTime;
        if(isSinking)
        {
            transform.Translate (-Vector3.up * sinkSpeed * Time.deltaTime);
        }

		if(timer >= effectsDisplayTime)
		{
			removeDisableEffectsDamage ();
		}
    }


    public void TakeDamage (int amount, Vector3 hitPoint)
    {
        if(isDead)
            return;
		timer = 0f;
		anim.SetBool ("IsDamage", true);

        enemyAudio.Play ();

        currentHealth -= amount;
            
        hitParticles.transform.position = hitPoint;
        hitParticles.Play();

        if(currentHealth <= 0)
        {
            Death ();
        }
    }

	public void TakeDamage (int amount)
	{
		if(isDead)
			return;
		timer = 0f;
		anim.SetBool ("IsDamage", true);

		enemyAudio.Play ();

		currentHealth -= amount;

		if(currentHealth <= 0)
		{
			Death ();
		}
	}

	public void removeDisableEffectsDamage() {
		anim.SetBool ("IsDamage", false);
	}

    void Death ()
    {
        isDead = true;

        capsuleCollider.isTrigger = true;

        anim.SetTrigger ("Dead");
		enemyAttack.Defeated ();
        enemyAudio.clip = deathClip;
//		enemyAudio.volume = (float)ScenesManager.getParam ("audioSource");
        enemyAudio.Play ();
		StartSinking ();
		Destroy (gameObject, 2f);
		itemManager.fallItem();
    }

	public bool getIsDeath() {
		return isDead;
	}
		

    public void StartSinking ()
    {
        GetComponent <UnityEngine.AI.NavMeshAgent> ().enabled = false;
        GetComponent <Rigidbody> ().isKinematic = true;
        isSinking = true;
        ScoreManager.score += scoreValue;
        Destroy (gameObject, 2f);
    }
}
