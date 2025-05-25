using UnityEngine;
using UnityEngine.SceneManagement;

namespace Questronaut.GameFlow
{
    public class SceneLoader : MonoBehaviour
    {
        [SerializeField] private GameObject _loadingScreen;
        public static SceneLoader Instance;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            SceneManager.sceneLoaded += (x,y) => _loadingScreen.SetActive(false);
        }

        private void OnDestroy()
        {
            SceneManager.sceneLoaded -= (x, y) => _loadingScreen.SetActive(false);
        }

        public void LoadScene(int index)
        {
            _loadingScreen.SetActive(true);
            SceneManager.LoadSceneAsync(index, LoadSceneMode.Single);
        }

    }
}
