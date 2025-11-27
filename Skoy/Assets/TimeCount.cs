using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using TMPro;

public class TimeCount : MonoBehaviour
{
    public int Time = 360;
    public HorseKillerAi HorseKillerAi;
    public TextMeshProUGUI TimeText;

    void Start()
    {
        StartCoroutine(ExecuteAfterDelay());
    }

    private void Update()
    {
        if (Time == 0)
        {
            SceneManager.LoadScene("Win");
        }
        if (Time < 100)
        {
            HorseKillerAi.currentState = HorseKillerAi.State.Chase;
            HorseKillerAi.HaveToChaseingPlayer = true;
            HorseKillerAi.ChasePlayer();
        }
        TimeText.text = Time.ToString();
    }

    IEnumerator ExecuteAfterDelay()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            Time--;
        }
    }
}