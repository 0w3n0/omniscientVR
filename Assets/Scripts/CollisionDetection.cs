using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    // Cette méthode est appelée lorsqu'une collision est détectée
    private void OnTriggerStay(Collider Trigger)
    {
        // Vérifier si la Trigger implique un autre objet
        if (Trigger.gameObject.tag == "CauldronInside")
        {
            // Trigger détectée avec un objet ayant le tag spécifié
            Debug.Log("Trigger détectée avec " + Trigger.gameObject.name);

            // Ajoutez ici le code que vous souhaitez exécuter lors de la collision
        }
    }
}

