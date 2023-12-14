using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewFile", menuName = "Character/New")]
public class Character : ScriptableObject
{
        public float speed;
        public string characterName;
        public Sprite characterSprite;
        public Color newColor;
        public List<Color> colorList;
        public RuntimeAnimatorController animations;
        public float outlineThickness;

        // public virtual void Active()
        // {

        // }

        // public virtual void Passive()
        // {
        //     //Debug.Log("Passive");
        // }
}
