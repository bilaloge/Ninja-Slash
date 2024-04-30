using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Difficulty : MonoBehaviour
{
    private Button button;
    private GameManager gameManager;
    public int diffLvl;
    // Start is called before the first frame update
    void Start()
    {
        button= gameObject.GetComponent<Button>();/*GetComponent<Button>(); game object olmadan yazýyo. gameobjektle dene bir*/
        button.onClick.AddListener(SetDifficulty);
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SetDifficulty()
    {
        Debug.Log(gameObject.name + " was clicked");
        gameManager.StartGame(diffLvl);
        gameObject.SetActive(false);
    }
}
