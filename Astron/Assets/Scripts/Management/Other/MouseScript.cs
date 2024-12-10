using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseScript : MonoBehaviour
{
    public Texture2D Mouse;

    private void Start()
    {
        Cursor.SetCursor(Mouse, new Vector2(Mouse.width / 2, Mouse.height / 2), CursorMode.Auto);
    }
}
