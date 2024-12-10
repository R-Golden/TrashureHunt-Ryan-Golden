using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartSystem : MonoBehaviour
{


    public GameObject[] hearts;

    [SerializeField] public Player player;

    public GameObject extrahealth;
    public GameObject text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.Health == 2)
        {
            Destroy(hearts[0].gameObject);
        }
        else if (player.Health == 1)
        {
            Destroy(hearts[1].gameObject);
        }
        else if (player.Health == 0)
        {
            Destroy(hearts[2].gameObject);
        }
        else if (player.Health > 3) 
        {
            hearts[3].gameObject.SetActive(true);
            
        }
    }


    public void addheart()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") 
        {
            Debug.Log("test");
            player.Health += 1;
            destory();
            
        }
    }

    private void destory()
    {
        Destroy(extrahealth);
        text.SetActive(true);
        
    }
}
