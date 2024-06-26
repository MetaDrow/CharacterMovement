using UnityEngine;
using UnityEngine.AI;

public class EnemyPointMove : MonoBehaviour
{
    [SerializeField] private float _distanceToChangePoint;
    [SerializeField] private Transform[] _agentPoints;
    private NavMeshAgent _agent;
    private int _currentPoints = 0;

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.destination = _agentPoints[0].position;
    }


    private void Update()
    {
        if (_agent.remainingDistance < _distanceToChangePoint)
        {
            _currentPoints++;
            if (_currentPoints == _agentPoints.Length)
            {
               _currentPoints = 0;
            }
            _agent.destination = _agentPoints[_currentPoints].position;

            _agent.Move(_agent.destination * _agent.speed * Time.deltaTime);
        }
    }
}