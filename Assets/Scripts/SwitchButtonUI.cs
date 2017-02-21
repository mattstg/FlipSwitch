using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchButtonUI : MonoBehaviour {
    
    public Image switchedImg;
    public List<Transform> colors;
    SwitchButton sb;

    private bool imgIsSetActive;

    public void Initialize(SwitchButton _sb)
    {
        sb = _sb;
        for (int i = 0; i < GV.number_of_colors; i++)
            colors[i].gameObject.SetActive(sb.activeColors[i]);
        switchedImg.sprite = GV.GetSwitchSprite(sb.switchedOn);
        imgIsSetActive = sb.switchedOn;
    }

    public void SwitchPressed()
    {
        sb.FlipSwitch(SwitchType.ButtonPressed);
    }

    private void SetSwitchImg(bool _isOn)
    {
        if(_isOn != imgIsSetActive)
        {
            switchedImg.sprite = GV.GetSwitchSprite(_isOn);
            imgIsSetActive = _isOn;
        }
    }

    public void SwitchValueChanged(bool isOn)
    {
        SetSwitchImg(isOn);
    }
}
