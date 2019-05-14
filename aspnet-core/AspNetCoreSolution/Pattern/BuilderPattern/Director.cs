using System;
using System.Collections.Generic;
using System.Text;

namespace Pattern.BuilderPattern
{
    public class Director
    {
        public void Construct(Builder builder)
        {
            builder.BuildCarDoor();
            builder.BuildCarEngine();
            builder.BuildCarWheel();
        }
    }
}
