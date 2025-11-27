using UnityEngine;
using UnityEngine.AI;

public class ChrBuff : MonoBehaviour
{
    NavMeshAgent agent;
    PlayerStatus status;
    public float AddSpeed;
    public int SetHealth;
    public int SetEnergy;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        status = GetComponent<PlayerStatus>();
    }
    void Update()
    {
        agent.speed = agent.speed + AddSpeed;
        status.MaxHealth = SetHealth;
        status.MaxEnergy = SetEnergy;
    }
}
