using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameController : MonoBehaviour {
    private VisibilityTrigger [] _visibilityTriggers;
    [SerializeField] private GameObject _objectToErase;
    public static Action LevelCompleted;
    private void OnEnable() {
        DrawController.MouseUp += CheckStatusTriggers;
    }
    private void Start() => _visibilityTriggers = FindObjectsOfType<VisibilityTrigger>();
    
    private void CheckStatusTriggers(){
        foreach (var trigger in _visibilityTriggers){
            if(trigger.IsVisible == false){
                foreach (var thisTrigger in _visibilityTriggers){
                    thisTrigger.IsVisible = false;
                }
                return;
            }
        }
        _objectToErase.SetActive(false);
        LevelCompleted?.Invoke(); 
    }
    private void OnDisable() {
        DrawController.MouseUp -= CheckStatusTriggers;
    }
}
