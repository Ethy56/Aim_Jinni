using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class gameController : MonoBehaviour
{
    [SerializeField] private Button coin, playAgainBtn, menuBtn;
    [SerializeField] private float maxCoins = 10f, coinsAMT = 0f, timesUp = 0f;
    [SerializeField] private TextMeshProUGUI coinsShow, timeShow, timesUpShow;
    [SerializeField] private Camera cam;
    [SerializeField] private bool summoning, gameActive = true;
    [SerializeField] private SpriteRenderer logo;
    public float coins = 0f;
    void Awake()
    {
        playAgainBtn.onClick.AddListener(playAgain);
        menuBtn.onClick.AddListener(loadMenu);
    }
    void Update()
    {
        if (gameActive)
        {
            if (logo.enabled)
            {
                logo.enabled = false;
            }
            if (menuBtn.transform.position != coin.transform.position)
            {
                menuBtn.transform.position = coin.transform.position;
            }
            if (playAgainBtn.transform.position != coin.transform.position)
            {
                playAgainBtn.transform.position = coin.transform.position;
            }
            if (timesUpShow.enabled)
            {
                timesUpShow.enabled = false;
            }
            if (!timeShow.enabled)
            {
                timeShow.enabled = true;
            }
            if (!coinsShow.enabled)
            {
                coinsShow.enabled = true;
            }
            if (coinsShow.text != ("Coins: " + coins))
            {
                coinsShow.text = ("Coins: " + coins);
            }
            coinsAMT = GameObject.FindGameObjectsWithTag("coins").Length - 1f;
            if (coinsAMT < maxCoins && !summoning)
            {
                Summon();
                StartCoroutine(waiter(0.25f));
                summoning = false;
            }
            timesUp += Time.deltaTime;
            if (timeShow.text != "Time: " + Mathf.Round(timesUp % 60).ToString())
            {
                timeShow.text = "Time: " + Mathf.Round(timesUp % 60).ToString();
            }
            if (Mathf.Round(timesUp % 60) >= 15f) 
            {
                gameActive = false;
            }
        } else
        {
            foreach (GameObject temp in GameObject.FindGameObjectsWithTag("coins"))
            {
                if (temp.gameObject.name != "CoinButton")
                {
                    Destroy(temp);
                }
            }
            menuBtn.transform.position = (new Vector3(960f, 200f, 0f));
            playAgainBtn.transform.position = (new Vector3(960f, 450f, 0f));
            timesUpShow.enabled = true;
            coinsShow.enabled = false;
            timeShow.enabled = false;
            logo.enabled = true;
            timesUpShow.text = "Times up! You collected " + coins.ToString() + " Coins!";
        }
    }
    void loadMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    void playAgain()
    {
        gameActive = true;
        timesUp = 0f;
        coins = 0f;
    }
    void Summon()
    {
        if (!summoning)
        {
            summoning = true;
            Vector3 loco = new Vector3(Random.Range(1850, 50f), Random.Range(60, 980), transform.position.z);
            GameObject temp = Instantiate(coin.gameObject, loco, transform.rotation);
            Button tempbtn = temp.GetComponent<Button>();
            if (!tempbtn.enabled)
            {
                temp.GetComponent<Button>().enabled = true;
            }
            summoning = false;
        }
    }
    IEnumerator waiter(float x)
    {
        yield return new WaitForSeconds(x);
    }
}
