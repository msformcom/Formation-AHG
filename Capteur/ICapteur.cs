
namespace CapteurNS
{
    public interface ICapteur<TValue>
    {
        IEnumerable<CapteurNewValueEventArgs<TValue>> Historique { get; }

        event EventHandler<CapteurNewValueEventArgs<TValue>> NewValueEvent;

        void StartListening();
        void StopListening();
    }
}