using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;

namespace BeehiveManagmentSystem.Objects
{
    public class Hive
    {
        private int _shiftNumber = 0;
        private double _nectar = 500;
        private double _honey = 1000;
        private int _alertLevel = 0;
        private double _enemyHP = 0;
        private bool _attacked = false;
        Random _random = new Random();

        

        public int ShiftNumber { get { return _shiftNumber; } }
        public double Nectar { get { return _nectar; } }
        public double Honey { get { return _honey; } }
        public int AlertLevel { get { return _alertLevel; } }
        public double EnemyHP { get { return _enemyHP; } }
        public bool Attacked { get { return _attacked; } }

        internal void NextShift(Queen queen)
        {
            _shiftNumber++;
            if (!_attacked)
                _alertLevel = DrawAlertLevel(queen);
        }
        public bool ReceiveNectar(double nectar)
        {
            if (nectar > 0)
            {
                _nectar += nectar;
                return true;    
            }
            return false;
        }
        public double ShareNectar(double nectar)
        {
            if (nectar <= _nectar)
            {
                _nectar -= nectar;
                return nectar;
            }
            return 0;
        }
        public bool ReceiveHoney(double honey)
        {
            if (honey > 0)
            {
                _honey += honey;
                return true;
            }
            return false;
        }
        public double ShareHoney(double honey)
        {
            if (honey <= _honey)
            {
                _honey -= honey;
                return honey;
            }
            return 0;
        }

        internal int DrawAlertLevel(Queen queen)
        {
            if (_random.Next(1, 11) <= 3)
            {
                bool activePatrol = false;
                foreach (Worker worker in queen.Workers)
                    if (worker is StingPatrol && worker.CurrentJob == Job.Patrol_z_żądłami.ToString())
                        activePatrol = true;


                _attacked = true;
                int rand = _random.Next(1, 101);
                if (rand <= 10)
                {
                    _alertLevel = 3;
                    _enemyHP = activePatrol ? 200 : 400;
                    return 3;
                }

                else
                {
                    if (rand > 40)
                    {
                        _alertLevel = 1;
                        _enemyHP = activePatrol ? 50 : 100;
                        return 1;
                    }
                    else
                    {
                        _alertLevel = 2;
                        _enemyHP = activePatrol ? 125 : 250;
                        return 2;
                    }
                }
            }
            return 0;
        }

        internal bool DamageEnemy(double damage)
        {
            if (damage > 0 && EnemyHP > 0)
            {
                _enemyHP -= damage;
                if (_enemyHP <= 0)
                {
                    _alertLevel = 0;
                    _enemyHP = 0;
                    _attacked = false;
                }
                return true;
            }
            else
                return false;
        }







    }
}
