namespace MethodChain
{
    public class UnitTest1
    {
        [Fact]
        public void MethodChainTest()
        {
            var car = new Car("Honda", 2);
            Console.WriteLine(car);
            var modificator = new CarModificator(car);
            Console.WriteLine("Let's doubling value");
            modificator.Add(new DoubleValueModificator(car));
            modificator.Add(new DecreaseValueModificator(car));
            modificator.Handle();
            Assert.Equal(3, car.Value);
        }

        [Fact]
        public void Test()
        {
            var game = new Game();
            var goblin = new Goblin(game);
            game.Creatures.Add(goblin);
            Assert.Equal(1, goblin.Attack);
            Assert.Equal(1, goblin.Defense);
        }
    }
}