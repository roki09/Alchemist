using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadAutoSave : MonoBehaviour
{
    [SerializeField] SaveLoad save;

    private void OnEnable()
    {
        save.LoadAutoSave();
    }
}
