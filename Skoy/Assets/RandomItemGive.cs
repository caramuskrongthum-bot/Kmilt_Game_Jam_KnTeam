using UnityEngine;

public class RandomItemGive : MonoBehaviour
{
    public GameObject[] Prefab;
    public Transform SpawnP;
    private int Current;

    public void RandomSpawn()
    {
        if (Prefab.Length == 0 || SpawnP == null)
        {
            return;
        }

        Current = Random.Range(0, Prefab.Length);
        Instantiate(Prefab[Current], SpawnP.position, SpawnP.rotation);
    }
}
