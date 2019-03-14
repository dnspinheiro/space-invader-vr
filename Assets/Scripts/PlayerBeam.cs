using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBeam : MonoBehaviour
{
    [SerializeField]
    private GameObject beamPrefab;
    [SerializeField]
    private Image beamEffectCamera;
    private float speedBeamCamera = 3;
    [SerializeField]
    private float delay = 0.5f;
    private float countDelay = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (HUDPlayer.GameOver()) return;
        countDelay += Time.deltaTime;
        if(Input.GetMouseButtonDown(0) && countDelay >= delay)
        {
            countDelay = 0;
            beamEffectCamera.color = new Color(beamEffectCamera.color.r,
                                               beamEffectCamera.color.g,
                                               beamEffectCamera.color.b, 0.75f);
            GameObject beam = Instantiate(beamPrefab, transform.position, beamPrefab.transform.rotation);
            beam.GetComponent<BeamProjectil>().Go(transform.forward);
        }

        if(beamEffectCamera.color.a > 0)
        {
            beamEffectCamera.color = new Color(beamEffectCamera.color.r,
                                               beamEffectCamera.color.g,
                                               beamEffectCamera.color.b, beamEffectCamera.color.a - Time.deltaTime * speedBeamCamera);
        }
    }    
}
