using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class CharacterManager : MonoBehaviour
{
    public CharacterDatabase characterDB;

    public Text nametext;

    public SpriteRenderer artworkSprite;

    private int selectedOption = 0;
    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("selectedOption"))
        {
            selectedOption = 0; 
        }

        else
        {
            Load();
        }
        UpdateCharacter(selectedOption);
    }

    // Update is called once per frame
  
    public void NextOption()
    {
        selectedOption++;
        if (selectedOption >= characterDB.CharacterCount) 
        {
            selectedOption = 0;
        }
        UpdateCharacter(selectedOption);
        Save();
    }

    public void BackOption()
    {
        selectedOption--;

        if (selectedOption < 0)
        {
            selectedOption = characterDB.CharacterCount - 1;
        }

        UpdateCharacter(selectedOption);
        Save();
    }

    private void UpdateCharacter(int selectedOption)
    {
            Character character = characterDB.GetCharacter(selectedOption);
        artworkSprite.sprite = character.charactersprite;
        nametext.text = character.characterName;
    }

    private void Load()
    {
        selectedOption = PlayerPrefs.GetInt("selectedOption");
    }
    

    private void Save()
    {
        PlayerPrefs.SetInt("selectedOption", selectedOption);
    }
}
