using System.Threading.Tasks;
using UnityEngine;

public class LoadingCircle : MonoBehaviour
{
    [SerializeField] private GameObject[] loadingCicles;
    [SerializeField] private float timeStep;

    private int currentCircleIndex;
    public bool rotate;

    public void StopChangeCicles()
    {
        rotate = false;
    }

    private async Task ChangeCicles()
    {
        while (rotate)
        {
            await Task.Delay((int)(timeStep * 1000));

            loadingCicles[currentCircleIndex].SetActive(false);
            loadingCicles[(currentCircleIndex + 1) % loadingCicles.Length].SetActive(true);

            currentCircleIndex = (currentCircleIndex + 1) % loadingCicles.Length;
        }
    }

    public void StartChangeCircles()
    {
        rotate = true;
        currentCircleIndex = 0;
        loadingCicles[currentCircleIndex].SetActive(true);
        ChangeCicles();
    }
        
}
