using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour {

    Transform gridParent;

    public void Awake()
    {

    }

	public void LoadBasicLevel()
    {
        //
        
        List<GV.ActiveColors> L1 = new List<GV.ActiveColors>() { GV.ActiveColors.Red };
        List<GV.ActiveColors> L2 = new List<GV.ActiveColors>() { GV.ActiveColors.Red, GV.ActiveColors.Green };
        List<GV.ActiveColors> L3 = new List<GV.ActiveColors>() { GV.ActiveColors.Red, GV.ActiveColors.Green, GV.ActiveColors.Blue};
        List<GV.ActiveColors> L4 = new List<GV.ActiveColors>() { GV.ActiveColors.Green, GV.ActiveColors.Blue };
        List<GV.ActiveColors> L5 = new List<GV.ActiveColors>() { GV.ActiveColors.Red,  GV.ActiveColors.Blue };


        List<SBCreationStruct> sbdna = new List<SBCreationStruct>()
        {
            new SBCreationStruct(0, 0, true, CreateBoolFromColors(L1)),
            new SBCreationStruct(1, 0, true, CreateBoolFromColors(L2)),
            new SBCreationStruct(2, 0, true, CreateBoolFromColors(L3)),
            new SBCreationStruct(3, 0, true, CreateBoolFromColors(L4)),
            new SBCreationStruct(4, 0, true, CreateBoolFromColors(L5)),
            new SBCreationStruct(5, 0, true, CreateBoolFromColors(L2))
        };
        GridManager.Instance.CreateGrid(6, 1, sbdna);
    }

    public void LoadRandomLevel()
    {
        int numToMake = 12;
        List<List<GV.ActiveColors>> superList = new List<List<GV.ActiveColors>>();
        for(int i = 0; i < numToMake; i++)
        {
            int numOfActive = Random.Range(1, 5); //how many can be on at once
            List<GV.ActiveColors> colorsActive = new List<GV.ActiveColors>();
            for(int c = 0; c < numOfActive; c++)
                colorsActive.Add((GV.ActiveColors)Random.Range(0, 5)); //which colors can be active
            superList.Add(colorsActive);
        }

        int xCounter = 0;
        List<SBCreationStruct> sbDna = new List<SBCreationStruct>();
        foreach(List<GV.ActiveColors> ac in superList)
            sbDna.Add(new SBCreationStruct(xCounter++, 0, true, CreateBoolFromColors(ac)));
        GridManager.Instance.CreateGrid(numToMake, 1, sbDna);
    }


    public bool[] CreateBoolFromColors(List<GV.ActiveColors> acList)
    {
        bool[] toRet = new bool[GV.number_of_colors];
        for (int i = 0; i < GV.number_of_colors; i++)
            toRet[i] = false;
        foreach (GV.ActiveColors ac in acList)
            toRet[(int)ac] = true;
        return toRet;
    }
}
