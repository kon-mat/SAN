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
        Vector3 Position { get; }
        Vector3 Destination { get; }
        List<Vector3> CurrentRoad { get; }
        int PositionIndexOfRoad { get; }
        bool DestinationReached { get; }

        string GenerateReport();
        string CurrentLocationName();
        int MovesLeftToDestination();
        string Move();
        Crossroad SetNewDestination();
    
    }
}
