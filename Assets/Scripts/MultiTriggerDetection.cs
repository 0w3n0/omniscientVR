using UnityEngine;

public class MultiTriggerDetection : MonoBehaviour
{
    // Compteurs pour chaque trigger

    public PotionCreation potionCreation;
    private int hautGaucheCounter = 0;
    private int hautDroitCounter = 0;
    private int basGaucheCounter = 0;
    private int basDroitCounter = 0;

    public AudioClip soundToPlay;  // Le son à jouer
    private AudioSource audioSource;  // Le composant AudioSource
    public bool hautgaucheDone = false;
    public bool hautdroitDone = false;
    public bool basgaucheDone = false;
    public bool basdroitDone = false;

    public GameObject Model_potion1;
    public GameObject Model_potion2;
    public GameObject Model_potion3;
    public GameObject Model_potion4;

    // Limite de passages pour chaque trigger
    private int passagesRequis = 5;

    void Update()
    {
        if (hautdroitDone == true && hautgaucheDone == true && basdroitDone == true && basgaucheDone == true)
        {
            Debug.Log("Le chaudron a créé une potion !");
            // Obtenez le composant AudioSource attaché à ce GameObject
            audioSource = GetComponent<AudioSource>();

            // Appelez la méthode TimerFunction avec un délai de 5 secondes
            Invoke("TimerFunction", 5f);
        }
    }

    // Cette méthode est appelée lorsqu'un autre collider entre en collision avec le collider de cet objet (trigger)
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Enter Cauldron");

        if (other.CompareTag("HautGaucheTrigger"))
        {
            hautGaucheCounter++;
            CheckPassages("Haut Gauche", hautGaucheCounter, ref hautgaucheDone);
        }

        else if (other.CompareTag("HautDroitTrigger"))
        {
            hautDroitCounter++;
            CheckPassages("Haut Droit", hautDroitCounter, ref hautdroitDone);
        }

        else if (other.CompareTag("BasGaucheTrigger"))
        {
            basGaucheCounter++;
            CheckPassages("Bas Gauche", basGaucheCounter, ref basgaucheDone);
        }

