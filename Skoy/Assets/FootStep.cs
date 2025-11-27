using Unity.VisualScripting;
using UnityEngine;

public class FootStep : MonoBehaviour
{
    public Transform LFoot;
    public Transform RFoot;
    public GameObject FootStepEffect;
    public AudioSource FootStepAudioSource;
    public AudioClip[] FootStepAudioClip;

    private void Start()
    {
        if (FootStepAudioSource == null)
        {
            transform.AddComponent<AudioSource>();
            FootStepAudioSource = GetComponent<AudioSource>();
        }
    }
    public void LFootStep()
    {
        Instantiate(FootStepEffect).transform.position = LFoot.position;
        int a = Random.Range(0, FootStepAudioClip.Length);
        FootStepAudioSource.PlayOneShot(FootStepAudioClip[a]);
    }
    public void RFootStep()
    {
        Instantiate(FootStepEffect).transform.position = RFoot.position;
        int a = Random.Range(0, FootStepAudioClip.Length);
        FootStepAudioSource.PlayOneShot(FootStepAudioClip[a]);
    }
}
