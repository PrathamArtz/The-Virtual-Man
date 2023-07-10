using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int Apples = 0;

    private Text T;
    [SerializeField] private Text ApplesCount;
    // [SerializeField] private Text ApplesCollected;

    //For Audio
    [SerializeField] private AudioSource CollectionSoundEffect;
    // [SerializeField] private AudioSource ApplesCoollectionCompletedSoundEffect;

   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Apple"))
        {

            CollectionSoundEffect.Play();

            Destroy(collision.gameObject);
            Apples++;
            ApplesCount.text = "Apples: 30/" + Apples;
            // ApplesCount.text = "App"

        }

    }
}
