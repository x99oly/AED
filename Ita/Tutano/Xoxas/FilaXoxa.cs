using System.Text;

namespace Ita.Tutano.Xoxas
{
    public class FilaXoxa<T>
    {
        private Pia<T> _head = new Pia<T>();
        private Pia<T> Last { get; set; }

        public FilaXoxa()
        {
            Last = _head;
        }

        public void Enqueue(T Tralha)
        {
            if (_head.Prox == null) {
                _head.Prox = new Pia<T>(Tralha);
                Last = _head.Prox;
                return;
            }

            Last.Prox = new Pia<T>(Tralha);
            Last = Last.Prox;
        }

        public T Dequeue()
        {
            if (_head.Prox == null || _head.Prox.Tralha == null)
                throw new InvalidOperationException("Dequeue from an empty queue is not allowed.");

            T dropped = _head.Prox.Tralha;
            _head.Prox = _head.Prox.Prox;

            return dropped;
        }

        public override string ToString()
        {
             if (_head.Prox == null) return "empty";

            StringBuilder sb = new StringBuilder();

            for (Pia<T> i = _head.Prox; i != null; i = i.Prox!){
                sb.Append($"{i.Tralha} ");
            }
            return sb.ToString().Trim();
        }
    }

}
