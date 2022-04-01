using Assets.Scripts.EntityMechanics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.EnemyCharacters
{
    class Bat : BaseEnemy
    {
        public Bat() : base()
        {
            health = new Health(3);
        }

        private void Update()
        {

        }

        private void FixedUpdate()
        {

        }
    }
}
