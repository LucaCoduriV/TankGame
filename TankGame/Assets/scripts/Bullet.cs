using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    public AudioClip shootClip;
    public AudioClip explosionClip;

    private Rigidbody2D bulletBody;
    private float cannonSize = 2;
    private GameObject collider;


    // Start is called before the first frame update
    void Start()
    {
        bulletBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //angle de départ de la balle + l'objet depuis le quel la balle doit partir
    public void Departure(float speed, GameObject cannon)
    {
        float rotation = cannon.transform.eulerAngles.z;
        Vector2 vRotation = Tools.DegreeToVector2(rotation);

        //positionne la balle au bonne endroit pour qu'elle puisse sortir du cannon
        bulletBody.position = (Vector2)cannon.transform.position + vRotation * cannonSize;

        //joue le son
        AudioController.instance.PlaySingle(shootClip);

        //donne une vitesse à la balle
        Vector2 vBullet = vRotation * speed;
        bulletBody.velocity = vBullet ;

        
    }

    //Quand une balle touche qqch
    void OnTriggerEnter2D(Collider2D col)
    {
        //Si c'est AI alors on déplace L'AI dans un coin non visible et on désactive la simulation
        if(col.tag == "AI")
        {
            //fait disparaitre la balle
            transform.position = new Vector3(0, -90, 0);
            GetComponent<Rigidbody2D>().simulated = false;
            //on créer l'animation de l'explosion
            AnimationController.instance.playExplosionAnimationAt(col.transform.position);
            //jouer le son de l'explosion
            AudioController.instance.PlaySingle(explosionClip);
            //fait disparaitre le AI
            col.GetComponent<Rigidbody2D>().simulated = false;
            col.transform.position = new Vector3(100, -99, 0);
        }

    }

}
