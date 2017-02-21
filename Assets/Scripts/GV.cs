using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GV : MonoBehaviour {

    public enum ActiveColors { Green, Red, Purple, Orange, Pink, HotPink, Yellow, Blue}

    public static readonly int number_of_colors = 8; //changing this will not scale perfectly since its sprite dependant
    public static Sprite sprite_switch_on;
    public static Sprite sprite_switch_off;
    static Transform gridParent;

    public static Sprite GetSwitchSprite(bool _on)
    {
        if(!sprite_switch_on || !sprite_switch_off)
        {
            sprite_switch_on = Resources.Load<Sprite>("Sprites/SwitchOn");
            sprite_switch_off = Resources.Load<Sprite>("Sprites/SwitchOff");
        }
        if (_on)
            return sprite_switch_on;
        else
            return sprite_switch_off;
    }

    public static Transform GetGridParent()
    {
        if (!gridParent)
            gridParent = GameObject.FindObjectOfType<CanvasManager>().gridParent;
        return gridParent;
    }
}
