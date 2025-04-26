using Xunit;
using Ita.Tutano.Xoxas;

namespace Ita.Tutano.Tests
{
    public class ListaXoxaTests
    {
        [Fact]
        public void Botar_ShouldAddNodeAtStart_WhenListIsEmpty()
        {
            var list = new ListaXoxa<int>();
            list.Botar(1, 0);

            Assert.Equal(1, list.Count);
            Assert.Equal("1", list.ToString());
        }

        [Fact]
        public void Botar_ShouldAddNodeAtEnd_WhenListIsEmpty()
        {
            var list = new ListaXoxa<int>();
            list.Botar(1);

            Assert.Equal(1, list.Count);
            Assert.Equal("1", list.ToString());
        }

        [Fact]
        public void Botar_ShouldAddNodeAtSpecifiedPosition()
        {
            var list = new ListaXoxa<int>();
            list.Botar(1);
            list.Botar(2);

            list.Botar(3, 1);

            Assert.Equal(3, list.Count);
            Assert.Equal("1 3 2", list.ToString());
        }

        [Fact]
        public void Botar_ShouldThrowException_WhenPositionIsInvalid()
        {
            var list = new ListaXoxa<int>();
            list.Botar(1);

            Assert.Throws<ArgumentOutOfRangeException>(() => list.Botar(2, 3));
        }

        [Fact]
        public void Botar_ShouldAddNode_WhenListIsEmpty()
        {
            var list = new ListaXoxa<int>();
            list.Botar(1, 0);

            Assert.Equal(1, list.Count);
            Assert.Equal("1", list.ToString());
        }

        [Fact]
        public void Botar_ShouldAddMultipleNodesInOrder()
        {
            var list = new ListaXoxa<int>();

            list.Botar(1);
            list.Botar(2, 0);
            list.Botar(3);

            Assert.Equal(3, list.Count);
            Assert.Equal("2 1 3", list.ToString());
        }

        [Fact]
        public void Botar_ShouldInsertAtPositionZero()
        {
            var list = new ListaXoxa<int>();
            list.Botar(1);
            list.Botar(2);

            list.Botar(3, 0);

            Assert.Equal(3, list.Count);
            Assert.Equal("3 1 2", list.ToString());
        }

        [Fact]
        public void Botar_ShouldAddNodeAtEnd_WhenListHasOnlyOneElement()
        {
            var list = new ListaXoxa<int>();
            list.Botar(1, 0);

            list.Botar(2);

            Assert.Equal(2, list.Count);
            Assert.Equal("1 2", list.ToString());
        }

        [Fact]
        public void Count_ShouldReturnCorrectCount_AfterMultipleInsertions()
        {
            var list = new ListaXoxa<int>();
            list.Botar(1);
            list.Botar(2);

            var count = list.Count;

            Assert.Equal(2, count);
        }

        [Fact]
        public void ToString_ShouldReturnCorrectString_AfterInsertions()
        {
            var list = new ListaXoxa<int>();
            list.Botar(1);
            list.Botar(2);
            list.Botar(3);

            var result = list.ToString();

            Assert.Equal("1 2 3", result);
        }

        [Fact]
        public void Tirar_RemovesFirstElement()
        {
            var list = new ListaXoxa<int>();
            list.Botar(1);
            list.Botar(2);
            list.Botar(3);

            var removedValue = list.Tirar(0);

            Assert.Equal(1, removedValue);
            Assert.Equal(2, list.Count);
            Assert.Equal("2 3", list.ToString());
        }

        [Fact]
        public void Tirar_RemovesLastElement()
        {
            var list = new ListaXoxa<int>();
            list.Botar(1);
            list.Botar(2);
            list.Botar(3);

            var removedValue = list.Tirar(2);

            Assert.Equal(3, removedValue);
            Assert.Equal(2, list.Count);
            Assert.Equal("1 2", list.ToString());
        }

        [Fact]
        public void Tirar_RemovesElementInMiddle()
        {
            var list = new ListaXoxa<int>();
            list.Botar(1);
            list.Botar(2);
            list.Botar(3);
            list.Botar(4);

            var removedValue = list.Tirar(2);

            Assert.Equal(3, removedValue);
            Assert.Equal(3, list.Count);
            Assert.Equal("1 2 4", list.ToString());
        }

        [Fact]
        public void Tirar_ThrowsException_WhenListIsEmpty()
        {
            var list = new ListaXoxa<int>();

            Assert.Throws<InvalidOperationException>(() => list.Tirar(1));
        }

        [Fact]
        public void Tirar_ThrowsException_WhenPositionIsInvalid()
        {
            var list = new ListaXoxa<int>();
            list.Botar(1);
            list.Botar(2);

            Assert.Throws<ArgumentOutOfRangeException>(() => list.Tirar(3));
        }

        [Fact]
        public void Tirar_ShouldRemoveLastWhenNoArgumentWasGiven()
        {
            var list = new ListaXoxa<int>();

            list.Botar(1);
            list.Botar(2);
            list.Botar(3);

            list.Tirar();

            Assert.Equal("1 2", list.ToString());
        }
    }
}