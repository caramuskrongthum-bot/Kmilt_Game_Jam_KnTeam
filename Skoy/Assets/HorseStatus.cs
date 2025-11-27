using UnityEngine;

public class HorseStatus : MonoBehaviour
{
    public Animator animator;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("StunHorse"))
        {
            animator.Play("Stun");
        }
    }
}
