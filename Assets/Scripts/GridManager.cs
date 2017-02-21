using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager {

    #region Singleton
    private static GridManager instance;

    private GridManager() { }

    public static GridManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GridManager();
            }
            return instance;
        }
    }
    #endregion

    SwitchButton[,] mainGrid;
    int[] gridSize;

    public bool CreateGrid(int _gridSizeX, int _gridSizeY, List<SBCreationStruct> sbDNA)
    {
        gridSize = new int[2];
        gridSize[0] = _gridSizeX;
        gridSize[1] = _gridSizeY;
        mainGrid = new SwitchButton[gridSize[0], gridSize[1]];

        int sanityCheck = gridSize[0] * gridSize[1];
        int check = 0;
        foreach (SBCreationStruct dna in sbDNA)
        {
            check++;
            mainGrid[dna.x, dna.y] = new SwitchButton(dna);
            mainGrid[dna.x, dna.y].CreateUI();
        }
        if (check != sanityCheck)
        {
            Debug.Log("#dna !match :: DnaGiven vs GridCapacity: " + check + ":" + sanityCheck);
            return false;
        }
        return true;
    }

    public void InitializeFromXML(string lvlName)
    {

    }

    public void ExportToXML(string lvlName)
    {

    }

    public void FlipAll(bool[] flipIndexs)
    {
        for(int x = 0; x < gridSize[0]; x++)
            for (int y = 0; y < gridSize[1]; y++)
                if (mainGrid[x, y].HasActiveColor(flipIndexs))
                    mainGrid[x, y].FlipSwitch(SwitchType.Internal);
    }
}
