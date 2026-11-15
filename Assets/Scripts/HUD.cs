using UnityEngine;
using TMPro;

public class HUDManager : MonoBehaviour
{

    public TextMeshProUGUI TrampolineText; 

    private int TrampolineCount = 0;

    void Update()
    {
        // Exemple : mise à jour du texte à chaque modification
        TrampolineText.text = "Trampolines : " + TrampolineCount.ToString();
    }
}