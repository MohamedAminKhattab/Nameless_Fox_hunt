using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField]
    BoolSO attackSound;
    [SerializeField]
    BoolSO eatingSound;
    [SerializeField]
    BoolSO enemyDeathSound;
    [SerializeField]
    BoolSO fetchingSound;
    [SerializeField]
    BoolSO enemyFootSound;
    [SerializeField]
    BoolSO foxLuringSound;
    [SerializeField]
    BoolSO winningSound;
    [SerializeField]
    BoolSO playerDeathSound;
    [SerializeField]
    BoolSO craftingSound;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        eatingSound.state = false;
        enemyDeathSound.state = false;
        fetchingSound.state = false;
        enemyFootSound.state = false;
        foxLuringSound.state = false;
        winningSound.state = false;
        playerDeathSound.state = false;
        craftingSound.state = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.magnitude > 0)
            FindObjectOfType<AudioManager>().PlayeSound("PlayerFoot");

        if (attackSound.state)
        {
            attackSound.state = false;
            FindObjectOfType<AudioManager>().PlayeSound("Arrow");
        }
        if (eatingSound.state)
        {
            eatingSound.state = false;
            FindObjectOfType<AudioManager>().PlayeSound("Eating");
        }
        if (enemyDeathSound.state)
        {
            enemyDeathSound.state = false;
            FindObjectOfType<AudioManager>().PlayeSound("EnemyDeath");
        }
        if (fetchingSound.state)
        {
            fetchingSound.state = false;
            FindObjectOfType<AudioManager>().PlayeSound("Fetch");
        }
        if (enemyFootSound.state)
        {
            enemyFootSound.state = false;
            FindObjectOfType<AudioManager>().PlayeSound("EnemyFoot");
        }
        if (foxLuringSound.state)
        {
            foxLuringSound.state = false;
            FindObjectOfType<AudioManager>().PlayeSound("Fox");
        }
        if (playerDeathSound.state)
        {
            playerDeathSound.state = false;
            FindObjectOfType<AudioManager>().PlayeSound("YelenaDeath");
            StartCoroutine(GameOver());
        }
        if (winningSound.state)
        {
            winningSound.state = false;
            FindObjectOfType<AudioManager>().PlayeSound("Win");
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Vine")
            FindObjectOfType<AudioManager>().PlayeSound("Grass");
    }
    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(2.0f);
        FindObjectOfType<AudioManager>().PlayeSound("GameOver");
    }
}
