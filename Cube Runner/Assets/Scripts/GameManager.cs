using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject obstacle;
    public Transform spawnPoint;
    public float spawnRate;

    public TextMeshProUGUI scoreText;
    public GameObject playButton;
    public GameObject player;

    private int _score = 0;
    
    IEnumerator SpawnObstacles()
    {
        while (true)
        {
            float waitTime = Random.Range(0.2f, 2f);

            yield return new WaitForSeconds(waitTime);

            Instantiate(obstacle, spawnPoint.position, Quaternion.identity);
            _score++;
            scoreText.text = _score.ToString();
        }
    }

    public void StartGame()
    {
        player.SetActive(true);
        playButton.SetActive(false);
        StartCoroutine("SpawnObstacles");
    }
}
