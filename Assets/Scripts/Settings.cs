using UnityEngine;

[CreateAssetMenu(fileName = "Settings", menuName = "Scriptable Objects/Settings")]
public class Settings : ScriptableObject
{
    
    static public Settings Instance;

    [Tooltip("Defines the life of the player")]
    public int PlayerLife;
    [Tooltip("Defines the maximum life of the player")]
    public int PlayerMaxLife;
    [Tooltip("Defines the speed of the player")]
    public float PlayerSpeed;    
    [Tooltip("Defines the falling speed of the spawns")]
    public float fallingSpeed;

    private void OnEnable()
    {
        Instance = this;
    }
}
