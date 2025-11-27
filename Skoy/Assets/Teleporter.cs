using UnityEngine;
using UnityEngine.Events;

public class Teleporter : MonoBehaviour
{
    public Transform TeleportPosition;
    public HorseKillerAi HorseKillerAi;
    PlayerMoveMouse PlayerMoveMouse;
    public UnityEvent E;

    public bool Ready;

    private void Set()
    {
        PlayerMoveMouse = HorseKillerAi.PlayerModel.GetComponent<PlayerMoveMouse>();
    }
    public void TeleportPlayer()
    {
        if (Ready)
        {
            Set();
            E.Invoke();
            PlayerMoveMouse.targetPoint = TeleportPosition.position;
            PlayerMoveMouse.agent.Warp(TeleportPosition.position);
        }
    }

    public void SetReady(bool ready)
    {
        Ready = ready;
    }
}
