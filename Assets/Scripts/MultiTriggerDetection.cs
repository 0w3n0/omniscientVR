using UnityEngine;

public class MultiTriggerDetection : MonoBehaviour
{
    // Compteurs pour chaque trigger
    private int hautGaucheCounter = 0;
    private int hautDroitCounter = 0;
    private int basGaucheCounter = 0;
    private int basDroitCounter = 0;

    public bool hautgaucheDone = false;
    public bool hautdroitDone = false;
    public bool basgaucheDone = false;
    public bool basdroitDone = false;    

    // Limite de passages pour chaque trigger
    private int passagesRequis = 5;

    void Update()
    {
        if(hautdroitDone == true && hautgaucheDone == true && basdroitDone == true && basgaucheDone == true){
            Debug.Log("Le chaudron a créé une potion !");
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

    // Réinitialiser tous les compteurs
    private void ResetCounters()
    {
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