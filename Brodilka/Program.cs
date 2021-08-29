using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;

/*
 * Создайте иерархию классов и пропишите ключевые методы для компьютерной игры (без
реализации функционала). Суть игры:
• Игрок может передвигаться по прямоугольному полю размером Width на Height;
• На поле располагаются бонусы (яблоко, вишня и т.д.), которые игрок может подобрать для
поднятия каких-либо характеристик;
• За игроком охотятся монстры (волки, медведи и т.д.), которые могут передвигаться по
карте по какому-либо алгоритму;
• На поле располагаются препятствия разных типов (камни, деревья и т.д.), которые игрок и
монстры должны обходить.
 */

namespace Brodilka
{
    public class Program
    {
        private static IContainer Container { get; set; }
        static void Main()
        {
            GameProcessor game = new GameProcessor();

            game.Run();

        }
    }
}
