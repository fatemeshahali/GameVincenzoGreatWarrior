using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Coin : MonoBehaviour
{

    private CoinManagment m;

    void Start()
    {
        m = GameObject.FindGameObjectWithTag("Text").GetComponent<CoinManagment>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "coin")
        {
            m.Addmoney();
            Destroy(other.gameObject);
            FindObjectOfType<AudioManager>().Play("Coin");
        }
        if (other.gameObject.tag == "Finish")
        {
            FindObjectOfType<AudioManager>().Play("Finish");
            SceneManager.LoadScene("Win-GameOver");
        }
    }
}
