using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WavesSurvived : MonoBehaviour
{
    public TextMeshProUGUI wavesSurvivedText;

    void OnEnable() {
        StartCoroutine(AnimateText());
        // wavesSurvivedText.text = PlayerStats.Waves.ToString();
    }

    IEnumerator AnimateText()
    {

        wavesSurvivedText.text = "0";
        int wave = 0;
        yield return new WaitForSeconds(0.7f);
        while(wave < PlayerStats.Waves)
        {
            wave++;
            wavesSurvivedText.text = wave.ToString();
            yield return new WaitForSeconds(0.05f);
        }
    }



    
}
