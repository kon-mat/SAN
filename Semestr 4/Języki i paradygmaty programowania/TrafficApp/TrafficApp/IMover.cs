using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TrafficApp
{
    internal interface IMover
    {
        int Id { get; }
        string Registration { get; }
        int Speed { get; }
        int Direction { get; set; }
        (Vector3, Vector3) Wheels { get; }
        List<Vector3> BodyPoints { get; }

        Vector3 NewPosition(int X, int Y);
        void Move();
    }
}
