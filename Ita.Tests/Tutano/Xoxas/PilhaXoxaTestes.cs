using Xunit;
using Ita.Tutano.Xoxas;

namespace Ita.Tests.Tutano.Xoxas
{
    public class PilhaXoxaTests
    {
        [Fact]
        public void BotarValores()
        {
            var pilha = new PilhaXoxa<int>(1);
            pilha.Botar(2);
            pilha.Botar(3);
            
            Assert.Equal(3, pilha.Count);
            Assert.Equal("3 2 1", pilha.ToString());
        }

        [Fact]
        public void LargarValores()
        {
            var pilha = new PilhaXoxa<int>(1);
            pilha.Botar(2);

            pilha.Largar();
        
            Assert.Equal(1, pilha.Count);

            pilha.Largar();
            Assert.Equal(0, pilha.Count);

            Assert.Equal("empty", pilha.ToString());
        }

        [Fact]
        public void LargarValoresPegaErro()
        {
            var pilha = new PilhaXoxa<int>();

            Assert.Throws<InvalidOperationException>(() => pilha.Largar());
        }
    }
}
