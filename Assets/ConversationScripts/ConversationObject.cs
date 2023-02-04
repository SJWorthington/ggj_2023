using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ConversationObject : ScriptableObject
{
    public enum Character
    {
        TREE,
        TINUS,
        TIBERIUS,
        TOOTERS,
        TRISH
    }

    //todo - make more things public? Everything public!
    [SerializeField] public List<Character> characterSpeaking;
    [SerializeField] public List<string> text;
}