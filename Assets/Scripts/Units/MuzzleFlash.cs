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
        var color = Flash.color;
        var newColor = new Color(color.r, color.g, color.b, 0);
        Flash.color = newColor;
    }

    public void ShowFlash()
    {
        var color = Flash.color;
        var newColor = new Color(color.r, color.g, color.b, 1);
        Flash.color = newColor;
    }
}