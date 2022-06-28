using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Coin : MonoBehaviour
{

    private CoinManagment m;
    public GameObject player;
    public GameObject fire;

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

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            FindObjectOfType<AudioManager>().Play("DistroyEnemy");
            Destroy(other.gameObject);
        }
    }

    void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            FindObjectOfType<AudioManager>().Stop("BgSound");
            Instantiate(fire, transform.position, Quaternion.identity);
            Destroy(player);
            SceneManager.LoadScene("Lost-Game");
        }
    }
}
