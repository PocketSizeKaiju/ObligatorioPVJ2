public static class GameState
{
    public static bool IsPaused;
    public static bool IsGameOver;

    public static bool IsGameplayBlocked => IsPaused || IsGameOver;
}