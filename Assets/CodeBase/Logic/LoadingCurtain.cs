using System;
using System.Collections;
using UnityEngine;
namespace CodeBase.Logic
{
    public class LoadingCurtain : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _canvasGroup;

        private void Awake() => DontDestroyOnLoad(gameObject);

        public void Show()
        {
            gameObject.SetActive(true);
            _canvasGroup.alpha = 1f;
        }
        
        public void Hide()
        {
            StartCoroutine(FideIn());
        }

        private IEnumerator FideIn()
        {
            while (_canvasGroup.alpha > 0)
            {
                _canvasGroup.alpha -= 0.2f;
                yield return new WaitForSeconds(0.1f);
            }
            gameObject.SetActive(false);
        }

    }
}