using System.Collections.Generic;
using Project.Dev.GamePlay.ObjectEvent.Event;
using UnityEngine;

namespace Project.Dev.GamePlay.ObjectEvent.Handler
{
    public class BrickEventHandler : IObjectEventHandler<BrickEvent>
    {
        // Каждый кирпич → количество ударов
        private readonly Dictionary<GameObject, int> _hits = new();

        public void Handle(BrickEvent obj)
        {
            GameObject brick = obj.Object;

            if (brick == null)
                return;

            // Считаем удар
            if (!_hits.ContainsKey(brick))
                _hits[brick] = 0;

            _hits[brick]++;

            int hitCount = _hits[brick];

            // 1 удар → визуальный урон
            if (hitCount == 1)
            {
                ApplyDamageVisual(brick, 0.5f); // 50% затемнение
            }
            // 2 удар → уничтожение
            else if (hitCount >= 2)
            {
                Object.Destroy(brick);
                _hits.Remove(brick);
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
                c.a * 0.7f // немного прозрачнее
            );
        }
    }
}
