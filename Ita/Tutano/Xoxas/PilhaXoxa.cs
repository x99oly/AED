using System.Text;

namespace Ita.Tutano.Xoxas
{
        public class PilhaXoxa<T>
    {
        public Pia<T>? Last { get; private set; }
        public int Count { get; private set; } = 0;

        public PilhaXoxa(){}
        public PilhaXoxa(T val)
        {
            Botar(val);         
        }

        public void Botar(T val)
        {
            var novoPia = new Pia<T>(val);
            novoPia.Prox = Last;
            Last = novoPia;  
            Count++;        
        }

        public T? Largar()
        {
            if (Last == null || Last.Tralha == null) 
                throw new InvalidOperationException("Any value to exclude.");

            T ripped = Last.Tralha;

            var temp = Last.Prox;
            Last.Prox = null;
            Last = temp;
            Count--;

            return ripped;
        }

        public override string ToString()
        {
            if (Last == null)
                return "empty";

            StringBuilder sb = new StringBuilder();
            for (Pia<T> i = Last; i != null; i = i.Prox!){
                sb.Append($"{i.Tralha} ");
            }
            return sb.ToString().Trim();
        }

    }

}