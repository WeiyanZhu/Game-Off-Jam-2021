using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SystemManager : MonoBehaviour
{
    [Header("Managers")]
    [System.NonSerialized] public static SystemManager instance;
    [SerializeField] private AudioManager audioManager;
    public AudioManager AudioManager{get =>audioManager; private set=> audioManager=value;}  
    [SerializeField] private TextLibrary textLibrary;
    public TextLibrary TextLibrary{get =>textLibrary; private set=> textLibrary=value;}  
    [SerializeField] private InputManager inputManager;
    public InputManager InputManager{get =>inputManager; private set=> inputManager=value;}  
    [SerializeField] private UIManager uiManager;
    public UIManager UIManager{get =>uiManager; private set=> uiManager=value;}  
    [SerializeField] private CurtainManager curtainManager;
    public CurtainManager CurtainManager{get =>curtainManager; private set=> curtainManager=value;} 

    private Language language;
    public Language Language{get =>language; set=> language = value;}

    private bool transitingToDifferentScene = false;
    void Awake()
    {
        if(instance == null){
            instance = this;
            DontDestroyOnLoad(gameObject);
            Initialize();
        }else{
            Destroy(gameObject);
        }
    }

    void Initialize()
    {

    }

    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadSceneRoutine(sceneName));
    }

    private IEnumerator LoadSceneRoutine(string sceneName)
    {
        if(transitingToDifferentScene)
            yield break;
        transitingToDifferentScene = true;
        DontDestroyOnLoad(this.gameObject);
        yield return curtainManager.Fade(0.5f, 1);
        string currentScene = SceneManager.GetActiveScene().name;
        uiManager.CloseObjectInfo();
        AsyncOperation loadOperation = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
        yield return new WaitUntil(() => loadOperation.isDone);

        yield return new WaitForSeconds(0.1f);
        yield return curtainManager.Fade(0.5f, -1);
        transitingToDifferentScene = false;
    }
}
