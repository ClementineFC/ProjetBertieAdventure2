using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Skyboxtransition : MonoBehaviour
{
    public Material[] skyboxMaterials; // Tableau de matériaux de Skybox
    public Light sun; // Référence à la source de lumière représentant le soleil
    public float skyboxRotationThreshold = 30.0f; // Rotation du soleil qui déclenche le changement de Skybox
    public float crossFadeDuration = 1.0f; // Durée du fondu enchaîné

    private int currentSkyboxIndex = 0; // Index actuel dans le tableau de matériaux
    private Material crossFadeMaterial; // Matériau de la Skybox de fondu enchaîné
    private float crossFadeStartTime; // Temps de début du fondu enchaîné
    private bool isCrossFading = false; // Indicateur de si un fondu enchaîné est en cours

    void Start()
    {
        // Créer le matériau de la Skybox de fondu enchaîné
        crossFadeMaterial = new Material(Shader.Find("Skybox/Cubemap"));
        crossFadeMaterial.SetInt("_SrcBlend", (int)BlendMode.SrcAlpha);
        crossFadeMaterial.SetInt("_DstBlend", (int)BlendMode.OneMinusSrcAlpha);
        crossFadeMaterial.SetInt("_ZWrite", 0);
        crossFadeMaterial.DisableKeyword("_ALPHATEST_ON");
        crossFadeMaterial.EnableKeyword("_ALPHABLEND_ON");
        crossFadeMaterial.DisableKeyword("_ALPHAPREMULTIPLY_ON");
        crossFadeMaterial.renderQueue = 3000;

        // Affecter le matériel de fondu enchaîné à la Skybox actuelle
        RenderSettings.skybox = crossFadeMaterial;
        RenderSettings.sun = sun;

        // Initialiser le fondu enchaîné
        crossFadeMaterial.SetTexture("_Tex1", skyboxMaterials[0].GetTexture("_Tex"));
        crossFadeMaterial.SetTexture("_Tex2", skyboxMaterials[0].GetTexture("_Tex"));
        crossFadeMaterial.SetFloat("_Blend", 0.0f);
    }

    void Update()
    {
        if (!isCrossFading && sun.transform.rotation.eulerAngles.y > skyboxRotationThreshold && currentSkyboxIndex == 0)
        {
            // Le soleil a dépassé la rotation de déclenchement, commencer le fondu enchaîné
            crossFadeStartTime = Time.time;
            isCrossFading = true;
            currentSkyboxIndex = 1;
        }
        else if (!isCrossFading && sun.transform.rotation.eulerAngles.y <= skyboxRotationThreshold && currentSkyboxIndex == 1)
        {
            // Le soleil est revenu en dessous de la rotation de déclenchement, commencer le fondu enchaîné
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
                // Le fondu enchaîné est terminé, affecter le nouveau matériau de Skybox
                crossFadeMaterial.SetTexture("_Tex1", skyboxMaterials[currentSkyboxIndex].GetTexture("_Tex"));
                crossFadeMaterial.SetTexture("_Tex2", skyboxMaterials[currentSkyboxIndex].GetTexture("_Tex"));
                crossFadeMaterial.SetFloat("_Blend", 0.0f);
                RenderSettings.skybox = skyboxMaterials[currentSkyboxIndex];
                isCrossFading = false;
            }
            else
            {
                // Mettre à jour la valeur de fondu enchaîné
                crossFadeMaterial.SetFloat("_Blend", t);
            }
        }
    }
}
