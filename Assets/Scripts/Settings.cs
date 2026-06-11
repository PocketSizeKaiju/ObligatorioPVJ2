using UnityEngine;

[CreateAssetMenu(fileName = "Settings", menuName = "Scriptable Objects/Settings")]
public class Settings : ScriptableObject
{

    private static Settings _instance;

    public static Settings Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = Resources.Load<Settings>("Settings");
                if (_instance == null)
                {
                    Debug.LogError("FATAL: No se encontró el asset 'Settings' en una carpeta Resources.");
                }
            }
            return _instance;
        }
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
