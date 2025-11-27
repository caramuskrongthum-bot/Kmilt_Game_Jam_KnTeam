using UnityEngine;

public class DamageToPlayer : MonoBehaviour
{
    public HorseKillerAi Killer;

    public void PlayerHealthDamage(int Damage)
    {
        Killer.PlayerModel.GetComponent<PlayerStatus>().Health -= Damage;
    }
}
