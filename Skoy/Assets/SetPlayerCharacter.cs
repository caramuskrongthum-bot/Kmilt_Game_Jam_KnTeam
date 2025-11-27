using UnityEngine;

public class SetPlayerCharacter : MonoBehaviour
{
    public GameObject Chr_1;
    public GameObject Chr_2;
    public GameObject Chr_3;
    public GameObject Chr_4;
    public GameObject Chr_5;

    public HorseKillerAi HorseKillerAi;

    public bool DestroyIt;
    private void Start()
    {
        LoadCharacter();
    }
    public void LoadCharacter()
    {
        if (PlayerPrefs.GetInt("Character") == 0)
        {
            if (HorseKillerAi != null)
            {
                HorseKillerAi.PlayerModel = Chr_1;
            }
            if (DestroyIt)
            {
                Destroy(Chr_2);
                Destroy(Chr_3);
                Destroy(Chr_4);
                Destroy(Chr_5);
            }
            Chr_1.SetActive(true);
        }
        if (PlayerPrefs.GetInt("Character") == 1)
        {
            if (HorseKillerAi != null)
            {
                HorseKillerAi.PlayerModel = Chr_1;
            }
            if (DestroyIt)
            {
                Destroy(Chr_2);
                Destroy(Chr_3);
                Destroy(Chr_4);
                Destroy(Chr_5);
            }
            Chr_1.SetActive(true);
        }
        if (PlayerPrefs.GetInt("Character") == 2)
        {
            if (HorseKillerAi != null)
            {
                HorseKillerAi.PlayerModel = Chr_2;
            }
            if (DestroyIt)
            {
                Destroy(Chr_1);
                Destroy(Chr_3);
                Destroy(Chr_4);
                Destroy(Chr_5);
            }
            Chr_2.SetActive(true);
        }
        if (PlayerPrefs.GetInt("Character") == 3)
        {
            if (HorseKillerAi != null)
            {
                HorseKillerAi.PlayerModel = Chr_3;
            }
            if (DestroyIt)
            {
                Destroy(Chr_1);
                Destroy(Chr_2);
                Destroy(Chr_4);
                Destroy(Chr_5);
            }
            Chr_3.SetActive(true);
        }
        if (PlayerPrefs.GetInt("Character") == 4)
        {
            if (HorseKillerAi != null)
            {
                HorseKillerAi.PlayerModel = Chr_4;
            }
            if (DestroyIt)
            {
                Destroy(Chr_1);
                Destroy(Chr_2);
                Destroy(Chr_3);
                Destroy(Chr_5);
            }
            Chr_4.SetActive(true);
        }
        if (PlayerPrefs.GetInt("Character") == 5)
        {
            if (HorseKillerAi != null)
            {
                HorseKillerAi.PlayerModel = Chr_5;
            }
            if (DestroyIt)
            {
                Destroy(Chr_1);
                Destroy(Chr_2);
                Destroy(Chr_3);
                Destroy(Chr_4);
            }
            Chr_5.SetActive(true);
        }
    }
}
