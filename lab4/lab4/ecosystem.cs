using System;
using System.Collections.Generic;


class LivingOrganism
{
    public int Energy { get; set; }
    public int Age { get; set; }
    public int Size { get; set; }
}


class Animal : LivingOrganism, IReproducible, IPredator
{
    public string Habitat { get; set; }
    public bool IsPredator { get; set; }

    public void Reproduce()
    {
        Console.WriteLine("Animal is reproducing.");
    }

    public void Hunt(LivingOrganism prey)
    {
        Console.WriteLine("Animal is hunting.");
    }
}


class Plant : LivingOrganism, IReproducible
{
    public string Type { get; set; }

    public void Reproduce()
    {
        Console.WriteLine("Plant is reproducing.");
    }
}


class Microorganism : LivingOrganism, IReproducible
{
    public bool IsParasitic { get; set; }

    public void Reproduce()
    {
        Console.WriteLine("Microorganism is reproducing.");
    }
}


interface IReproducible
{
    void Reproduce();
}


interface IPredator
{
    void Hunt(LivingOrganism prey);
}


class Ecosystem
{
    private List<LivingOrganism> organisms = new List<LivingOrganism>();

    public void AddOrganism(LivingOrganism organism)
    {
        organisms.Add(organism);
    }

    public void SimulateEcosystem()
    {
        foreach (var organism in organisms)
        {
            if (organism is IReproducible)
            {
                ((IReproducible)organism).Reproduce();
            }

            if (organism is IPredator)
            {
                foreach (var otherOrganism in organisms)
                {
                    if (organism != otherOrganism)
                    {
                        ((IPredator)organism).Hunt(otherOrganism);
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
        Animal lion = new Animal { Energy = 80, Age = 5, Size = 2, Habitat = "large savanna", IsPredator = true };
        Plant oakTree = new Plant { Energy = 30, Age = 10, Size = 5, Type = "deciduous" };
        Microorganism bacteria = new Microorganism { Energy = 5, Age = 1, Size = 1, IsParasitic = true };

        Ecosystem ecosystem = new Ecosystem();
        ecosystem.AddOrganism(lion);
        ecosystem.AddOrganism(oakTree);
        ecosystem.AddOrganism(bacteria);

        ecosystem.SimulateEcosystem();
    }
}
