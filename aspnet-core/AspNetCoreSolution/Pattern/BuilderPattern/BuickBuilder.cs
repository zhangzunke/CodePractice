using System;
using System.Collections.Generic;
using System.Text;

namespace Pattern.BuilderPattern
{
    public class BuickBuilder : Builder
    {
        Car buickCar = new Car();

        public override void BuildCarDoor()
        {
            buickCar.Add("Buick's Door");
        }

        public override void BuildCarEngine()
        {
            buickCar.Add("Buick's Engine");
        }

        public override void BuildCarWheel()
        {
            buickCar.Add("Buick's Wheel");
        }

        public override Car GetCar()
        {
            return buickCar;
        }
    }
}
