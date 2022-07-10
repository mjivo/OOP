﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    public class Tesla : ICar, IElectricCar
    {
        public Tesla(string model, string color, int battery)
        {
            this.Model = model;
            this.Color = color;
            this.Battery = battery;
        }
        public string Color { get; private set; }
        public string Model { get; private set; }
        public int Battery { get; private set; }
        public string Start() => "Engine start";
        public string Stop() => "Breaaak!";

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{Color} Tesla {Model} with {Battery} Batteries");
            sb.AppendLine($"{Start()}");
            sb.AppendLine($"{Stop()}");
            return sb.ToString().TrimEnd();
        }
    }
}
