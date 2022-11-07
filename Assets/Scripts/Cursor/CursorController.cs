using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ÉJÅ[É\ÉãÇÃãììÆ
/// </summary>
public class CursorController : MonoBehaviour
{
    [SerializeField] Image _cursorImg;

    private void Start()
    {
        Cursor.visible = false;
    }

    private void Update()
    {
        CursorMove();

        if (Input.GetButtonDown("Cancel"))
        {
            Cursor.visible = true;
        }
    }

    private void CursorMove()
    {
        _cursorImg.transform.position = Input.mousePosition;
    }
}
