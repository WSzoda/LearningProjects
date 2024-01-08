using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.Events;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private GameObject squarePrefab;
    [SerializeField]
    private Transform player;


    public UnityEvent<SwipeDirection> movePlayer;
    public int Score { get; private set; }
    private readonly GameObject[] _enemies = new GameObject[4];
    

    public void IncrementScore()
    {
        Score++;
    }
    
    void Start()
    {
        RespawnEnemies();
    }

    void RespawnEnemies()
    {
        Vector3 playerPos = player.position;
        _enemies[(int)SwipeDirection.Up] = Instantiate(squarePrefab, new Vector3(playerPos.x, 0, playerPos.z + 1.5f), Quaternion.identity);
        _enemies[(int)SwipeDirection.Right] = Instantiate(squarePrefab, new Vector3(playerPos.x + 1.5f, 0, playerPos.z), Quaternion.identity);
        _enemies[(int)SwipeDirection.Down] = Instantiate(squarePrefab, new Vector3(playerPos.x, 0, playerPos.z - 1.5f), Quaternion.identity);
        _enemies[(int)SwipeDirection.Left] = Instantiate(squarePrefab, new Vector3(playerPos.x - 1.5f, 0, playerPos.z), Quaternion.identity);
    }

    void DestroyEnemies()
    {
        foreach (GameObject enemy in _enemies)
        {
            Destroy(enemy);
        }
    }

    public void HandleSwipe(SwipeDirection direction)
    {
        IncrementScore();
        movePlayer.Invoke(direction);
        DestroyEnemies();
        RespawnEnemies();
    }
}
