using UnityEngine;

public class SpawnItemInChillden : MonoBehaviour
{
    GameObject TheButton;
    public GameObject PrefabButton;
    public Transform Parent;

    private void Start()
    {
        if (Parent == null)
        {
            Parent = GameObject.FindGameObjectWithTag("ListInteract").transform;
        }
    }
    public void ShowButton()
    {
        GameObject NewButton = Instantiate(PrefabButton, Parent);
        TheButton = NewButton;
    }
    public void HideButton()
    {
        Destroy(TheButton);
    }
}
