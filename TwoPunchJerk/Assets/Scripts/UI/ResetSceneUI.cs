using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResetSceneUI : MonoBehaviour
{
    [SerializeField] Button resetBtn;

    void Start()
    {
        resetBtn.onClick.AddListener(OnClick);
    }

    void OnDestroy()
    {
        resetBtn.onClick.RemoveListener(OnClick);
    }

    void OnClick()
    {
        SceneManager.LoadScene(0);
    }
}
