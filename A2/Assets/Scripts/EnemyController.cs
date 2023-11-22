using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public ParticleSystem bloodSplatter;

    [SerializeField] private Transform targetPos;
    [SerializeField] private Animator animator;

    private NavMeshAgent zombie;
    private Vector3 pos;

    private void Awake()
    {
        zombie = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
        bloodSplatter = GetComponentInChildren<ParticleSystem>();
        pos.y = 0;
    }

    void Update()
    {
        zombie.destination = targetPos.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            animator.SetTrigger("Dead");
            bloodSplatter.Play();
            zombie.speed = 0.0f;
            Destroy(gameObject, 2);
        }
    }
}
