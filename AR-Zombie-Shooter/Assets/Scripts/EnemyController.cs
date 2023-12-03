using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Transform targetPos;
    [SerializeField] private Animator animator;
    [SerializeField] private ParticleSystem bloodSplatter;
    [SerializeField] private CapsuleCollider zombieCollider;
    [SerializeField] private AudioSource zombieNoise;
    [SerializeField] private AudioSource zombieAttack;

    private NavMeshAgent zombie;
    private Vector3 pos;

    private void Awake()
    {
        zombie = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
        bloodSplatter = GetComponentInChildren<ParticleSystem>();
        zombieCollider = GetComponent<CapsuleCollider>();
    }

    void Update()
    {
        zombie.destination = targetPos.position;
        pos.y = -2.0f;

        if(PlayerController.PlayerIsDead)
        {
            zombieNoise.Stop();
            zombie.speed = 0.0f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            ZombieCollidesSomething();
            ZombieDies();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            ZombieCollidesSomething();
            ZombieBites();
        }
    }

    private void ZombieDies()
    {
        animator.SetTrigger("Dead");
        zombieCollider.enabled = false;
        Destroy(gameObject, 1);
    }

    private void ZombieBites()
    {
        animator.SetTrigger("Attack");
        zombieAttack.Play();
    }

    private void ZombieCollidesSomething()
    {
        bloodSplatter.Play();
        zombie.speed = 0.0f;
    }
}
