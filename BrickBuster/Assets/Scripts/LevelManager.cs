using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

    public int curLevel = 0;
    public GameObject[] levels;
    private GameObject curLevelGO;
    public Text levelUITxt;

    public void LoadNextLevel() {

        if (curLevelGO != null) {

            Destroy(curLevelGO);

        }

        if (curLevel < levels.Length) {

            curLevelGO = Instantiate(levels[curLevel], levels[curLevel].transform.position, levels[curLevel].transform.rotation) as GameObject;

            curLevel++;

        }
        else {

            ResetLevels();

        }

        SetLevelUI();

    }

    private void ResetLevels()
    {

        curLevel = 0;
        LoadNextLevel();

    }

    public void SetLevelUI() {

        levelUITxt.text = "Level " + curLevel;

    }

}
