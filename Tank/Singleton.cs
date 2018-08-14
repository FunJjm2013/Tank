/*
 * 时间：2012-10-06
 * 创建人：杨卫
 * 说明：基本的操作类
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;

namespace Tank
{
    class Singleton
    {
        private P1Tank p1Tank;

        public P1Tank P1Tank
        {
            get { return p1Tank; }
            set { p1Tank = value; }
        }

        private P2Tank p2Tank;

        public P2Tank P2Tank
        {
            get { return p2Tank; }
            set { p2Tank = value; }
        }
        private Symbol symbol;

        public Symbol Symbol
        {
            get { return symbol; }
            set { symbol = value; }
        }
        public int count;
        #region  私用成员对象
        public List<Enemy> enemy = new List<Enemy>();
        public List<MyMissile> myMissile = new List<MyMissile>();
        public List<EnemyMissile> enemyMissile = new List<EnemyMissile>();
        public List<Blast> blast = new List<Blast>();
        public List<Born> born = new List<Born>();
        public List<Wall> wall = new List<Wall>();
        public List<Water> water = new List<Water>();
        public List<Steel> steel = new List<Steel>();
        public List<Grass> grass = new List<Grass>();
        public List<Equipment> equi = new List<Equipment>();
        #endregion
        private Singleton()
        { }
        private static Singleton instance;

        internal static Singleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Singleton();
                }
                return instance;
            }
        }
        /// <summary>
        /// 创建多线程
        /// </summary>
        public void CreatThread()
        {
            //Thread hitThread = new Thread(new ThreadStart(HitCheck));
            Task.Factory.StartNew(HitCheck);
            //hitThread.Start();
            count = enemy.Count;
        }

        /// <summary>
        /// 添加各种元素
        /// </summary>
        /// <param name="e"></param>
        public void AddElement(Element e)
        {
            #region 添加相应元素
            if (e is P1Tank)
            {
                p1Tank = e as P1Tank;
                return;
            }
            if (e is P2Tank)
            {
                p2Tank = e as P2Tank;
                return;
            }
            if (e is Symbol)
            {
                symbol = e as Symbol;
                return;
            }
            if (e is Enemy)
            {
                enemy.Add(e as Enemy);
                return;
            }
            if (e is MyMissile)
            {
                myMissile.Add(e as MyMissile);
                return;
            }
            if (e is EnemyMissile)
            {
                enemyMissile.Add(e as EnemyMissile);
                return;
            }
            if (e is Blast)
            {
                blast.Add(e as Blast);
                return;
            }
            if (e is Born)
            {
                born.Add(e as Born);
                return;
            }
            if (e is Equipment)
            {
                equi.Add(e as Equipment);
                return;
            }
            if (e is Wall)
            {
                wall.Add(e as Wall);
                return;
            }
            if (e is Steel)
            {
                steel.Add(e as Steel);
                return;
            }
            if (e is Grass)
            {
                grass.Add(e as Grass);
                return;
            }
            if (e is Water)
            {
                water.Add(e as Water);
                return;
            }
            #endregion
        }
        /// <summary>
        /// 画出所有元素
        /// </summary>
        /// <param name="g"></param>
        public void Draw(Graphics g)
        {
            #region  画出对应元素
            
            if (!StartForm.editing)
            {
                p1Tank.Draw(g);
                symbol.Draw(g);
            }
            if (StartForm.isMultiplayer)
            {
                p2Tank.Draw(g);
            }
            for (int i = 0; i < enemy.Count; i++)
            {
                enemy[i].Draw(g);
            }
            for (int i = 0; i < myMissile.Count; i++)
            {
                myMissile[i].Draw(g);
            }
            for (int i = 0; i < enemyMissile.Count; i++)
            {
                enemyMissile[i].Draw(g);
            }
            for (int i = 0; i < blast.Count; i++)
            {
                blast[i].Draw(g);
            }
            for (int i = 0; i < born.Count; i++)
            {
                born[i].Draw(g);
            }
            for (int i = 0; i < equi.Count; i++)
            {
                equi[i].Draw(g);
            }
            for (int i = 0; i < wall.Count; i++)
            {
                wall[i].Draw(g);
            }
            for (int i = 0; i < steel.Count; i++)
            {
                steel[i].Draw(g);
            }
            for (int i = 0; i < water.Count; i++)
            {
                water[i].Draw(g);
            }
            for (int i = 0; i < grass.Count; i++)
            {
                grass[i].Draw(g);
            }
            #endregion
        }

        /// <summary>
        /// 移除元素
        /// </summary>
        /// <param name="e"></param>
        public void RemoveElement(Element e)
        {
            #region  移除对应元素
            if (e is Blast)
            {
                blast.Remove(e as Blast);
                return;
            }
            if (e is Enemy)
            {
                enemy.Remove(e as Enemy);
                return;
            }
            if (e is Wall)
            {
                wall.Remove(e as Wall);
                return;
            }
            if (e is Water)
            {
                water.Remove(e as Water);
                return;
            }
            if (e is Steel)
            {
                steel.Remove(e as Steel);
                return;
            }
            #endregion
        }

        /// <summary>
        /// 碰撞检测
        /// </summary>
        public void HitCheck()
        {
            #region  检测玩家和总部是否和敌方炮弹碰撞
            for (int i = 0; i < enemyMissile.Count; i++)
            {
                if (p1Tank.Live > 0)
                {
                    try
                    {
                        if (p1Tank.GetRectangle().IntersectsWith(enemyMissile[i].GetRectangle()))
                        {
                            p1Tank.Life -= enemyMissile[i].power;
                            enemyMissile.Remove(enemyMissile[i]);
                            p1Tank.IsDead();
                        }
                    }
                    catch (Exception)
                    { }
                    if (StartForm.isMultiplayer && p2Tank.Live > 0)
                    {
                        try
                        {
                            if (p2Tank.GetRectangle().IntersectsWith(enemyMissile[i].GetRectangle()))
                            {
                                p2Tank.Life -= enemyMissile[i].power;
                                enemyMissile.Remove(enemyMissile[i]);
                                p2Tank.IsDead();
                            }
                        }
                        catch (Exception)
                        { }
                    }
                    try
                    {
                        if (enemyMissile[i].GetRectangle().IntersectsWith(symbol.GetRectangle()))
                        {
                            symbol.IsDistory = true;
                            enemyMissile.Remove(enemyMissile[i]);
                        }
                    }
                    catch (Exception)
                    { }
                }
            }
            #endregion
            #region 检测玩家炮弹是否和敌人碰撞
            for (int i = 0; i < myMissile.Count; i++)
            {
                for (int j = 0; j < enemyMissile.Count; j++)
                {
                    try
                    {
                        if (myMissile[i].GetRectangle().IntersectsWith(enemy[j].GetRectangle()))
                        {
                            enemy[j].Life -= myMissile[i].power;
                            myMissile.Remove(myMissile[i]);
                            enemy[j].IsDead();
                        }
                    }
                    catch (Exception)
                    { }
                }
                try
                {
                    if (myMissile[i].GetRectangle().IntersectsWith(symbol.GetRectangle()))
                    {
                        symbol.IsDistory = true;
                        myMissile.Remove(myMissile[i]);
                    }
                }
                catch (Exception)
                {  }
            }
            #endregion
            #region  检测玩家是否与装备碰撞
            for (int i = 0; i < equi.Count; i++)
            {
                try
                {
                    if (p1Tank.GetRectangle().IntersectsWith(equi[i].GetRectangle()))
                    {
                        Equip(equi[i].Flag, 1);
                        equi.Remove(equi[i]);
                    }
                    if (p2Tank.GetRectangle().IntersectsWith(equi[i].GetRectangle()))
                    {
                        Equip(equi[i].Flag, 2);
                        equi.Remove(equi[i]);
                    }
                }
                catch (Exception)
                { }
            }
            #endregion
            #region  检测坦克是否和土墙碰撞
            for (int i = 0; i < wall.Count; i++)
            {

                for (int j = 0; j < enemy.Count; j++)
                {

                    if (enemy[j].GetRectangle().IntersectsWith(wall[i].GetRectangle()))
                    {
                        switch (enemy[j].dir)
                        {
                            case directions.U:
                                enemy[j].Y = wall[i].Y + wall[i].Height;
                                break;
                            case directions.D:
                                enemy[j].Y = wall[i].Y - enemy[j].Height;
                                break;
                            case directions.L:
                                enemy[j].X = wall[i].X + wall[i].Width;
                                break;
                            case directions.R:
                                enemy[j].X = wall[i].X - enemy[j].Width;
                                break;
                            default:
                                break;
                        }
                    }
                }
                if (p1Tank.GetRectangle().IntersectsWith(wall[i].GetRectangle()))
                {
                    switch (p1Tank.dir)
                    {
                        case directions.U:
                            p1Tank.Y = wall[i].Y + wall[i].Height;
                            break;
                        case directions.D:
                            p1Tank.Y = wall[i].Y - p1Tank.Height;
                            break;
                        case directions.L:
                            p1Tank.X = wall[i].X + wall[i].X;
                            break;
                        case directions.R:
                            p1Tank.X = wall[i].X - p1Tank.Width;
                            break;
                        default:
                            break;
                    }
                }
                if (StartForm.isMultiplayer)
                {
                    if (p2Tank.GetRectangle().IntersectsWith(wall[i].GetRectangle()))
                    {
                        switch (p2Tank.dir)
                        {
                            case directions.U:
                                p2Tank.Y = wall[i].Y + wall[i].Height;
                                break;
                            case directions.D:
                                p2Tank.Y = wall[i].Y - p2Tank.Height;
                                break;
                            case directions.L:
                                p2Tank.X = wall[i].X + wall[i].Width;
                                break;
                            case directions.R:
                                p2Tank.X = wall[i].X - p2Tank.Width;
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
            #endregion
            #region  检测坦克是否和铁墙碰撞
            for (int i = 0; i < steel.Count; i++)
            {

                for (int j = 0; j < enemy.Count; j++)
                {

                    if (enemy[j].GetRectangle().IntersectsWith(steel[i].GetRectangle()))
                    {
                        switch (enemy[j].dir)
                        {
                            case directions.U:
                                enemy[j].Y = steel[i].Y + steel[i].Height;
                                break;
                            case directions.D:
                                enemy[j].Y = steel[i].Y - enemy[j].Height;
                                break;
                            case directions.L:
                                enemy[j].X = steel[i].X + steel[i].Width;
                                break;
                            case directions.R:
                                enemy[j].X = steel[i].X - enemy[j].Width;
                                break;
                            default:
                                break;
                        }
                    }
                }
                if (p1Tank.GetRectangle().IntersectsWith(steel[i].GetRectangle()))
                {
                    switch (p1Tank.dir)
                    {
                        case directions.U:
                            p1Tank.Y = steel[i].Y + steel[i].Height;
                            break;
                        case directions.D:
                            p1Tank.Y = steel[i].Y - p1Tank.Height;
                            break;
                        case directions.L:
                            p1Tank.X = steel[i].X + steel[i].X;
                            break;
                        case directions.R:
                            p1Tank.X = steel[i].X - p1Tank.Width;
                            break;
                        default:
                            break;
                    }
                }
                if (StartForm.isMultiplayer)
                {
                    if (p2Tank.GetRectangle().IntersectsWith(steel[i].GetRectangle()))
                    {
                        switch (p2Tank.dir)
                        {
                            case directions.U:
                                p2Tank.Y = steel[i].Y + steel[i].Height;
                                break;
                            case directions.D:
                                p2Tank.Y = steel[i].Y - p2Tank.Height;
                                break;
                            case directions.L:
                                p2Tank.X = steel[i].X + steel[i].Width;
                                break;
                            case directions.R:
                                p2Tank.X = steel[i].X - p2Tank.Width;
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
            #endregion
            #region  检测坦克是否和河水碰撞
            for (int i = 0; i < water.Count; i++)
            {

                for (int j = 0; j < enemy.Count; j++)
                {

                    if (enemy[j].GetRectangle().IntersectsWith(water[i].GetRectangle()))
                    {
                        switch (enemy[j].dir)
                        {
                            case directions.U:
                                enemy[j].Y = water[i].Y + water[i].Height;
                                break;
                            case directions.D:
                                enemy[j].Y = water[i].Y - enemy[j].Height;
                                break;
                            case directions.L:
                                enemy[j].X = water[i].X + water[i].Width;
                                break;
                            case directions.R:
                                enemy[j].X = water[i].X - enemy[j].Width;
                                break;
                            default:
                                break;
                        }
                    }
                }
                if (p1Tank.GetRectangle().IntersectsWith(water[i].GetRectangle()))
                {
                    switch (p1Tank.dir)
                    {
                        case directions.U:
                            p1Tank.Y = water[i].Y + water[i].Height;
                            break;
                        case directions.D:
                            p1Tank.Y = water[i].Y - p1Tank.Height;
                            break;
                        case directions.L:
                            p1Tank.X = water[i].X + water[i].X;
                            break;
                        case directions.R:
                            p1Tank.X = water[i].X - p1Tank.Width;
                            break;
                        default:
                            break;
                    }
                }
                if (StartForm.isMultiplayer)
                {
                    if (p2Tank.GetRectangle().IntersectsWith(water[i].GetRectangle()))
                    {
                        switch (p2Tank.dir)
                        {
                            case directions.U:
                                p2Tank.Y = water[i].Y + water[i].Height;
                                break;
                            case directions.D:
                                p2Tank.Y = water[i].Y - p2Tank.Height;
                                break;
                            case directions.L:
                                p2Tank.X = water[i].X + water[i].Width;
                                break;
                            case directions.R:
                                p2Tank.X = water[i].X - p2Tank.Width;
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
            #endregion
            #region  检测玩家炮弹是否和敌人炮弹相碰
            for (int i = 0; i < myMissile.Count; i++)
            {
                for (int j = 0; j < enemyMissile.Count; j++)
                {
                    try
                    {
                        if (myMissile[i].GetRectangle().IntersectsWith(enemyMissile[j].GetRectangle()))
                        {
                            myMissile.Remove(myMissile[i]);
                            enemyMissile.Remove(enemyMissile[j]);
                        }
                    }
                    catch (Exception)
                    { }
                }
            }
            #endregion
            #region  检测炮弹是否和土墙相碰
            for (int i = 0; i < myMissile.Count; i++)
            {
                for (int j = 0; j < wall.Count; j++)
                {
                    try
                    {
                        if (myMissile[i].GetRectangle().IntersectsWith(wall[j].GetRectangle()))
                        {
                            myMissile.Remove(myMissile[i]);
                            wall.Remove(wall[j]);
                        }
                    }
                    catch (Exception)
                    { }
                }
                for (int j = 0; j < steel.Count; j++)
                {
                    try
                    {
                        if (myMissile[i].GetRectangle().IntersectsWith(steel[j].GetRectangle()))
                        {
                            myMissile.Remove(myMissile[i]);
                        }
                    }
                    catch (Exception)
                    { }
                }
            }
            for (int i = 0; i < enemyMissile.Count; i++)
            {
                for (int j = 0; j < wall.Count; j++)
                {
                    try
                    {
                        if (enemyMissile[i].GetRectangle().IntersectsWith(wall[j].GetRectangle()))
                        {
                            enemyMissile.Remove(enemyMissile[i]);
                            wall.Remove(wall[j]);
                        }
                    }
                    catch (Exception)
                    { }
                }
                for (int j = 0; j < steel.Count; j++)
                {
                    try
                    {
                        if (enemyMissile[i].GetRectangle().IntersectsWith(steel[j].GetRectangle()))
                        {
                            enemyMissile.Remove(enemyMissile[i]);
                        }
                    }
                    catch (Exception)
                    { }
                }
            }
            #endregion
        }

        /// <summary>
        /// 移除地图组件土墙、河水、草地、铁墙
        /// </summary>
        public void RemoveImg()
        {
            for (int i = 0; i < wall.Count; i++)
            {
                try
                {
                    if (!EditFrom.arrWall[wall[i].X / 15, wall[i].Y / 15])
                    {
                        wall.Remove(wall[i]);
                    }
                }
                catch (Exception)
                { }
            }
            for (int i = 0; i < grass.Count; i++)
            {
                try
                {
                    if (!EditFrom.strArr[grass[i].X / 60, grass[i].Y / 60])
                    {
                        grass.Remove(grass[i]);
                    }
                }
                catch (Exception)
                { }
            }
            for (int i = 0; i < water.Count; i++)
            {
                try
                {
                    if (!EditFrom.strArr[water[i].X / 60, water[i].Y / 60])
                    {
                        water.Remove(water[i]);
                    }
                }
                catch (Exception)
                { }
            }
            for (int i = 0; i < steel.Count; i++)
            {
                try
                {
                    if (!EditFrom.arrSteel[steel[i].X / 30, steel[i].Y / 30])
                    {
                        steel.Remove(steel[i]);
                    }
                }
                catch (Exception)
                { }
            }
        }

        /// <summary>
        /// 给坦克加装备
        /// </summary>
        /// <param name="type">装备类型</param>
        public void Equip(int type, int player)
        {
            switch (type)
            {
                case 0:
                    if (player == 1)
                    {
                        if (p1Tank.MisLv < 2)
                        {
                            p1Tank.MisLv++;
                            return;
                        }
                        if (p1Tank.MisLv == 2)
                        {
                            p1Tank.Live++;
                            return;
                        }
                    }
                    else
                    {
                        if (p2Tank.MisLv < 2)
                        {
                            p2Tank.MisLv++;
                            return;
                        }
                        if (p1Tank.MisLv == 2)
                        {
                            p2Tank.Live++;
                            return;
                        }
                    }
                    break;
                case 1:
                    for (int i = 0; i < enemy.Count; i++)
                    {
                        enemy[i].Life = 0;
                        enemy[i].IsDead();
                    }
                    break;
                case 2:
                    for (int i = 0; i < enemy.Count; i++)
                    {
                        enemy[i].Enable = false;
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
