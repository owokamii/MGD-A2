using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Transform targetPos;

    private NavMeshAgent zombie;
    private Vector3 pos;

    private void Awake()
    {
        zombie = GetComponent<NavMeshAgent>();
        pos.y = 0;
    }

    void Update()
    {
        zombie.destination = targetPos.position;
    }
}
