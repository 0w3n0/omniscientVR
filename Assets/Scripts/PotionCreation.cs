using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionCreation : MonoBehaviour
{
    // Tableaux d'ingrédients pour chaque potion
    private string[] potion1Ingredients = { "ChampiRouge", "Croc", "PlumePhoenix" };
    private string[] potion2Ingredients = { "PlumeColombe", "CaillouRond" };
    private string[] potion3Ingredients = { "ChampiBleu", "Oeil" };
    private string[] potion4Ingredients = { "ChampiRouge", "Croc", "PlumePhoenix", "Crystal" };

    private List<GameObject> objetsEnCollision = new List<GameObject>();
    public string[] nomsGameObjects = new string[5];

    private string AllIngredientsPot1 = "";
    private string AllIngredientsPot2 = "";
    private string AllIngredientsPot3 = "";
    private string AllIngredientsPot4 = "";

    public bool Potion1 = false;
    public bool Potion2 = false;
    public bool Potion3 = false;
    public bool Potion4 = false;

    public bool PotionDone1 = false;
    public bool PotionDone2 = false;
    public bool PotionDone3 = false;
    public bool PotionDone4 = false;

    public int cpt = 0;

    public int NbPotion1 = 0;
    public int NbPotion2 = 0;
    public int NbPotion3 = 0;
    public int NbPotion4 = 0;

    public GameObject Trigger1;
    public GameObject Trigger2;
    public GameObject Trigger3;

    public GameObject Trigger4;

    private string elementDansChaudron;

    void Start()
    {
        // Concaténer les ingrédients pour former une seule chaîne


        for (int i = 0; i < potion1Ingredients.Length; i++)
        {
            AllIngredientsPot1 += potion1Ingredients[i];

            // Ajouter une virgule et un espace sauf pour le dernier element
            if (i < potion1Ingredients.Length - 1)
            {
                AllIngredientsPot1 += ", ";
            }
        }

        // Concaténer les ingrédients pour former une seule chaîne

        for (int i = 0; i < potion2Ingredients.Length; i++)
        {
            AllIngredientsPot2 += potion2Ingredients[i];

            // Ajouter une virgule et un espace sauf pour le dernier element
            if (i < potion2Ingredients.Length - 1)
            {
                AllIngredientsPot2 += ", ";
            }
        }

        // Concaténer les ingrédients pour former une seule chaîne

        for (int i = 0; i < potion3Ingredients.Length; i++)
        {
            AllIngredientsPot3 += potion3Ingredients[i];

            // Ajouter une virgule et un espace sauf pour le dernier element
            if (i < potion3Ingredients.Length - 1)
            {
                AllIngredientsPot3 += ", ";
            }
        }

        // Concaténer les ingrédients pour former une seule chaîne

        for (int i = 0; i < potion4Ingredients.Length; i++)
        {
            AllIngredientsPot4 += potion4Ingredients[i];

            // Ajouter une virgule et un espace sauf pour le dernier element
            if (i < potion4Ingredients.Length - 1)
            {
                AllIngredientsPot4 += ", ";
            }
        }

        // Afficher la chaîne complète dans la console Unity
        Debug.Log(AllIngredientsPot1);
    }
    void Update()
    {
        AfficherObjetsEnCollision();
        if (Potion1 == true)
        {
            Debug.Log("La potion a conconcter est composée de " + AllIngredientsPot1);
        }
        if (Potion2 == true)
        {
            Debug.Log("La potion a conconcter est composée de " + AllIngredientsPot2);
        }
        if (Potion3 == true)
        {
            Debug.Log("La potion a conconcter est composée de " + AllIngredientsPot3);
        }
        if (Potion4 == true)
        {
            Debug.Log("La potion a conconcter est composée de " + AllIngredientsPot4);
        }
    }




    // Cette méthode est appelée lorsqu'un autre collider entre en collision avec le collider de cet objet (trigger)
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.tag);


        if (Potion1 == true)
        {
            Debug.Log("La potion a conconcter est composée de " + potion1Ingredients);
            // Vérifier si tous les ingrédients pour Potion1 sont présents
            if (other.gameObject.tag == "ChampiRouge")
            {
                Debug.Log(other.gameObject.tag + " est dans le chaudron !");
                NbPotion1 += 1;
                cpt += 1;
                Debug.Log(NbPotion1);
            }

            else if (other.gameObject.tag == "Croc")
            {
                Debug.Log(other.gameObject.tag + " est dans le chaudron !");
                NbPotion1 += 1;
                cpt += 1;
                Debug.Log(NbPotion1);
            }

            else if (other.gameObject.tag == "PlumePhoenix")
            {
                Debug.Log(other.gameObject.tag + " est dans le chaudron !");
                NbPotion1 += 1;
                cpt += 1;
                Debug.Log(NbPotion1);
            }

            else
            {
                cpt += 1;
                Debug.Log("ON RESET TOUT");
            }

            if (cpt == 3)
            {
                Trigger1.SetActive(true);
                Trigger2.SetActive(true);
                Trigger3.SetActive(true);
                Trigger4.SetActive(true);
            }
        }

        if (Potion2 == true)
        {
            Debug.Log("La potion a conconcter est composée de " + potion2Ingredients);
            // Vérifier si tous les ingrédients pour Potion2 sont présents
            if (other.gameObject.tag == "PlumeColombe")
            {
                Debug.Log(other.gameObject.tag + " est dans le chaudron !");
                NbPotion2 += 1;
                cpt += 1;
                Debug.Log(NbPotion2);
            }

            else if (other.gameObject.tag == "CaillouRond")
            {
                Debug.Log(other.gameObject.tag + " est dans le chaudron !");
                NbPotion2 += 1;
                cpt += 1;
                Debug.Log(NbPotion2);
            }

            else
            {
                cpt += 1;
                Debug.Log("ON RESET TOUT");
            }

            if (cpt == 2)
            {
                Trigger1.SetActive(true);
                Trigger2.SetActive(true);
                Trigger3.SetActive(true);
                Trigger4.SetActive(true);

            }
        }

        if (Potion3 == true)
        {
            Debug.Log("La potion a conconcter est composée de " + potion3Ingredients);
            // Vérifier si tous les ingrédients pour Potion3 sont présents
            if (other.gameObject.tag == "ChampiBleu")
            {
                Debug.Log(other.gameObject.tag + " est dans le chaudron !");
                NbPotion3 += 1;
                cpt += 1;
                Debug.Log(NbPotion3);
            }

            else if (other.gameObject.tag == "Oeil")
            {
                Debug.Log(other.gameObject.tag + " est dans le chaudron !");
                NbPotion3 += 1;
                cpt += 1;
                Debug.Log(NbPotion3);
            }

            else
            {
                cpt += 1;
                Debug.Log("ON RESET TOUT");
                AjouterNom(other.gameObject.name);
            }

            if (cpt == 2)
            {
                Trigger1.SetActive(true);
                Trigger2.SetActive(true);
                Trigger3.SetActive(true);
                Trigger4.SetActive(true);

            }
        }

        if (Potion4 == true)
        {
            Debug.Log("La potion a conconcter est composée de " + potion4Ingredients);
            // Vérifier si tous les ingrédients pour Potion4 sont présents
            if (other.gameObject.tag == "ChampiRouge")
            {
                Debug.Log(other.gameObject.tag + " est dans le chaudron !");
                NbPotion4 += 1;
                cpt += 1;
                Debug.Log(NbPotion4);
            }

            else if (other.gameObject.tag == "Croc")
            {
                Debug.Log(other.gameObject.tag + " est dans le chaudron !");
                NbPotion4 += 1;
                cpt += 1;
                Debug.Log(NbPotion4);
            }

            else if (other.gameObject.tag == "PlumePhoenix")
            {
                Debug.Log(other.gameObject.tag + " est dans le chaudron !");
                NbPotion4 += 1;
                cpt += 1;
                Debug.Log(NbPotion4);
            }

            else if (other.gameObject.tag == "Crystal")
            {
                Debug.Log(other.gameObject.tag + " est dans le chaudron !");
                NbPotion4 += 1;
                cpt += 1;
                Debug.Log(NbPotion4);
            }

            else
            {
                cpt += 1;
                Debug.Log("ON RESET TOUT");
            }

            if (cpt == 4)
            {
                Trigger1.SetActive(true);
                Trigger2.SetActive(true);
                Trigger3.SetActive(true);
                Trigger4.SetActive(true);

            }
        }
    }

    private bool CheckIngredients(string[] ingredients, Collider trigger)
    {
        // Récupérer les tags du collider
        string[] colliderTags = trigger.gameObject.tag.Split(',');

        foreach (string ingredient in ingredients)
        {
            if (!ContainsIngredient(colliderTags, ingredient))
            {
                // If an ingredient is missing, return false
                return false;
            }
        }

        // Si tous les ingrédients sont présents, retourner true
        return true;
    }

    void AjouterNom(string nom)
    {
        // Cherchez un emplacement vide dans le tableau pour ajouter le nom
        for (int i = 0; i < nomsGameObjects.Length; i++)
        {
            if (string.IsNullOrEmpty(nomsGameObjects[i]))
            {
                nomsGameObjects[i] = nom;
                break; // Sortez de la boucle une fois que le nom a été ajouté
            }
        }
    }

    private bool ContainsIngredient(string[] colliderTags, string ingredient)
    {
        // Check if the ingredient is present in the tags of the collider
        foreach (string tag in colliderTags)
        {
            if (tag == ingredient)
            {
                // If the ingredient is found, return true
                return true;
            }
        }

        // If the ingredient is not found, return false
        return false;
    }

    private void AfficherElementDansChaudron()
    {
        Debug.Log("Élément dans le chaudron : " + elementDansChaudron);
    }

    public void LetsMakePotion1()
    {
        Potion1 = true;
    }

    public void LetsMakePotion2()
    {
        Potion2 = true;
    }
    public void LetsMakePotion3()
    {
        Potion3 = true;
    }
    public void LetsMakePotion4()
    {
        Potion4 = true;
    }

    private void OnCollisionStay(Collision collision)
    {
            Debug.Log(collision.gameObject.name);
            // Récupérer le GameObject de l'autre collider
            GameObject autreObjet = collision.gameObject;

            // Ajouter l'objet à la liste s'il n'est pas déjà présent
            if (!objetsEnCollision.Contains(autreObjet))
            {
                objetsEnCollision.Add(autreObjet);
            }
       
    }

    private void AfficherObjetsEnCollision()
    {
        // Afficher les noms des objets en collision

        Debug.Log("Objets en collision :");
        foreach (GameObject objet in objetsEnCollision)
        {
            Debug.Log(objet.name);
        }

    }
}

// REGLER LE PROBLEME DES INGREDIENTS ET DU NOM DES TRUCS ENTRES DEDANS + FAIRE EN SORTE QUE SI TOUT EST DEDANS ALORS ON PASSE UN BOOLEEN A TRUE ET ENSUITE ON AFFICHE SUR UN CANVA UIg