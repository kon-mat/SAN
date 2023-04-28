using Accessibility;
using BeehiveManagmentSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeehiveManagmentSystem.Objects
{
    internal class StingPatrol : Worker, IStingPatrol
    {
        private int _stingerLength = 10;

        public StingPatrol(int weight, List<Job> jobsICanDo, Hive hive) 
            : base(weight, jobsICanDo, hive)
        {
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

                report += $"Kończy {CurrentJob} i zaczyna {Job.Patrol_z_żądłami}";
                CurrentJob = Job.Patrol_z_żądłami.ToString();
                return report;
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
