using System;
using Project.Dev.Services.Interfaces;
using UniRx;
using UnityEngine;
using Zenject;

namespace Project.Dev.GamePlay.ObjectEvent.Event
{
    public class ObjectEventListener : MonoBehaviour
    {
        private IRxEventService _eventService;
        private readonly CompositeDisposable _compositeDisposable = new();

        [Inject]
        private void Construct(IRxEventService eventService)
        {
            _eventService = eventService;
        }

        private void Start()
        {
            _eventService.OnEvent<IObjectEvent>()
                .Subscribe(Dispatch)
                .AddTo(_compositeDisposable);
        }

        private void Dispatch(IObjectEvent obj)
        {
            Type handlerType = typeof(IObjectEventHandler<>).MakeGenericType(obj.GetType());

            object handler = ProjectContext.Instance.Container.TryResolve(handlerType);
            if (handler == null)
                return;

            var method = handlerType.GetMethod("Handle");
            method?.Invoke(handler, new object[] { obj });
        }

        private void OnDestroy()
        {
            _compositeDisposable.Dispose();
        }

    }
}
