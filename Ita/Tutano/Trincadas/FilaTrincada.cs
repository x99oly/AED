
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Ita.Tutano.Trincadas
{
    public class FilaTrincada<T>
    {
        public int Total = 0;
        private int _last = 0;
        private int _cabeca;
        private T[] _queue;
        private int _balancer=2;
        
        public FilaTrincada()
        {
            _queue = new T[_balancer+1];
            _cabeca = 0;
        }

        public FilaTrincada(int length)
        {
            if (length < 1) {
                throw new InvalidOperationException("Fila menor que o permitido.");
            }
            _queue = new T[length+1];
        }

        public void Botar(T tralha)
        {
            if (Total == _queue.Length) {
                Remake();
            }
            int newPos = Walk(_last);
            _queue[newPos] = tralha;
            _last = newPos;
            Total++;
        }

        public T Tirar()
        {
            if (Total == 0) {
                throw new InvalidOperationException("Não é possível retirar de fila vázia.");
            }
            T dropado = _queue[Walk(_cabeca)];
            _cabeca = Walk(_cabeca);
            Total--;
            return dropado;
        }

        private void Remake()
        {
            T[] queue = new T[_queue.Length*_balancer];
            int counter = 0;

            for (int i = _cabeca + 1; counter <= Total; i = Walk(i)){
                queue[counter] = _queue[i];
                counter++;
            }
            _queue = queue;
            _cabeca = -1;
            _last = counter;
        }

        private int Walk(int posicaoAtual) => (posicaoAtual + 1) % _queue.Length;

        public override string ToString()
        {
            if (Total == 0) return "";

            StringBuilder sb = new StringBuilder();
            int pos = Walk(_cabeca);
            do
            {
                bool ultimo = pos == _last;
                string str = ultimo ? $"{_queue[pos]}" : $"{_queue[pos]}, ";
                sb.Append(str);
                pos = Walk(pos);
            }
            while (pos != Walk(_last));

            return sb.ToString();
        }

    }
}