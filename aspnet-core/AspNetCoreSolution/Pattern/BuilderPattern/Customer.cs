using System;
using System.Collections.Generic;
using System.Text;

namespace Pattern.BuilderPattern
{
    public class Customer
    {
        public static void WantCar()
        {
            Director director = new Director();
            Builder buickCarBuilder = new BuickBuilder();
            director.Construct(buickCarBuilder);
            Car buickCar = buickCarBuilder.GetCar();
            buickCar.Show();

            Builder aoDiCarBuilder = new AoDiBuilder();
            director.Construct(aoDiCarBuilder);
            Car aoDiCard = aoDiCarBuilder.GetCar();
            aoDiCard.Show();
        }
    }
}
