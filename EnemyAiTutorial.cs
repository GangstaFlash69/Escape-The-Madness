
using UnityEngine;
using UnityEngine.AI;

public class EnemyAiTutorial : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;
    public PlayerHealth ph;
    GameObject ItemSpawn;
    Transform spawnTransform;
    public GameObject ItemPref;

    public LayerMask whatIsGround, whatIsPlayer;

    public float health;

    //Patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attacking
    private int attackDamage = 10;
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    private Light shotLight;
    private LineRenderer shotLine;
    private Ray rayshot;
	private RaycastHit hit;
    private int range = 20;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    private void Awake()
    {
        shotLine = GetComponent<LineRenderer> ();
		shotLight = GetComponent<Light> ();
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        //Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange) Patroling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInAttackRange && playerInSightRange)
        {
            PlayerHealth ph = GameObject.Find("Player").GetComponent<PlayerHealth>();
            if(ph.CurHealth <= 0)
            Patroling();
        }
        else AttackPlayer();
    }

    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }
    private void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }

    private void AttackPlayer()
    {
        //Make sure enemy doesn't move
        agent.SetDestination(transform.position);

        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            ///Attack code here
            shotLight.enabled = true;
		    shotLine.enabled = true;
		    shotLine.SetPosition (0, transform.position);
		    rayshot.origin = transform.position;
		    rayshot.direction = transform.forward;
            if (Physics.Raycast (rayshot, out hit, range)) 
            {
			    PlayerHealth ph = hit.collider.GetComponent<PlayerHealth> ();
			    if (ph != null) 
                {
				  ph.GetHurt (attackDamage);
			    }
		          shotLine.SetPosition (1, hit.point);
		    } 
            else shotLine.SetPosition (1, rayshot.origin + range * rayshot.direction);

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }
    private void ResetAttack()
    {
        DisableEffect();
        alreadyAttacked = false;
    }
    void DisableEffect()
	{
		shotLight.enabled = false;
		shotLine.enabled = false;
	}

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0) Invoke(nameof(DestroyEnemy), 0.01f);
    }
    private void DestroyEnemy()
    {
        spawnTransform = gameObject.transform;
        GameObject item = Instantiate(ItemPref, spawnTransform.position, spawnTransform.rotation);
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
