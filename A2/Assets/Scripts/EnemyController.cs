using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Transform targetPos;

    private NavMeshAgent zombie;

    private void Awake()
    {
        zombie = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        zombie.destination = targetPos.position;
    }
}
