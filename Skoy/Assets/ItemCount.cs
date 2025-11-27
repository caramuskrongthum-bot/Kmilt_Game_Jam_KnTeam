using TMPro;
using UnityEngine;

public class ItemCount : MonoBehaviour
{
    public int Count;
    public TextMeshProUGUI TextMeshProUGUI;
    public GameObject Prefab;
    public bool Spawn;
    public HorseKillerAi Killer;
    void Update()
    {
        TextMeshProUGUI.text = Count.ToString();
    }

    public void SpawnItem()
    {
        if (Count != 0)
        {
            Count--;
            if (Spawn)
            {
                Instantiate(Prefab).transform.position = Killer.PlayerModel.transform.position;
            }
            else
            {
                Prefab.transform.position = Killer.PlayerModel.transform.position;
            }
        }
    }
}
