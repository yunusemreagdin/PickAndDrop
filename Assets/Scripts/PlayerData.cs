using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Create/Player/Data")]
public class PlayerData : ScriptableObject
{
    
    [Header("Player Actions")]
    // Players raycast distance
    public float interactionDistance;
    
    [Header("Key Bindings")]
    public KeyCode keyCodeInteraction;
    public KeyCode keyCodeDoorInteraction;
    public KeyCode keyCodeThrowInteraction;

}