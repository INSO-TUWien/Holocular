﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static UnityEditor.Handles;

public class FolderController : MonoBehaviour
{

    private UnityAction updateFolderListener;
    private LineRenderer lr;

    // Start is called before the first frame update
    void Start()
    {
        lr = gameObject.GetComponent<LineRenderer>();
        UpdateFolder();
        updateFolderListener = new UnityAction(UpdateFolder);
        EventManager.StartListening("updateFolders", updateFolderListener);
    }

    private void UpdateFolder()
    {
        if (GlobalSettings.showFolderRings)
        {
            lr.enabled = true;
        }
        else
        {
            lr.enabled = false;
        }
    }
}
