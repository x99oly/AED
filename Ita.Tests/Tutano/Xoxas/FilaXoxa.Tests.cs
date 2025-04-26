using Xunit;
using Ita.Tutano.Xoxas;

namespace Ita.Tests.Tutano.Xoxas
{
    public class FilaXoxaTests
    {
        [Fact]
        public void Enqueue_AdicionaElementosNaOrdem()
        {
            var fila = new FilaXoxa<int>();
            fila.Enqueue(1);
            fila.Enqueue(2);
            fila.Enqueue(3);

            Assert.Equal("1 2 3", fila.ToString());
        }

        [Fact]
        public void Dequeue_RemoveElementosNaOrdem()
        {
            var fila = new FilaXoxa<int>();
            fila.Enqueue(10);
            fila.Enqueue(20);
            fila.Enqueue(30);

            Assert.Equal(10, fila.Dequeue());
            Assert.Equal(20, fila.Dequeue());
            Assert.Equal(30, fila.Dequeue());
        }

        [Fact]
        public void Dequeue_EmFilaVazia_LancaErro()
        {
            var fila = new FilaXoxa<string>();
            Assert.Throws<InvalidOperationException>(() => fila.Dequeue());
        }

        [Fact]
        public void ToString_EmFilaVazia_RetornaVazia()
        {
            var fila = new FilaXoxa<char>();
            Assert.Equal("empty", fila.ToString());
        }

        [Fact]
        public void Enqueue_EntãoDequeue_EntãoEnqueue_FuncionaCorretamente()
        {
            var fila = new FilaXoxa<string>();
            fila.Enqueue("A");
            fila.Enqueue("B");
            fila.Dequeue();
            fila.Enqueue("C");

            Assert.Equal("B C", fila.ToString());
        }
    }
}
