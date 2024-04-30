using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public float spawnRate = 1;
    private int score;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameoverText;
    public bool gameactive;
    public Button restart;
    public GameObject titleScreen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void GameOver()
    {
        gameoverText.gameObject.SetActive(true);
        gameactive = false;
        restart.gameObject.SetActive(true);
    }
    IEnumerator SpawnTarget()
    {
        while (gameactive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score : " + score;
    }
    public void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); /*yada loadscene(Prototype 5 yazabilirsin)*/
    }
    public void StartGame(int diffLvl)
    {
        spawnRate /= diffLvl;
        gameactive = true;
        score = 0;
        StartCoroutine(SpawnTarget());
        UpdateScore(0);
        titleScreen.SetActive(false);
    }
}
