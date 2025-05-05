using System;
using Ita.Tutano.Trincadas;
using Xunit;

namespace Ita.Tests.Tutano.Trincadas
{
    public class PilhaTrincadaTests
    {
        [Fact]
        public void CriarPilhaComTamanhoInvalido_DeveLancarExcecao()
        {
            Assert.Throws<InvalidOperationException>(() => new PilhaTrincada<int>(0));
        }

        [Fact]
        public void BotarE_Tirar_DeveFuncionarCorretamente()
        {
            var pilha = new PilhaTrincada<string>();
            pilha.Botar("a");
            pilha.Botar("b");
            pilha.Botar("c");

            Assert.Equal("c", pilha.Tirar());
            Assert.Equal("b", pilha.Tirar());
            Assert.Equal("a", pilha.Tirar());
        }

        [Fact]
        public void Tirar_DePilhaVazia_DeveLancarExcecao()
        {
            var pilha = new PilhaTrincada<int>();
            Assert.Throws<InvalidOperationException>(() => pilha.Tirar());
        }

        [Fact]
        public void InserirMaisQueOTamanhoInicial_DeveRedimensionarCorretamente()
        {
            var pilha = new PilhaTrincada<int>(2);
            pilha.Botar(10);
            pilha.Botar(20);
            pilha.Botar(30); // Deve forçar o Remake

            Assert.Equal(30, pilha.Tirar());
            Assert.Equal(20, pilha.Tirar());
            Assert.Equal(10, pilha.Tirar());
        }
    }
}
