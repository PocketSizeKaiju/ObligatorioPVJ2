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
    [Tooltip("Defines the speed of the player")]
    public float PlayerSpeed;    
    [Tooltip("Defines the falling speed of the spawns")]
    public float fallingSpeed;
}
