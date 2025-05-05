using System.Text;

namespace Ita.Tutano.Xoxas
{
    public class ListaXoxa<T>
    {
        private Pia<T> _head = new Pia<T>();
        private Pia<T> Last = new Pia<T>();

        public int Count {get; private set;} = 0;

        public ListaXoxa(){}

        public T Tirar()
        {
            return Tirar(Count-1);
        }

        public T Tirar(int pos)
        {
            if (_head.Prox == null) throw new InvalidOperationException("Lista está vázia.");
            
            if (pos < 0 || pos >= Count) throw new ArgumentOutOfRangeException(nameof(pos), "Posição inválida.");

            T ripped;
            Pia<T> previous = _head;
            int ctt = 0;

            for (Pia<T> current = _head.Prox; current != null; current = current.Prox!)
            {
                if (ctt == pos)
                {
                    ripped = current.Tralha!;
                    previous.Prox = current.Prox;

                    if (previous.Prox == null)
                    {
                        Last = previous;
                    }

                    Count--;
                    return ripped;
                }
                previous = current;
                ctt++;
            }

            throw new ArgumentOutOfRangeException(nameof(pos), "Posição inválida.");
        }

        public void Botar(T Tralha)
        {
            Botar(Tralha, Count);
        }

        public void Botar(T Tralha, int pos)
        {
            if (pos > Count || pos < 0 )
                throw new ArgumentOutOfRangeException(nameof(pos),"Posição fora dos limites da lista.");

            if (_head.Prox == null) {
                BotarPrimeiro(Tralha);

            } else if (pos == 0) {
                BotarNoInicio(Tralha);

            } else if (pos == Count) {
                BotarNoFim(Tralha);
            }
             else {
                BotarNoMeio(Tralha, pos);                
            } 
            Count++;
        }

        private void BotarNoInicio(T Tralha)
        {
            Pia<T> Pia = new Pia<T>(Tralha);
            Pia.Prox = _head.Prox;
            _head.Prox = Pia;
        }

        private void BotarNoFim(T Tralha)
        {
            Pia<T> Pia = new Pia<T>(Tralha);
            Last.Prox = Pia;
            Last = Pia;
        }

        private void BotarNoMeio(T Tralha, int position)
        {
            Pia<T> Pia = new Pia<T>(Tralha);
            int ct = 0;
            for (Pia<T> i = _head.Prox!; i != null; i = i.Prox!)
            {
                if (ct == position-1)
                {
                    Pia.Prox = i.Prox;
                    i.Prox = Pia;
                    break;
                }
                ct++;
            }
        }
       
        private void BotarPrimeiro(T Tralha)
        {
            Pia<T> Pia = new Pia<T>(Tralha);

            _head.Prox = Pia;
            Last = Pia;
        }

        public override string? ToString()
        {
            if (_head.Prox == null) return null;

            StringBuilder sb = new StringBuilder();

            for (Pia<T> i = _head.Prox; i != null; i = i.Prox!)
            {
                sb.Append($"{i.Tralha} ");
            }

            return sb.ToString().TrimEnd();
        }
        
    }
}