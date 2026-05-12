using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class LightsScript : MonoBehaviour
{
    private double delta;

    private void Update()
    {
        GetComponent<BoxCollider2D>().enabled = Keyboard.current.ctrlKey.IsPressed();
        GetComponent<Renderer>().enabled = Keyboard.current.ctrlKey.IsPressed();

        delta += Time.deltaTime;
        if (delta > 2 && Keyboard.current.ctrlKey.IsPressed())
        {
            Settings.Instance.PlayerLife -= 1;
            Debug.Log("Player life " + Settings.Instance.PlayerLife);
            delta = 0;
        } else if(!Keyboard.current.ctrlKey.IsPressed())
        {
            delta = 0;
        }
    }
}