        else if (other.CompareTag("BasDroitTrigger"))
        {
            basDroitCounter++;
            CheckPassages("Bas Droit", basDroitCounter, ref basdroitDone);
        }
    }

    // Cette méthode est appelée lorsqu'un autre collider quitte la zone du collider de cet objet (trigger englobant)
    private void OnTriggerExit(Collider other)
    {
        // Gérer la sortie des différents triggers
        if (other.CompareTag("CauldronInside"))
        {
            // Réinitialiser les compteurs lorsque le joueur sort de la zone englobante
            ResetCounters();
            Debug.Log("Reset effectué, sorti de la zone prévue.");
        }
    }

    // Vérifier si le nombre de passages atteint la limite requise
    private void CheckPassages(string triggerName, int counter, ref bool hey)
    {
        Debug.Log(counter);
        if (counter >= passagesRequis)
        {
            Debug.Log("Le trigger " + triggerName + " a été franchi au moins 5 fois!");
            // Ajoutez ici le code supplémentaire que vous souhaitez exécuter
            Debug.Log(hey);
            hey = true;
            Debug.Log(hey);
        }
    }

    void TimerFunction()
    {
        if (potionCreation.Potion1 == true)
        {
            // Jouer le son au début du délai
            if (soundToPlay != null)
            {
                audioSource.PlayOneShot(soundToPlay);
            }
            Debug.Log(potionCreation.NbPotion1);
            // Vérifier si maVariable est égale à 3 après le délai
            if (potionCreation.NbPotion1 == 3)
            {
                Debug.Log("Potion1 créée !");
                Model_potion1.SetActive(true);
                potionCreation.PotionDone1 = true;
                potionCreation.Potion2 = true;
                potionCreation.Potion1 = false;
                potionCreation.Trigger1.SetActive(false);
                potionCreation.Trigger2.SetActive(false);
                potionCreation.Trigger3.SetActive(false);
                potionCreation.Trigger4.SetActive(false);
            }
            else
            {
                Debug.Log(potionCreation.nomsGameObjects);
                ResetCounters();
                Vector3 nouvellePosition = new Vector3(1f, 1f, 1f);
                GameObject a = GameObject.Find("PlumePhoenix1"); // Remplacez "NomDeLObjet" par le nom de votre objet
                GameObject b = GameObject.Find("Croc1"); // Remplacez "NomDeLObjet" par le nom de votre objet
                GameObject c = GameObject.Find("ChampiRouge1"); // Remplacez "NomDeLObjet" par le nom de votre objet

                float Xvalue = 0f;
                float Zvalue = 0f;
                Vector3 neVe = new Vector3(0f, 0f, 0f);
                for (int i = 0; i < potionCreation.nomsGameObjects.Length; i++)
                {
                    Xvalue += 1;
                    
                    if (Xvalue % 3f == 0)
                    {
                        Zvalue += 1f;
                        Xvalue = 0f;
                    }
                    Debug.Log(potionCreation.nomsGameObjects[i]);
                    neVe = new Vector3(Xvalue, 1f, Zvalue);
                    GameObject objetTrouve = GameObject.Find(potionCreation.nomsGameObjects[i]);
                    DeplacerObjet(neVe, objetTrouve);
                }

                potionCreation.Trigger1.SetActive(false);
                potionCreation.Trigger2.SetActive(false);
                potionCreation.Trigger3.SetActive(false);
                potionCreation.Trigger4.SetActive(false);
                potionCreation.NbPotion1 = 0;
                Debug.Log("La variable n'est pas égale à 3 après le délai de 5 secondes.");
                Debug.Log(potionCreation.NbPotion1);

                // Remettre à leur place les ingrédients /////////////////////////////////////////////////////
            }
        }

        if (potionCreation.Potion2 == true)
        {
            // Jouer le son au début du délai
            if (soundToPlay != null)
            {
                audioSource.PlayOneShot(soundToPlay);
            }
            Debug.Log(potionCreation.NbPotion2);
            // Vérifier si maVariable est égale à 3 après le délai
            if (potionCreation.NbPotion2 == 2)
            {
                Debug.Log("Potion2 créée !");
                Model_potion2.SetActive(true);
                potionCreation.PotionDone2 = true;
                potionCreation.Potion3 = true;
                potionCreation.Potion2 = false;
                potionCreation.Trigger1.SetActive(false);
                potionCreation.Trigger2.SetActive(false);
                potionCreation.Trigger3.SetActive(false);
                potionCreation.Trigger4.SetActive(false);
            }
            else
            {
                ResetCounters();
                potionCreation.NbPotion2 = 0;
                potionCreation.Trigger1.SetActive(false);
                potionCreation.Trigger2.SetActive(false);
                potionCreation.Trigger3.SetActive(false);
                potionCreation.Trigger4.SetActive(false);
                Debug.Log("La variable n'est pas égale à 3 après le délai de 5 secondes.");
                Debug.Log(potionCreation.NbPotion1);

                // Remettre à leur place les ingrédients /////////////////////////////////////////////////////
            }
        }

        if (potionCreation.Potion3 == true)
        {
            // Jouer le son au début du délai
            if (soundToPlay != null)
            {
                audioSource.PlayOneShot(soundToPlay);
            }
            Debug.Log(potionCreation.NbPotion3);
            // Vérifier si maVariable est égale à 3 après le délai
            if (potionCreation.NbPotion3 == 2)
            {
                Debug.Log("Potion3 créée !");
                Model_potion3.SetActive(true);
                potionCreation.PotionDone3 = true;
                potionCreation.Potion4 = true;
                potionCreation.Potion3 = false;
                potionCreation.Trigger1.SetActive(false);
                potionCreation.Trigger2.SetActive(false);
                potionCreation.Trigger3.SetActive(false);
                potionCreation.Trigger4.SetActive(false);
            }
            else
            {
                ResetCounters();
                potionCreation.NbPotion3 = 0;
                potionCreation.Trigger1.SetActive(false);
                potionCreation.Trigger2.SetActive(false);
                potionCreation.Trigger3.SetActive(false);
                potionCreation.Trigger4.SetActive(false);
                Debug.Log("La variable n'est pas égale à 3 après le délai de 5 secondes.");
                Debug.Log(potionCreation.NbPotion1);

                // Remettre à leur place les ingrédients /////////////////////////////////////////////////////
            }
        }

        if (potionCreation.Potion4 == true)
        {
            // Jouer le son au début du délai
            if (soundToPlay != null)
            {
                audioSource.PlayOneShot(soundToPlay);
            }
            Debug.Log(potionCreation.NbPotion4);
            // Vérifier si maVariable est égale à 3 après le délai
            if (potionCreation.NbPotion4 == 4)
            {
                Debug.Log("Potion4 créée !");
                potionCreation.PotionDone4 = true;
                Model_potion4.SetActive(true);
                potionCreation.Trigger1.SetActive(false);
                potionCreation.Trigger2.SetActive(false);
                potionCreation.Trigger3.SetActive(false);
                potionCreation.Trigger4.SetActive(false);
            }
            else
            {
                ResetCounters();
                potionCreation.Trigger1.SetActive(false);
                potionCreation.Trigger2.SetActive(false);
                potionCreation.Trigger3.SetActive(false);
                potionCreation.Trigger4.SetActive(false);
                potionCreation.NbPotion4 = 0;
                Debug.Log("La variable n'est pas égale à 3 après le délai de 5 secondes.");
                Debug.Log(potionCreation.NbPotion4);

                // Remettre à leur place les ingrédients /////////////////////////////////////////////////////
            }
        }
    }

    void DeplacerObjet(Vector3 nouvellesCoordonnees, GameObject objetADeplacer)
    {
        // Vérifier si l'objet a été trouvé
        if (objetADeplacer != null)
        {
            // Étape 3 : Sauvegarder le vecteur de position de l'objet dans une variable temp
            Vector3 positionInitiale = objetADeplacer.transform.position;

            // Étape 4 : Modifier les coordonnées actuelles de l'objet
            objetADeplacer.transform.position = nouvellesCoordonnees;

            // Afficher des informations dans la console
            Debug.Log("Objet " + objetADeplacer.name + " déplacé de " + positionInitiale + " à " + nouvellesCoordonnees);
        }
        else
        {
            Debug.LogWarning("Objet non trouvé.");
        }
    }

    // Réinitialiser tous les compteurs
    private void ResetCounters()
    {
        potionCreation.cpt = 0;
        hautGaucheCounter = 0;
        hautDroitCounter = 0;
        basGaucheCounter = 0;
        basDroitCounter = 0;

        hautgaucheDone = false;
        hautdroitDone = false;
        basgaucheDone = false;
        basdroitDone = false;
    }
}