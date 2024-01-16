using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionCreation : MonoBehaviour
{
    // Tableaux d'ingrédients pour chaque potion
    private string[] potion1Ingredients = { "ChampiRouge", "Croc", "PlumePhoenix" };
    private string[] potion2Ingredients = { "PlumeColombe", "CaillouRond" };
    private string[] potion3Ingredients = { "ChampiBleu", "OngleSorciere" };
    private string[] potion4Ingredients = { "ChampiRouge", "Croc", "PlumePhoenix", "Crystal" };

    private string elementDansChaudron;

    // Cette méthode est appelée lorsqu'un autre collider entre en collision avec le collider de cet objet (trigger)
    private void OnTriggerEnter(Collider other)
    {
        // Vérifier si tous les ingrédients pour Potion1 sont présents
        if (CheckIngredients(potion1Ingredients, other))
        {
            Debug.Log("Potion1 créée !");
            AfficherElementDansChaudron();
        }
        // Vérifier si tous les ingrédients pour Potion2 sont présents
        else if (CheckIngredients(potion2Ingredients, other))
        {
            Debug.Log("Potion2 créée !");
            AfficherElementDansChaudron();
        }
        // Vérifier si tous les ingrédients pour Potion3 sont présents
        else if (CheckIngredients(potion3Ingredients, other))
        {
            Debug.Log("Potion3 créée !");
            AfficherElementDansChaudron();
        }

        // Vérifier si tous les ingrédients pour Potion3 sont présents
        else if (CheckIngredients(potion4Ingredients, other))
        {
            Debug.Log("Potion4 créée !");
            AfficherElementDansChaudron();
        }
    }

    private bool CheckIngredients(string[] ingredients, Collider trigger)
    {
        // Récupérer les tags du collider
        string[] colliderTags = trigger.gameObject.tag.Split(',');

        foreach (string ingredient in ingredients)
        {
            // Vérifier si l'ingrédient est présent dans les tags du collider
            // if (Array.IndexOf(colliderTags, ingredient) == -1)
            // {
            //     // Si un ingrédient est manquant, retourner false
            //     return false;
            // }
        }

        // Si tous les ingrédients sont présents, retourner true
        return true;
    }
    private void AfficherElementDansChaudron()
    {
        Debug.Log("Élément dans le chaudron : " + elementDansChaudron);
    }
}

// REGLER LE PROBLEME DES INGREDIENTS ET DU NOM DES TRUCS ENTRES DEDANS + FAIRE EN SORTE QUE SI TOUT EST DEDANS ALORS ON PASSE UN BOOLEEN A TRUE ET ENSUITE ON AFFICHE SUR UN CANVA UIg