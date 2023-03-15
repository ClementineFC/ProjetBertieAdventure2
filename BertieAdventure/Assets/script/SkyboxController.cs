using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class SkyboxController : MonoBehaviour
{
    public Material[] skyboxMaterials; // Tableau de matériaux de Skybox
    public Light sun; // Référence à la source de lumière représentant le soleil

    private int currentSkyboxIndex = 0; // Index actuel dans le tableau de matériaux
    private float skyboxRotationThreshold = 300.0f; // Rotation du soleil qui déclenche le changement de Skybox

    void Update()
    {
        if (sun.transform.rotation.eulerAngles.y > skyboxRotationThreshold && currentSkyboxIndex == 0)
        {
            // Le soleil a dépassé la rotation de déclenchement, changer de Skybox
            RenderSettings.skybox = skyboxMaterials[1];
            RenderSettings.sun = sun;
            currentSkyboxIndex = 1;
        }
        else if (sun.transform.rotation.eulerAngles.y <= skyboxRotationThreshold && currentSkyboxIndex == 1)
        {
            // Le soleil est revenu en dessous de la rotation de déclenchement, revenir au Skybox initial
            RenderSettings.skybox = skyboxMaterials[0];
            RenderSettings.sun = sun;
            currentSkyboxIndex = 0;
        }
    }
}
