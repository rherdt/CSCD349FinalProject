using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCD349FinalProject.Spaces
{
    class Map
    {
        ISpace[,] grid;
        int trapCount;
        int enemyCount;
        int treasureCount;
         
        Map()//default map build
        {
            grid = new ISpace[5,5];
            trapCount = 3;
            enemyCount = 4;
            treasureCount = 2;
        }
        Map(int rows,int col,int traps,int enemy,int treasure)
        {
            grid = new ISpace[rows, col];
            trapCount = traps;
            enemyCount = enemy;
            treasureCount = treasure;
        }
        Map(int rows, int col)
        {
            grid = new ISpace[rows, col];
            Random rand = new Random();
            trapCount = (int)Math.Floor(rand.NextDouble() * rows);
            enemyCount = (int)Math.Floor(rand.NextDouble() * col);
            treasureCount = (int)Math.Floor(rand.NextDouble() * col);
        }
    }
}
