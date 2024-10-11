using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResultDetails : MonoBehaviour
{
    [SerializeField] private TMP_Text vaseCuantityText;
    [SerializeField] private TMP_Text amforaCuantityText;
    [SerializeField] private TMP_Text grapeCuantityText;
    [SerializeField] private TMP_Text oliveCuantityText;

    public void SetResultsDetails(Dictionary<ItemType, int> results)
    {
        vaseCuantityText.text = results[ItemType.Vase].ToString();
        amforaCuantityText.text = results[ItemType.Amfora].ToString();
        grapeCuantityText.text = results[ItemType.Grape].ToString();
        oliveCuantityText.text = results[ItemType.Olive].ToString();
    }
}
