
namespace Ita.Tutano.Trincadas
{
    public class PilhaTrincada<T>
    {
        public int Total;
        private int _last = -1;
        private int _startLength = 4;
        private int _balancer = 2;
        private T[] _list;

        public PilhaTrincada(int length)
        {
            if (length < 1) {
                throw new InvalidOperationException("Pilha menor que o permitido.");
            }
            _list = new T[length];
            Total = _last+1;
        } 

        public PilhaTrincada()
        {
            Total = _last+1;
            _list = new T[_startLength];
        }

        public void Botar(T value)
        {
            if (_last == _list.Length - 1 ) {
                Remake();
            }

            _list[_last+1] = value;
            _last++;
        }

        public T Tirar()
        {
            if (_last < 0) {
                throw new InvalidOperationException("Lista vázia.");
            }
            T dropado = _list[_last];
            _last--;
            return dropado;
        }

        private void Remake()
        {
            T[] list = new T[_list.Length*_balancer];

            for (int i = 0; i < _list.Length; i++ ) {
                list[i] = _list[i];
            }
            _list = list;
        }
    }
}