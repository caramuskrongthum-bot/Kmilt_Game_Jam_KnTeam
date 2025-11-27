using UnityEngine;

public class ItemSkill : MonoBehaviour
{
    public int Add;
    public HorseKillerAi Killer;
    public GameObject Prefab;
    public bool Heal;
    public bool Spawn;
    private void Start()
    {
        Killer = GameObject.FindGameObjectWithTag("Horse").GetComponent<HorseKillerAi>();
    }

    public void UseItem()
    {
        if (Heal)
        {
            Killer.PlayerModel.GetComponent<PlayerStatus>().Health += Add;
            Destroy(gameObject);
        }
        if (Spawn)
        {
            Instantiate(Prefab).transform.position = Killer.PlayerModel.GetComponent<PlayerStatus>().transform.position;
            Destroy(gameObject);
        }
    }
}
