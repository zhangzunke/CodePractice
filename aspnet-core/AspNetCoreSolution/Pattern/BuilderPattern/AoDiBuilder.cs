using System;
using System.Collections.Generic;
using System.Text;

namespace Pattern.BuilderPattern
{
    public class AoDiBuilder : Builder
    {
        Car aoDiCar = new Car();

        public override void BuildCarDoor()
        {
            aoDiCar.Add("Aodi's Door");
        }

        public override void BuildCarWheel()
        {
            aoDiCar.Add("Aodi's Wheel");
        }

        public override void BuildCarEngine()
        {
            aoDiCar.Add("Aodi's Engine");
        }

        public override Car GetCar()
        {
            return aoDiCar;
        }
    }
}
