using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public GameObject[] spawnerPoints;
	public GameObject fruit;
	public GameObject bomb;
    public GameObject obj_basket;

    public GameObject canvasGameOver;
    public GameObject canvasGame;
    public GameObject canvasMenu;
    public Text txtScore;


    public float waitSpawn = 5.0f;
    public float waitEnd = 1.0f;
    public float waitStart = 1.0f;

    public int totalItms = 20;


    public int countItems = 0;
    public int countFruit = 0;
    public int score = 0;

    private Basket basket;
    private bool gameOver = false;

    // Use this for initialization
    void Start () {
        basket = obj_basket.GetComponent<Basket>();
    }
	//Cambiar y dejar en un KeboardManager
	void Update () {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Debug.Log("Key Left");
            basket.MoveLeft();
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            Debug.Log("Key Right");
            basket.MoveRight();
        }
        else if (basket.IsNotCenter)
        {
            basket.MoveCenter();
        }
    }


	//Cambiar y dejar en un FruitManager
	IEnumerator StartWave(){
        while(!gameOver){
            yield return new WaitForSeconds(waitStart);
            for (int i = 0; i < totalItms; i++){

                if (!gameOver) {
                    SpawnItem();
                }
                yield return new WaitForSeconds(waitSpawn);
            }

            gameOver = !gameOver;
        }

        yield return new WaitForSeconds (waitEnd);
	}

	public void addScore(){

		score++;
        UpdateScore();

    }

    private void UpdateScore() {
        txtScore.text = score.ToString() + "/" + countFruit;
    }

	//Cambiar y dejar en un CanvasGameManager
	private void CreateFruit(Vector3 spawnPos){
        Instantiate (
			fruit,
			spawnPos,
			Quaternion.identity
		);

        countFruit++;
        UpdateScore();

    }

    private void CreateBomb(Vector3 spawnPos){
		Instantiate (
			bomb,
			spawnPos,
			Quaternion.identity
		);
	}

    private void SpawnItem() {
        Vector3 spawnPoint = GetRandomSpawnPoint();
        float randomNum = Random.value;
        //Debug.Log (randomNum);
        if (randomNum < 0.8)
        {
            CreateFruit(spawnPoint);
        }
        else
        {
            CreateBomb(spawnPoint);
        }
    }

	private Vector3 GetRandomSpawnPoint(){
		int index = GetRandomSpawnPointIndex ();
		Vector3 spawnPos = new Vector3 (
			spawnerPoints [index].transform.position.x,
			spawnerPoints [index].transform.position.y,
			0
		);

		return spawnPos;
	}

	private int GetRandomSpawnPointIndex(){
		float randomNum = Random.Range (0,spawnerPoints.Length);
		int index = (int)Mathf.Floor (randomNum);
		return index;
	}

    public void GameOver()
    {
        StopCoroutine("StartWave");
        gameOver = true;
        canvasGame.SetActive(false);
        canvasGameOver.SetActive(true);
    }

    public void StartGame() {
        canvasGame.SetActive(true);
        canvasMenu.SetActive(false);
        gameOver = false;

        UpdateScore();

        StartCoroutine("StartWave");
    }

    public void RestartGame()
    {
        canvasGame.SetActive(true);
        canvasGameOver.SetActive(false);
        RestartVariables();
        StartCoroutine("StartWave");
    }

    private void RestartVariables() {
        gameOver = false;
        countItems = 0;
        countFruit = 0;
        score = 0;
        UpdateScore();
        obj_basket.SetActive(true);
    }
}
