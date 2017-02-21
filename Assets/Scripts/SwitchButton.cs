using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public enum SwitchType { ButtonPressed, Internal, Forced}
public class SwitchButton  {

    SwitchButtonUI sbi;
    public bool switchedOn = true;
    public bool[] activeColors;

    public SwitchButton(SBCreationStruct dna)
    {
        activeColors = dna.activeColors.ToArray();
        switchedOn = dna.isOn;
    }

    public void FlipSwitch(SwitchType switchType)
    {
        switch(switchType)
        {
            case SwitchType.ButtonPressed:
                GridManager.Instance.FlipAll(activeColors);
                break;
            case SwitchType.Internal:
                switchedOn = !switchedOn;
                sbi.SwitchValueChanged(switchedOn);
                break;
        }
        
    }

    public bool HasActiveColor(bool[] checkColors)
    {
        for(int i = 0; i < GV.number_of_colors; i++)
                if(activeColors[i] && checkColors[i])
                    return true;
        return false;
    }

    public void CreateUI()
    {
        DestroyUI();
        
        GameObject go = MonoBehaviour.Instantiate(Resources.Load("Prefabs/SwitchPrefab")) as GameObject;
        go.transform.SetParent(GV.GetGridParent());
        sbi = go.GetComponent<SwitchButtonUI>();
        sbi.Initialize(this);
    }

    private void DestroyUI()
    {
        if(sbi)
            MonoBehaviour.Destroy(sbi.gameObject);
        sbi = null;
    }

    public void DeleteSwitchButton()
    {
        DestroyUI();
        //clean up UI;
    }
}
