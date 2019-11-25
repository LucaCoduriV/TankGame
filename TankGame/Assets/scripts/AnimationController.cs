using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private static int iterationCount = 20;

    public GameObject explosionPrefab;
    public static AnimationController instance = null;

    private static GameObject[] explosions;
    private static int selectedExplosion = 0;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }else if(instance != this)
        {
            Destroy(gameObject);
        }


        explosions = new GameObject[iterationCount];

        for (int i = 0; i < iterationCount; i++)
        {
            explosions[i] = Instantiate(explosionPrefab, new Vector3(0, -99, 0), Quaternion.identity);
        }
    }    

    public void playExplosionAnimationAt(Vector3 position)
    {
        int previousSelected;

        Debug.Log(selectedExplosion);

        explosions[selectedExplosion].transform.position = position;
        explosions[selectedExplosion].SetActive(true);
        

        //selectionne la dernière animation utilisée pour la remettere en place
        previousSelected = selectedExplosion == 0 ? iterationCount - 1 : selectedExplosion - 1;
        Debug.Log(previousSelected);
        explosions[previousSelected].SetActive(false);
        explosions[previousSelected].transform.position = new Vector3(0, -99, 0);

        //on ajoute 1 à l'animation selectionnée ou on remet à zéro
        selectedExplosion = selectedExplosion < iterationCount - 1 ? selectedExplosion + 1 : 0;
    }
}
