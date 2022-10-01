using UnityEngine;

public class MuzzleFlash: MonoBehaviour
{
    private SpriteRenderer flash;

    public SpriteRenderer Flash
    {
        get
        {
            if (flash == null)
            {
                flash = GetComponent<SpriteRenderer>();
            }

            return flash;
        }
    }
    private GameObject go;
    private GameObject Go
    {
        get
        {
            if (go == null)
            {
                go = gameObject;
            }

            return go;
        }
    }

    public void HideFlash()
    {
        var color = flash.color;
        var newColor = new Color(color.r, color.g, color.b, 0);
        flash.color = newColor;
    }

    public void ShowFlash()
    {
        var color = flash.color;
        var newColor = new Color(color.r, color.g, color.b, 1);
        flash.color = newColor;
    }
}