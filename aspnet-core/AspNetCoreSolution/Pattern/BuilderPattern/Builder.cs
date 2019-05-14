using System;
using System.Collections.Generic;
using System.Text;

namespace Pattern.BuilderPattern
{
    public abstract class Builder
    {
        public abstract void BuildCarDoor();
        public abstract void BuildCarWheel();
        public abstract void BuildCarEngine();
        public abstract Car GetCar();
    }
}
