
namespace Project.Dev.GamePlay.ObjectEvent
{
    public interface IObjectEventHandler<T> where T : IObjectEvent
    {
        void Handle(T obj);
    }
}
