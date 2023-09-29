using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "New Fighter", menuName = "Fighter")]
public class Fighter : ScriptableObject {

    public string fighterName;
    public Sprite fighterSprite;

}