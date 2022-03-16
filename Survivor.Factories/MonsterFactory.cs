using Survivor.Models;

namespace Survivor.Factories
{
    public static class MonsterFactory
    {
        public static Monster CreateMonster(string name, int damage)
            => new Monster(name, damage);
    }
}
