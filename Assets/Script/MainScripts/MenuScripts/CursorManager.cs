using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    [SerializeField] Texture2D cursorImg;
    void Start()
    {
        Cursor.SetCursor(cursorImg, new Vector2(cursorImg.width * 0.5f, cursorImg.height * 0.5f), CursorMode.ForceSoftware);
    }
}
