using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour {
    [SerializeField] private GameObject _prefabBall;
    [SerializeField] private Transform [] _ballSpawns;
    
    public void SpawnBalls(){
        for (int i = 0; i < _ballSpawns.Length; i++){
            Instantiate(_prefabBall, _ballSpawns[i].position, Quaternion.identity);
        }
    }
}
