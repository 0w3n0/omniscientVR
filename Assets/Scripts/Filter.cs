using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class Filter : MonoBehaviour
{
    public Volume volume; // Référence au volume de post-traitement
    private ColorAdjustments colorAdjustments; // Référence à l'effet Color Adjustments

    void Start()
    {
        // Récupérer la référence au Volume attaché au même GameObject que ce script
        volume = GetComponent<Volume>();
        
        // Tenter de récupérer l'effet Color Adjustments du profil du Volume
        if (volume.profile.TryGet<ColorAdjustments>(out colorAdjustments))
        {
            SetBlackAndWhite(true);
        }
    }

    void SetBlackAndWhite(bool enabled)
    {
        if (colorAdjustments != null)
        {
            // Définir la saturation à -100 pour activer le noir et blanc, ou 0 pour la couleur
            colorAdjustments.saturation.value = enabled ? -100 : 0;
        }
    }
}
