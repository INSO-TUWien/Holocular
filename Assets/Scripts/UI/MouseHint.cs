﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using SimpleFileBrowser;
using UnityEditor;
using UnityEngine;

public class MouseHint : MonoBehaviour
{
    public GUISkin uiStyle;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }


    private void OnGUI()
    {
        if (Main.fileHover)
        {
            GUI.skin = uiStyle;
            GUI.BeginGroup(new Rect(Input.mousePosition.x, Screen.height - Input.mousePosition.y, 600, 70), uiStyle.GetStyle("hint"));
            GUI.Label(new Rect(10, 10, 580, 20), Main.hoveredFile.fullFilePath, uiStyle.GetStyle("headline"));
            GUI.Label(new Rect(10, 30, 580, 20), "Commit: " + Main.hoveredFile.commit.dBCommitStore.sha);
            GUI.Label(new Rect(10, 50, 580, 20), "Commit Date: " + Main.hoveredFile.commit.dBCommitStore.date);
            GUI.EndGroup();
        }
    }
}
