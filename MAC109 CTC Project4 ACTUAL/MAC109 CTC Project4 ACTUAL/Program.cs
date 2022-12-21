using System;
using static System.Console;

class Taxi
{
    string taxiId;
    string carMaker;
    string carModel;
    string carColor;
    string driverName;
    int numOfPassengers;
    int totalNum;
    int calls;
    static int totalPassengers;

    public Taxi(string id, string name, string maker, string model, string color)
    {
        taxiId = id;
        driverName = name;
        carMaker = maker;
        carModel = model;
        carColor = color;
        numOfPassengers = 0;
        calls = 0;
    }

    public int getRandomPass()
    {
        Random rnd = new Random();
        return (rnd.Next(4)) + 1;
    }

    public void recordNumOfPassengers()
    {
        totalNum += numOfPassengers;
    }

    public void display()
    {
        numOfPassengers = getRandomPass();
        Write(String.Format("Taxi {0} will pick you up in a few minutes. ", taxiId));
        WriteLine(String.Format("(Taxi {0} determined that there were {1} passengers)", taxiId, numOfPassengers));
        recordNumOfPassengers();
        totalPassengers += numOfPassengers;
        calls += 1;
    }

    public void showRecord()
    {
        if (totalNum > 0)
        {
            WriteLine(String.Format("{0} served {1} passengers.", driverName, totalNum));
        }
    }

    public int totalPassengersServed()
    {
        return totalPassengers;
    }

    public string getTaxiId()
    {
        return taxiId;
    }

    public string getMaker()
    {
        return carMaker;
    }

    public string getModel()
    {
        return carModel;
    }

    public string getColor()
    {
        return carColor;
    }

     public string getDriverName()
    {
        return driverName;
    }


    public int getCalls()
    {
        return calls;
    }

    public int getPassengers()
    {
        return totalNum;
    }

}

class CTCApp
{
    public static void Main(string[] args)
    {

        int totalTaxi = 6;

        Taxi taxi1 = new Taxi("CTC0001", "Nusi", "Toyota", "Camry", "black");
        Taxi taxi2 = new Taxi("CTC0002", "Christian", "Ford", "Explorer", "blue");
        Taxi taxi3 = new Taxi("CTC0003", "Nishi", "Nissan", "Ultima", "gray");
        Taxi taxi4 = new Taxi("CTC0004", "Riri", "Toyota", "Corolla", "gold");
        Taxi taxi5 = new Taxi("CTC0005", "Rafi", "Honda", "CRV", "red");
        Taxi taxi6 = new Taxi("CTC0006", "Ria", "Tesla", "ModelS", "white");

        Taxi[] TaxiList = { taxi1, taxi2, taxi3, taxi4, taxi5, taxi6 };

        char input;
        WriteLine("Welcome to CTC Taxi.");

        while (true)
        {
            WriteLine("\nDo you need a taxi?");
            input = Convert.ToChar(ReadLine());

            if (input == 'N')
            {
                break;
            }

            Random rnd = new Random();
            int select = (rnd.Next(6)) + 1;

            TaxiList[select - 1].display();

        }

        int mostPassengers = 0;
        string totalPassengers = ""; 
        double averagePassengers;

        WriteLine(String.Format("\n\nCTC served a total of {0} passengers today.\n", taxi1.totalPassengersServed()));

        for (int i = 0; i < totalTaxi; i++)
        {
            Write(TaxiList[i].getTaxiId().PadRight(15));
        }

        WriteLine();

        for (int i = 0; i < totalTaxi; i++)
        {
            Write((TaxiList[i].getCalls() + " Calls").PadRight(15));
        }

        WriteLine();

        for (int i = 0; i < totalTaxi; i++)
        {

            int passengers = TaxiList[i].getPassengers();
            Write((passengers + " Passengers").PadRight(15));

            if (passengers >= mostPassengers)
            {
                mostPassengers = passengers;
                totalPassengers = TaxiList[i].getTaxiId();
            }
        }

        averagePassengers = Convert.ToDouble(taxi1.totalPassengersServed()) / totalTaxi;

       
        WriteLine();
        WriteLine("\nToday " + totalPassengers + " served most passengers.");
        WriteLine("\nToday on average each taxi served " + averagePassengers.ToString("0.0") + " passengers.");

    }
}
