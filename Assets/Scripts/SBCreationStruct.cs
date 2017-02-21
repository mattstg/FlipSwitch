using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SBCreationStruct {

    public int x;
    public int y;
    public bool isOn;
    public bool[] activeColors;
    
	public SBCreationStruct(int _x, int _y, bool _on, bool[] _activeColors)
    {
        x = _x;
        y = _y;
        isOn = _on;
        activeColors = _activeColors.ToArray();
    }
}
