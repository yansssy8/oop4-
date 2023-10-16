using System;
using System.Collections.Generic;


class Computer
{
    public string IPAddress { get; set; }
    public int Power { get; set; }
    public string OperatingSystem { get; set; }
}


class Server : Computer, IConnectable
{
    public int StorageCapacity { get; set; }

    public void Connect(Computer target)
    {
        Console.WriteLine($"Connected to computer with IP {target.IPAddress}");
    }

    public void Disconnect(Computer target)
    {
        Console.WriteLine($"Disconnected from computer with IP {target.IPAddress}");
    }

    public void TransferData(Computer target, string data)
    {
        Console.WriteLine($"Transferred data to computer with IP {target.IPAddress}: {data}");
    }
}


class Workstation : Computer, IConnectable
{
    public string WorkstationType { get; set; }

    public void Connect(Computer target)
    {
        Console.WriteLine($"Connected to computer with IP {target.IPAddress}");
    }

    public void Disconnect(Computer target)
    {
        Console.WriteLine($"Disconnected from computer with IP {target.IPAddress}");
    }

    public void TransferData(Computer target, string data)
    {
        Console.WriteLine($"Transferred data to computer with IP {target.IPAddress}: {data}");
    }
}


class Router : Computer, IConnectable
{
    public int PortCount { get; set; }

    public void Connect(Computer target)
    {
        Console.WriteLine($"Connected to computer with IP {target.IPAddress}");
    }

    public void Disconnect(Computer target)
    {
        Console.WriteLine($"Disconnected from computer with IP {target.IPAddress}");
    }

    public void TransferData(Computer target, string data)
    {
        Console.WriteLine($"Transferred data to computer with IP {target.IPAddress}: {data}");
    }
}


interface IConnectable
{
    void Connect(Computer target);
    void Disconnect(Computer target);
    void TransferData(Computer target, string data);
}


class Network
{
    private List<Computer> computers = new List<Computer>();

    public void AddComputer(Computer computer)
    {
        computers.Add(computer);
    }

    public void SimulateNetwork()
    {
        foreach (var computer in computers)
        {
            if (computer is IConnectable)
            {
                foreach (var otherComputer in computers)
                {
                    if (computer != otherComputer)
                    {
                        ((IConnectable)computer).Connect(otherComputer);
                        ((IConnectable)computer).TransferData(otherComputer, "Sample data");
                        ((IConnectable)computer).Disconnect(otherComputer);
                    }
                }
            }
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Server server = new Server { IPAddress = "192.168.1.1", Power = 1000, OperatingSystem = "Windows Server", StorageCapacity = 10000 };
        Workstation workstation = new Workstation { IPAddress = "192.168.1.2", Power = 500, OperatingSystem = "Windows 10", WorkstationType = "Desktop" };
        Router router = new Router { IPAddress = "192.168.1.3", Power = 200, OperatingSystem = "Custom Router OS", PortCount = 8 };

        Network network = new Network();
        network.AddComputer(server);
        network.AddComputer(workstation);
        network.AddComputer(router);

        network.SimulateNetwork();
    }
}
