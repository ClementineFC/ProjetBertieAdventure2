using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class SkyboxController : MonoBehaviour
{
    public Material[] skyboxMaterials; // Tableau de mat�riaux de Skybox
    public Light sun; // R�f�rence � la source de lumi�re repr�sentant le soleil

    private int currentSkyboxIndex = 0; // Index actuel dans le tableau de mat�riaux
    private float skyboxRotationThreshold = 300.0f; // Rotation du soleil qui d�clenche le changement de Skybox

    void Update()
    {
        if (sun.transform.rotation.eulerAngles.y > skyboxRotationThreshold && currentSkyboxIndex == 0)
        {
            // Le soleil a d�pass� la rotation de d�clenchement, changer de Skybox
            RenderSettings.skybox = skyboxMaterials[1];
            RenderSettings.sun = sun;
            currentSkyboxIndex = 1;
        }
        else if (sun.transform.rotation.eulerAngles.y <= skyboxRotationThreshold && currentSkyboxIndex == 1)
        {
            // Le soleil est revenu en dessous de la rotation de d�clenchement, revenir au Skybox initial
            RenderSettings.skybox = skyboxMaterials[0];
            RenderSettings.sun = sun;
            currentSkyboxIndex = 0;
        }
    }
}
