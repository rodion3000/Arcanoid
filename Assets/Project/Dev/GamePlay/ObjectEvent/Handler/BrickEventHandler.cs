using System.Collections.Generic;
using Project.Dev.GamePlay.ObjectEvent.Event;
using Project.Dev.Meta.UI.HudController;
using Project.Dev.Services.CinemachineService;
using UnityEngine;
using Zenject;

namespace Project.Dev.GamePlay.ObjectEvent.Handler
{
    public class BrickEventHandler : IObjectEventHandler<BrickEvent>
    {
        private readonly Dictionary<int, int> _hits = new();
        private ICinemachineService _cinemachineService;
        private HudController hud;

        [Inject]
        private void Construct(ICinemachineService cinemachineService) => _cinemachineService = cinemachineService;

        public void Handle(BrickEvent obj)
        {
            GameObject brick = obj.Object;

            // Unity fake-null check
            if (brick == null)
                return;

            int id = brick.GetInstanceID();

            // Счётчик ударов
            if (!_hits.ContainsKey(id))
                _hits[id] = 0;

            _hits[id]++;

            int hitCount = _hits[id];

            if (hitCount == 1)
            {
                ApplyDamageVisual(brick, 0.5f);
            }
            else if (hitCount >= 2)
            {
                // Безопасно удаляем
                if (brick != null)
                    Object.Destroy(brick);

                _hits.Remove(id);
            }
        }

        private void ApplyDamageVisual(GameObject brick, float darkness)
        {
            if (!brick.TryGetComponent<SpriteRenderer>(out var renderer))
                return;

            Color c = renderer.color;
            float d = 1f - darkness;

            renderer.color = new Color(
                c.r * d,
                c.g * d,
                c.b * d,
                c.a * 0.7f
            );
        }
    }
}
