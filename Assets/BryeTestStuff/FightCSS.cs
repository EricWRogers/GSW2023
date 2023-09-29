using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FightCSS : MonoBehaviour {

    public List<Fighter> characters = new List<Fighter>();

    public GameObject charCellPrefab;
  
    void Start() {

        foreach(Fighter character in characters)
        {
            SpawnCharacterCell(character);
        }
        
    }

    private void SpawnCharacterCell(Fighter character)
    {
        GameObject charCell = Instantiate(charCellPrefab, transform);

        Image artwork = charCell.transform.Find("Artwork").GetComponent<Image>();
        TextMeshProUGUI name = charCell.transform.Find("nameRect").GetComponentInChildren<TextMeshProUGUI>();

        artwork.sprite = character.fighterSprite;
        name.text = character.fighterName;
    }
}
