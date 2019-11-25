using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed = 20;
    public GameObject bulletPrefab;


    private GameObject[] bullets;
    private Bullet bullet;
    private int numberOfBullet = 50;
    private int actualBulletID = 0;
    private float boundY = -100;
    private Bullet selectedBullet;

    private void Awake()
    {
        for (int i = 0; i < numberOfBullet; i++)
        {
            Instantiate(bulletPrefab, new Vector3(-1000, 0, 0), Quaternion.identity);
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        bullets = GameObject.FindGameObjectsWithTag("Bullets");
    }

    // Update is called once per frame
    void Update()
    {
        //verifie pour chaque balle si elle se trouve hors des limite et si c'est le cas, stop la simulation de la balle
        for (int i = 0; i < numberOfBullet; i++)
        {
            if (CheckIfBulletOutOfBound(i))
            {
                //on range les balles  en 0;-90
                bullets[i].transform.position = new Vector3(0, -90, 0);
                bullets[i].GetComponent<Rigidbody2D>().simulated = false;
            }
        }
        
    }

    //selectionne une balle puis la fait partir dans la direction choisi
    public void BulletSelector(GameObject cannon)
    {

        selectedBullet = bullets[actualBulletID].GetComponent<Bullet>();
        bullets[actualBulletID].GetComponent<Rigidbody2D>().simulated = true;


        selectedBullet.Departure(speed, cannon);

        actualBulletID = ( actualBulletID < numberOfBullet-1) ? (actualBulletID + 1) : 0;

    }

    //vérifie si une balle se trouve hors des limites
    private bool CheckIfBulletOutOfBound(int bulletID)
    {
        if(bullets[bulletID].transform.position.y <= boundY)
        {
            return true;
        }
        return false;
    }

}
