﻿namespace CarFactoryLibrary
{
    public abstract class Car
    {
        public double velocity { get; set; }
        public DrivingMode drivingMode { get; set; }

        public Car()
        {
            velocity = 0;
            drivingMode = DrivingMode.Stopped;
        }
        public Boolean IsStopped()
        {
            return velocity == 0 ? true : false;
        }

        public void Stop()
        {
            velocity = 0;
            drivingMode = DrivingMode.Stopped;
        }

        public void IncreaseVelocity(double addedVelocity)
        {
            velocity += addedVelocity;
            drivingMode = DrivingMode.Forward;
        }

        public abstract void Accelerate();
        
        public string GetDirection()
        {
            return drivingMode.ToString();
        }

        public Car GetMyCar()
        {
            //return this;   // shallow copy
            
            // deep copy
            return new Toyota() { velocity = this.velocity, drivingMode = this.drivingMode };
        }


        public double TimeToCoverDistance(double distance)
        {
            return distance / velocity;
        }

        public override bool Equals(object? obj)
        {
            Car? car = obj as Car;
            if (car == null) return false;

            return car.velocity == velocity && car.drivingMode == drivingMode;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.drivingMode, this.velocity);
        }
    }
}