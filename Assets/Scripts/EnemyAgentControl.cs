using UnityEngine;
using UnityEngine.AI;

public class EnemyAgentControl : MonoBehaviour
{
    [Header("Agent")]
    [SerializeField] private NavMeshAgent agent = null;

    [Header("Look at hero")] 
    [SerializeField] private bool lookAtHero = false;
    
    private GameObject _hero = null;
    
    private void Start() => _hero = GameObject.Find("Hero");
    
    private void Update()
    {
        Vector3 position = _hero.transform.position;
        agent.destination = position;
        if (lookAtHero) RotateToTarget(position, transform.position);
    }
    
    private void RotateToTarget(Vector3 targetPosition, Vector3 myPosition)
    {
        targetPosition.y = myPosition.y;
        Vector3 pos = targetPosition - myPosition;
        Quaternion rotation = Quaternion.LookRotation(pos);
        transform.rotation = rotation;
    }
}
