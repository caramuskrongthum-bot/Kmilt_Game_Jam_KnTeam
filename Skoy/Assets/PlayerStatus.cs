using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class PlayerStatus : MonoBehaviour
{
    public Animator Animator;
    public Slider HealthBar;
    public Slider EnergyhBar;
    public int Energy;
    public int Health;

    public float FirstSpeed;

    public int MaxHealth = 100;
    public int MaxEnergy = 100;

    public AudioSource FootStepAudioSource;
    public AudioClip[] FootStepAudioClip;
    public NavMeshAgent NavMeshAgent;

    private void Start()
    {
        StartCoroutine(ExecuteAfterDelay());
        FirstSpeed = NavMeshAgent.speed;
        if (FootStepAudioSource == null)
        {
            transform.AddComponent<AudioSource>();
            FootStepAudioSource = GetComponent<AudioSource>();
        }
    }

    private void Update()
    {
        Health = Mathf.Clamp(Health, 0, MaxHealth);
        Energy = Mathf.Clamp(Energy, 0, MaxEnergy);

        HealthBar.value = Health;
        EnergyhBar.value = Energy;

        if (Health <= 0)
        {
            SceneManager.LoadScene("Jumpscare");
        }

        if (Energy > 51)
            NavMeshAgent.speed = FirstSpeed;
        else if (Energy < 10 || Energy > 1)
            NavMeshAgent.speed = 1.5f;
        else if (Energy < 50 || Energy > 11)
            NavMeshAgent.speed = 2f;
    }

    public void EnergyDis(int Ener)
    {
        Energy -= Ener;
    }

    public void EnergyDis25()
    {
        Energy -= 25;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Damage"))
        {
            int a = Random.Range(0, FootStepAudioClip.Length);
            FootStepAudioSource.PlayOneShot(FootStepAudioClip[a]);
            Health -= 15;
            Animator.Play("Damage");
        }

        if (other.CompareTag("Vault"))
        {
            if (SceneManager.GetActiveScene().name == "Hunting")
            {
                EnergyDis25();
            }
            Animator.Play("Vault");
        }
    }

    public void SetHealth(int health)
    {
        Health = Mathf.Clamp(health, 0, MaxHealth);
    }

    IEnumerator ExecuteAfterDelay()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.2f);
            Energy++;
        }
    }
}
