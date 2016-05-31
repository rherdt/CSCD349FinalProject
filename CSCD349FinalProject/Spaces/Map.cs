using CSCD349FinalProject.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CSCD349FinalProject.Spaces
{
    class Map
    {
        private ASpace[,] grid;
        private int trapCount;
        private int enemyCount;
        private int treasureCount;
        private Party party;
        private int level;
        private Point currentPosition;
         
        Map()//default map build
        {
            grid = new ASpace[5,5];
            trapCount = 3;
            enemyCount = 4;
            treasureCount = 2;
            level = 1;
            GenerateMap();
        }
        Map(int rows,int col,int traps,int enemy,int treasure)
        {
            grid = new ASpace[rows, col];
            trapCount = traps;
            enemyCount = enemy;
            treasureCount = treasure;
            level = 1;
            GenerateMap();
        }
        public Map(int rows, int col, Party party)
        {
            grid = new ASpace[rows, col];
            Random rand = new Random();
            trapCount = (int)Math.Floor(rand.NextDouble() * rows);
            enemyCount = (int)Math.Floor(rand.NextDouble() * col);
            treasureCount = (int)Math.Floor(rand.NextDouble() * col);
            this.party = party;
            level = 1;
            GenerateMap();
        }
        private void GenerateMap()
        {
            Random rand = new Random();

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
                        IspaceGen(x, y, rand);
                    }
                }
            }
        }
        private void IspaceGen(int x, int y, Random rand)
        {
            
            int temp = rand.Next(0, 1000);
            if (temp >= 0 && temp < 125)
            {
                grid[x, y] = new TreasureSquare();
            }
            else if(temp >= 125 && temp < 300)
            {
                grid[x, y] = new EnemySquare();
            }
            else if(temp >= 300 && temp < 425)
            {
                grid[x, y] = new TrapSquare();
            }
            else
            {
                grid[x, y] = new BlankSquare();
            }
            
        }

        public int GetColumns()
        {
            return this.grid.GetLength(1);
        }

        public int GetRows()
        {
            return this.grid.GetLength(0);
        }

        public ASpace GetBoardSpace(int row, int column)
        {
            if (row > GetRows() - 1 || column > GetColumns() - 1)
                throw new IndexOutOfRangeException("Row or column is out of range");

            return this.grid[row, column];
        }

        public ASpace[,] getGrid()
        {
            return this.grid;
        }

        public void DrawSprite(int row, int col)
        {
            Rectangle rec = new Rectangle();
            //will need to change dynamically based on rectangle size
            rec.Height = 60;
            rec.Width = 60;
            rec.Fill = party.GetImg();
            this.GetBoardSpace(row, col).getSpace().Child = rec;
        }

        public Point GetCurrentPosition()
        {
            return this.currentPosition;
        }

        public void SetCurrentPosition(int row, int column)
        {
            if (row <= this.GetRows() && column < this.GetColumns())
            {
                currentPosition.X = row;
                currentPosition.Y = column;
            }
        }
        public Party getParty()
        {
            return party;
        }
    }
}
