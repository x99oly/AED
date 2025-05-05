using System;
using Ita.Tutano.Trincadas;
using Xunit;

namespace Ita.Tests.Tutano.Trincadas
{
    public class FilaTrincadaTests
    {
        [Fact]
        public void CriarFilaComTamanhoInvalido_DeveLancarExcecao()
        {
            // Testa a exceção quando a fila é criada com tamanho inválido (menor que 1)
            Assert.Throws<InvalidOperationException>(() => new FilaTrincada<int>(0));
        }

        [Fact]
        public void Validar_TotalNaFila()
        {
            var fila = new FilaTrincada<int>(2);
            
            Assert.Equal(0, fila.Total);

            fila.Botar(1);
            fila.Botar(2);

            Assert.Equal(2, fila.Total);

            fila.Botar(3);
            fila.Botar(4);

            Assert.Equal(4, fila.Total);

            var dropado = fila.Tirar();

            Assert.Equal(1, dropado);
            Assert.Equal(3, fila.Total);

        }

        [Fact]
        public void BotarE_Tirar_DeveFuncionarCorretamente()
        {
            var fila = new FilaTrincada<string>();
            fila.Botar("a");
            fila.Botar("b");
            fila.Botar("c");

            Assert.Equal(3, fila.Total);  // Verifica que o total é 3
            Assert.Equal("a", fila.Tirar());  // O primeiro item inserido deve ser retirado primeiro (FIFO)
            Assert.Equal(2, fila.Total);  // Após tirar 1 item, o total deve ser 2
            Assert.Equal("b", fila.Tirar());  // O segundo item deve ser o próximo a ser retirado
            Assert.Equal("c", fila.Tirar());  // O terceiro item deve ser o último a ser retirado
        }

        [Fact]
        public void Tirar_DeFilaVazia_DeveLancarExcecao()
        {
            var fila = new FilaTrincada<int>();
            // Testa a exceção quando tenta-se tirar de uma fila vazia
            Assert.Throws<InvalidOperationException>(() => fila.Tirar());
        }

        [Fact]
        public void InserirMaisQueOTamanhoInicial_DeveRedimensionarCorretamente()
        {
            var fila = new FilaTrincada<int>(2);
            fila.Botar(10);
            fila.Botar(20);
            fila.Botar(30); // Deve forçar o redimensionamento

            Assert.Equal(3, fila.Total); // Verifica que a fila foi redimensionada corretamente e contém 3 elementos
            Assert.Equal(10, fila.Tirar()); // O primeiro item deve ser 10
            Assert.Equal(20, fila.Tirar()); // O segundo item deve ser 20
            Assert.Equal(30, fila.Tirar()); // O terceiro item deve ser 30
        }

        [Fact]
        public void ToString_DeveRetornarElementosSeparadosPorVirgulaSemVirgulaFinal()
        {
            var fila = new FilaTrincada<int>(5);
            fila.Botar(10);
            fila.Botar(20);
            fila.Botar(30);

            string resultado = fila.ToString();

            Assert.Equal("10, 20, 30", resultado);
        }

        [Fact]
        public void ToString_DeveRefletirOrdemCorretaAposVariosBotaresETiradas()
        {
            var fila = new FilaTrincada<int>(4);

            // Inserções iniciais
            fila.Botar(1);
            fila.Botar(2);
            fila.Botar(3);
            fila.Botar(4);
            Assert.Equal("1, 2, 3, 4", fila.ToString());

            // Remove dois elementos (1 e 2)
            Assert.Equal(1, fila.Tirar());
            Assert.Equal(2, fila.Tirar());
            Assert.Equal("3, 4", fila.ToString());

            // Insere mais elementos (gira a fila)
            fila.Botar(5);
            fila.Botar(6);
            Assert.Equal("3, 4, 5, 6", fila.ToString());

            // Remove mais um
            Assert.Equal(3, fila.Tirar());
            Assert.Equal("4, 5, 6", fila.ToString());

            // Adiciona mais até forçar realocação ou circularidade
            fila.Botar(7);
            fila.Botar(8);
            Assert.Equal("4, 5, 6, 7, 8", fila.ToString());

            // Remove todos
            Assert.Equal(4, fila.Tirar());
            Assert.Equal(5, fila.Tirar());
            Assert.Equal(6, fila.Tirar());
            Assert.Equal(7, fila.Tirar());
            Assert.Equal(8, fila.Tirar());
            Assert.Equal("", fila.ToString()); // Espera-se vazio
        }

    }
}
