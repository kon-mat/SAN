using BeehiveManagmentSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeehiveManagmentSystem.Objects
{
    internal class NectarStinger : Worker, INectarCollector//, IStingPatrol
    {
        private double _nectar = 0;
        private Random _random = new Random();
        private int _stingerLength = 10;

        public NectarStinger(int weight, List<Job> jobsICanDo, Hive hive) 
            : base(weight, jobsICanDo, hive)
        {
        }


        public double Nectar { get { return _nectar; } }
        public double NectarLimit { get { return 2 * Weight; } }
        public bool Overloaded { get { return _nectar >= NectarLimit ? true : false; } }

        public bool FindFlowers()
        {
            if (_random.Next(1, 11) <= 8)
                return true;
            return false;
        }

        public double GatherNectar(double nectar)
        {
            if (_nectar + nectar > NectarLimit)
                nectar = NectarLimit - _nectar;
            _nectar += nectar;
            return nectar;
        }

        public double ReturnToHive()
        {
            double returnedNectar = _nectar;
            Hive.ReceiveNectar(_nectar);
            _nectar = 0;
            return returnedNectar;
        }

        public string CollectNectar(bool lastShift)
        {
            string report = "";
            if (Overloaded || lastShift)
            {
                double returnedNectar = ReturnToHive();
                report += $"Dostarczyła {returnedNectar} mg nektaru do bazy.";
            }
            else
            {
                if (FindFlowers())
                {
                    double gatheredNectar = GatherNectar(_random.Next(30, 61) * Weight / 50);
                    report += $"Zebrała {gatheredNectar} mg nektaru. Aktualnie posiada {_nectar} mg.";
                }
                else
                    report += $"Nie udało jej się odnaleźć kwiatów do zbiorów nektaru. Aktualnie posiada {_nectar} mg.";
            }
            return report;
        }


        public double AttackEnemy()
        {
            double damage = (50 - _stingerLength) * 2 + (_stingerLength / 50) * (50 - _stingerLength);
            if (Hive.EnemyHP < damage)
                damage = Hive.EnemyHP;
            return damage;
        }

        public bool SharpenStinger()
        {
            if (_stingerLength >= 10)
            {
                _stingerLength = 10;
                return true;
            }
            return false;
        }

        public string DoPatrol()
        {
            string report = "";
            if (!String.IsNullOrEmpty(CurrentJob) && CurrentJob != Job.Patrol_z_żądłami.ToString())
            {
                if (CurrentJob == Job.Zbieranie_nektaru.ToString())
                {
                    double returnedNectar = ReturnToHive();
                    report += $"Dostarczyła {returnedNectar} mg nektaru do bazy.";
                    return report;
                }
                else
                {
                    report += $"Kończy {CurrentJob} i zaczyna {Job.Patrol_z_żądłami}";
                    CurrentJob = Job.Patrol_z_żądłami.ToString();
                    return report;
                }
            }
            if (!Hive.Attacked || _stingerLength >= 30)
                if (SharpenStinger())
                {
                    report += "Naostrzyła żądło i zaczyna patrolować oklicę ula.";
                    return report;
                }
                else
                {
                    report += "Powinna naostrzyć żadło, ale nie udało jej się...";
                    return report;
                }

            double damageDealt = AttackEnemy();
            if (Hive.DamageEnemy(damageDealt))
                report += $"Zaatakowała wroga za {damageDealt} punktów życia. Pozostało mu {Hive.EnemyHP} punktów. Aktualna długość żądła {_stingerLength}.";
            else
                report += $"Nie udało jej się zaatakować wroga... Pozostało mu {Hive.EnemyHP} punktów. Aktualna długość żądła {_stingerLength}.";
            return report;
        }

        public void GrowStinger()
        {
            _stingerLength++;
        }










    }
}
