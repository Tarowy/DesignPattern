using System;
using System.Collections;
using System.Collections.Generic;
using SceneController;
using UnityEngine;

public class GameLoop : MonoBehaviour
{
    private SceneStateController _stateController;
    
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        _stateController = new SceneStateController();
        _stateController.SetState(new StartSceneState(_stateController), false);
    }

    private void Update()
    {
        _stateController.StateUpdate();
    }
}
