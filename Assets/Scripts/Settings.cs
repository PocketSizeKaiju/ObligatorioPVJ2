using UnityEngine;

[CreateAssetMenu(fileName = "Settings", menuName = "Scriptable Objects/Settings")]
public class Settings : ScriptableObject
{

    static public Settings Instance;

    public Settings()
    {
        Instance = this;
    }

    [Tooltip("Defines the life of the player")]
    public int PlayerLife;
    [Tooltip("Defines the maximum life of the player")]
    public int PlayerMaxLife;
    [Tooltip("Defines the speed of the player")]
    public float PlayerSpeed;

    [Tooltip("How many good people the player has found")]
    public int SurvivoursLeft;
    [Tooltip("How many good people are on the current scene")]
    public int survivoursOnScenes;
}
