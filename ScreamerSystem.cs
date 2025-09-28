using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Screamer
{
    public class ScreamerSystem : MonoBehaviour
    {
        private GameObject canvasScreamer;
        private AudioSource audioScreamer;
        private bool Generate = true;

        void Start()
        {
            SceneManager.sceneLoaded += onSceneLoaded;
            LoadScreamerResources();
        }

        void OnDestroy()
        {
            SceneManager.sceneLoaded -= onSceneLoaded;
        }

        void onSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            LoadScreamerResources();
        }

        void LoadScreamerResources()
        {
            var prefab = Resources.FindObjectsOfTypeAll<GameObject>()
            .FirstOrDefault(go => go.name == "GloboAsesino");
            if (prefab != null)
            {
                GameObject balloon = Instantiate(prefab);
                balloon.name = "";
                Destroy(balloon.GetComponent<GloboAsesino>());
                canvasScreamer = balloon.transform.Find("CanvasScreamer").gameObject;
                audioScreamer = canvasScreamer.GetComponent<AudioSource>();

                if (canvasScreamer != null)
                    canvasScreamer.SetActive(false);
            }
        }

        void Update()
        {
            if (Generate)
            {
                int chance = Random.Range(0, 20001);
                if (chance == 5)
                {
                    StartCoroutine(Screamer());
                }
            }
        }

        IEnumerator Screamer()
        {
            if (canvasScreamer != null && audioScreamer != null)
            {
                Generate = false;
                canvasScreamer.SetActive(value: true);
                audioScreamer.Play();
                yield return new WaitForSeconds(2f);
                canvasScreamer.SetActive(value: false);
                Generate = true;
            }
        }
    }
}