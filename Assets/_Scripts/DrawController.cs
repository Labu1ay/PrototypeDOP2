using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class DrawController : MonoBehaviour {
    private Camera _camera;
    public static Action MouseUp;
    [SerializeField] private Line _linePrefab;
    [SerializeField, Range(0f, 3f)] private float _lineThickness;
    public const float RESOLUTION = 0.1f;
    private Line _currentLine;
    [SerializeField] private SpawnController spawnController;
    private void Start() => _camera = Camera.main;
    
    private void Update() {
        Vector2 mousePos = _camera.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0)){
            _currentLine = Instantiate(_linePrefab, mousePos, Quaternion.identity);
            _currentLine.LineThickness = _lineThickness;
        } 


        if (Input.GetMouseButton(0)){
            _currentLine.SetPosition(mousePos);
        } 
        if (Input.GetMouseButtonUp(0)){
            //did so to show the bonus task on a separate scene
            //without bonus task It should be like this

                        /* if (Input.GetMouseButtonUp(0)){
                               Destroy(_currentLine.gameObject);
                               MouseUp?.Invoke();
                            }*/

            if(SceneManager.GetActiveScene().name != "Level3"){
                Destroy(_currentLine.gameObject);
                MouseUp?.Invoke();
            }else{
                spawnController.SpawnBalls();
            }
            
        } 
    }
}
