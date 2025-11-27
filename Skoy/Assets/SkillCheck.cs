using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class SkillCheck : MonoBehaviour
{
    public bool CanClick;
    public int Score;
    public TextMeshProUGUI TextMeshProUGUI;
    public int Round;
    public int Max;
    public UnityEvent Finish;
    public UnityEvent Missed;

    public bool CareMissed = true;
    void Update()
    {
        if (TextMeshProUGUI != null)
        {
        TextMeshProUGUI.text = Score.ToString();
        }
        if (CanClick)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Score++;
            }
        }
        else
        {
            if (!CareMissed)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Missed.Invoke();
                }
            }
        }
    }

    public void CheckScore()
    {
        if (Score == Max)
        {
            Finish.Invoke();
        }
        else
        {
            Missed.Invoke();
        }
    }
    public void AddScore()
    {
        Score++;
        if (Round == Max)
        {
            if (Score == Max)
            {
                Finish.Invoke();
            }
            else
            {
                Missed.Invoke();
            }
        }
    }
    public void SetScore(int a)
    {
        Score = a;
    }
}
