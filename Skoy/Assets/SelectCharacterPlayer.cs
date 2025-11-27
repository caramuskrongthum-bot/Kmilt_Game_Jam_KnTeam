using System.Collections.Generic;
using UnityEngine;

public class SelectCharacterPlayer : MonoBehaviour
{
    public GameObject ChrSelect;
    public List<GameObject> Character;
    public int Current;
    public void SelectThisCharacter(GameObject character)
    {
        foreach (GameObject obj in Character)
        {
            obj.SetActive(false);
        }
        ChrSelect = character;
        ChrSelect.SetActive(true);
        PlayerPrefs.SetInt("Character", Current);
    }

    public void SelectNumber(int number)
    {
        Current = number;
    }
}
