using UnityEngine;

public class DifficultyController : MonoBehaviour
{
    public static DifficultyController Instance { get; private set; } 

    public int Difficulty;
    public float[] DifficultyDamage;
    public double[] DifficultyHealth;
    public float[] DifficultyFireRate;
    public float[] DifficultySpeed;
    public float[] DifficultyScore;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            Difficulty = 0;
            DifficultyDamage = new float[] { 1, 1.2f, 1.5f };
            DifficultyHealth = new double[] { 1, 1.5, 2 };
            DifficultyFireRate = new float[] { 1, 1.35f, 1.75f };
            DifficultySpeed = new float[] { 1, 1.2f, 1.35f };
            DifficultyScore = new float[] { 1, 1.5f, 2f};
        }
        else
        {
            Destroy(gameObject); 
        }
    }


}