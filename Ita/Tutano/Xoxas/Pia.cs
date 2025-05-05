

namespace Ita.Tutano.Xoxas
{
    public class Pia<T>
    {
        public T? Tralha { get; set; }

        public Pia<T>? Prox { get; set; } = null;

        public Pia<T>? Ant { get; set; } = null;

        public Pia(T Content)
        {
            Tralha = Content;
        }

        public Pia(){}

    }
}