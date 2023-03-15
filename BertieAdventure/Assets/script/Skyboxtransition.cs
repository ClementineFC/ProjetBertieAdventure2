using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Skyboxtransition : MonoBehaviour
{
    public Material[] skyboxMaterials; // Tableau de mat�riaux de Skybox
    public Light sun; // R�f�rence � la source de lumi�re repr�sentant le soleil
    public float skyboxRotationThreshold = 30.0f; // Rotation du soleil qui d�clenche le changement de Skybox
    public float crossFadeDuration = 1.0f; // Dur�e du fondu encha�n�

    private int currentSkyboxIndex = 0; // Index actuel dans le tableau de mat�riaux
    private Material crossFadeMaterial; // Mat�riau de la Skybox de fondu encha�n�
    private float crossFadeStartTime; // Temps de d�but du fondu encha�n�
    private bool isCrossFading = false; // Indicateur de si un fondu encha�n� est en cours

    void Start()
    {
        // Cr�er le mat�riau de la Skybox de fondu encha�n�
        crossFadeMaterial = new Material(Shader.Find("Skybox/Cubemap"));
        crossFadeMaterial.SetInt("_SrcBlend", (int)BlendMode.SrcAlpha);
        crossFadeMaterial.SetInt("_DstBlend", (int)BlendMode.OneMinusSrcAlpha);
        crossFadeMaterial.SetInt("_ZWrite", 0);
        crossFadeMaterial.DisableKeyword("_ALPHATEST_ON");
        crossFadeMaterial.EnableKeyword("_ALPHABLEND_ON");
        crossFadeMaterial.DisableKeyword("_ALPHAPREMULTIPLY_ON");
        crossFadeMaterial.renderQueue = 3000;

        // Affecter le mat�riel de fondu encha�n� � la Skybox actuelle
        RenderSettings.skybox = crossFadeMaterial;
        RenderSettings.sun = sun;

        // Initialiser le fondu encha�n�
        crossFadeMaterial.SetTexture("_Tex1", skyboxMaterials[0].GetTexture("_Tex"));
        crossFadeMaterial.SetTexture("_Tex2", skyboxMaterials[0].GetTexture("_Tex"));
        crossFadeMaterial.SetFloat("_Blend", 0.0f);
    }

    void Update()
    {
        if (!isCrossFading && sun.transform.rotation.eulerAngles.y > skyboxRotationThreshold && currentSkyboxIndex == 0)
        {
            // Le soleil a d�pass� la rotation de d�clenchement, commencer le fondu encha�n�
            crossFadeStartTime = Time.time;
            isCrossFading = true;
            currentSkyboxIndex = 1;
        }
        else if (!isCrossFading && sun.transform.rotation.eulerAngles.y <= skyboxRotationThreshold && currentSkyboxIndex == 1)
        {
            // Le soleil est revenu en dessous de la rotation de d�clenchement, commencer le fondu encha�n�
            crossFadeStartTime = Time.time;
            isCrossFading = true;
            currentSkyboxIndex = 0;
        }

        if (isCrossFading)
        {
            // Calculer la valeur de fondu en
            float t = Mathf.Clamp01((Time.time - crossFadeStartTime) / crossFadeDuration);

            if (t >= 1.0f)
            {
                // Le fondu encha�n� est termin�, affecter le nouveau mat�riau de Skybox
                crossFadeMaterial.SetTexture("_Tex1", skyboxMaterials[currentSkyboxIndex].GetTexture("_Tex"));
                crossFadeMaterial.SetTexture("_Tex2", skyboxMaterials[currentSkyboxIndex].GetTexture("_Tex"));
                crossFadeMaterial.SetFloat("_Blend", 0.0f);
                RenderSettings.skybox = skyboxMaterials[currentSkyboxIndex];
                isCrossFading = false;
            }
            else
            {
                // Mettre � jour la valeur de fondu encha�n�
                crossFadeMaterial.SetFloat("_Blend", t);
            }
        }
    }
}
