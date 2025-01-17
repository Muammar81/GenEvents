using System.Collections;
using UnityEngine;

namespace Plugins.PanettoneGames.GenEvents.Demo.Scripts
{
    public class CubeGrow : MonoBehaviour,
        IGameEventListener<Void>
    {
        [SerializeField] private VoidEvent gameObjectEvent;
        private Coroutine growRoutine;
        private Vector3 initialScale;
        private readonly float speed = 0.2f;

        private void Awake()
        {
            initialScale = transform.localScale;
        }

        private void OnEnable()
        {
            gameObjectEvent.RegisterListener(this);
        }

        private void OnDisable()
        {
            gameObjectEvent.UnregisterListener(this);
        }

        public void OnEventRaised(Void item)
        {
            if (growRoutine != null)
                StopCoroutine(growRoutine);
            growRoutine = StartCoroutine(Grow());
        }

        private IEnumerator Grow()
        {
            float elapsedTime = 0;

            while (elapsedTime < speed)
            {
                transform.localScale = Vector3.Lerp(Vector3.zero, initialScale, elapsedTime / speed);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            transform.localScale = initialScale;
            yield return null;
        }
    }
}