using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // Define the instance variable

    public int sheepAliveCount = 4;
    public float levelTime = 300.0f;
    public float wolfActivationTime = 10.0f;
    public GameObject wolfUIPanel;

    public GameObject wolfGameObject;

    private bool wolfActive = false;
    private float timePassed = 0.0f;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this; // Set the instance to this GameManager
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            timePassed += Time.deltaTime;

            if (!wolfActive && timePassed >= wolfActivationTime)
            {
                ActivateWolf();
                wolfActive = true;
            }

            if (currentTime <= 0)
            {
                currentTime = 0;
            }
        }

    }

    private void ActivateWolf()
    {
        if (wolfGameObject != null)
        {
            wolfGameObject.SetActive(true);
            if (wolfUIPanel != null)
            {
                wolfUIPanel.SetActive(true); // Activate the UI panel
            }
        }
    }

    public float currentTime
    {
        get;
        private set;
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        currentTime = levelTime;
    }
}