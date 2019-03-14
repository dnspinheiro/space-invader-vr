using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HUDPlayer : MonoBehaviour
{
    public static HUDPlayer singleton;

    [SerializeField]
    private TextMeshPro scoreText;
    [SerializeField]
    private TextMeshPro lifeText;
    [SerializeField]
    private Image fadeImage;
    private int score = 0, life = 3;
    private bool gameOver = false;
    [SerializeField]
    private float speedFade = 1;
    // Start is called before the first frame update
    void Start()
    {
        singleton = this;
        UpdateHud();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver && fadeImage.color.a < 1)
        {
            fadeImage.color = new Color(0,0,0, fadeImage.color.a + Time.deltaTime * speedFade);
        }
    }

    void UpdateHud()
    {
        scoreText.text = "Score: " + score.ToString();
        lifeText.text = "Life: " + life.ToString();
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateHud();
    }

    public void dealDamage(int amount)
    {
        life -= amount;
        UpdateHud();
        if (life <= 0)
        {
            gameOver = true;
            fadeImage.color = new Color(0, 0, 0, 0);
            Invoke("ReStartGame", 6);
        }
    }

    public static bool GameOver()
    {
        return singleton.gameOver;
    }

    public void ReStartGame()
    {
        SceneManager.LoadScene(0);
    }
}
