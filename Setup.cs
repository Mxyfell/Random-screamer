using BepInEx;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Screamer
{
    [BepInPlugin("ru.MxyfellKek.Screamer", "Screamer", "1.0.0")]
    public class Setup : BaseUnityPlugin
    {
        void Awake()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        void OnDestroy()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
        void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            if (scene.name == "menus") return;

            GameObject screamer = new GameObject("");
            screamer.AddComponent<ScreamerSystem>();
        }
    }
}
