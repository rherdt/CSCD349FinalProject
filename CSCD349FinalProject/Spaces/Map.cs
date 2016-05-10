using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCD349FinalProject.Spaces
{
    class Map
    {
        private ISpace[,] grid;
        private int trapCount;
        private int enemyCount;
        private int treasureCount;
        private int level;
         
        Map()//default map build
        {
            grid = new ISpace[5,5];
            trapCount = 3;
            enemyCount = 4;
            treasureCount = 2;
            level = 1;
            GenerateMap();
        }
        Map(int rows,int col,int traps,int enemy,int treasure)
        {
            grid = new ISpace[rows, col];
            trapCount = traps;
            enemyCount = enemy;
            treasureCount = treasure;
            level = 1;
            GenerateMap();
        }
        Map(int rows, int col)
        {
            grid = new ISpace[rows, col];
            Random rand = new Random();
            trapCount = (int)Math.Floor(rand.NextDouble() * rows);
            enemyCount = (int)Math.Floor(rand.NextDouble() * col);
            treasureCount = (int)Math.Floor(rand.NextDouble() * col);
            level = 1;
            GenerateMap();
        }
        private void GenerateMap()
        {
            for(int x = 0; x < grid.GetLength(0); x++)
            {
                for(int y = 0; y < grid.GetLength(1); y++)
                {
                    if(y == 0 || y == (grid.GetLength(1) - 1) || x == 0 || x == (grid.GetLength(0) - 1))
                    {
                        grid[x, y] = new EdgeSquare();
                    }
                    else
                    {
                        IspaceGen(x, y);
                    }
                }
            }
        }
        private void IspaceGen(int x, int y)
        {
            Random rand = new Random();
            int temp = rand.Next(0, 100);
            if (temp < 33)
            {
                grid[x, y] = new TreasureSquare();
            }
            else if(temp < 70)
            {
                grid[x, y] = new EnemySquare();
            }
            else if(temp < 85)
            {
                grid[x, y] = new TrapSquare();
            }
            else
            {
                grid[x, y] = new BlankSquare();
            }
        }
    }
}
