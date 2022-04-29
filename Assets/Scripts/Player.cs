using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Player : MonoBehaviour{
    private NavMeshAgent _agent;

    public void MoveTo(Vector3 point) => _agent.SetDestination(point);

    private void Awake() => _agent = GetComponent<NavMeshAgent>();
}