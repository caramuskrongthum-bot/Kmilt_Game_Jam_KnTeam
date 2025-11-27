using UnityEngine;
using UnityEngine.Events;

public class InteractWithObject : MonoBehaviour
{
    public GameObject Key;
    public bool Player_Can_Interact;
    public UnityEvent Event;
    public Animator animator;

    public void DoEvent()
    {
        Event.Invoke();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Player_Can_Interact = true;
            GameObject[] AnotherKey = GameObject.FindGameObjectsWithTag("Key");
            foreach (GameObject key in AnotherKey)
            {
                key.SetActive(false);
            }
            Key.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Player_Can_Interact = false;
            animator.Play("UiFadeOut");
        }
    }

    public void CloseGameObject()
        {
            Key.SetActive(false);
        }
}
