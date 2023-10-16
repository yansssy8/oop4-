using System;
using System.Collections.Generic;
class Road
{
    public double Length { get; set; }
    public double Width { get; set; }
    public int NumberOfLanes { get; set; }
    public double TrafficLevel { get; set; }
}
class Vehicle : IDriveable
{
    public string Type { get; set; }
    public double Speed { get; set; }
    public double Size { get; set; }

    public void Move()
    {
        Console.WriteLine($"Транспортний засіб типу {Type} рухається зі швидкістю {Speed} км/год.");
    }

    public void Stop()
    {
        Console.WriteLine($"Транспортний засіб типу {Type} зупинився.");
    }
}

interface IDriveable
{
    void Move();
    void Stop();
}

class TrafficSimulation
{
    public void SimulateTraffic(Road road, List<Vehicle> vehicles)
    {
        Console.WriteLine($"Дорога довжиною {road.Length} км, шириною {road.Width} м із {road.NumberOfLanes} смугами.");
        Console.WriteLine($"Рівень трафіку на дорозі: {road.TrafficLevel}");

        foreach (var vehicle in vehicles)
        {
            vehicle.Move();
        }
    }
}