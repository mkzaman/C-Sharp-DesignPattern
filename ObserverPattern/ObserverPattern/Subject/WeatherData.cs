using ObserverPattern.Observers;
using ObserverPattern.Subject;
using System;
using System.Collections.Generic;
using System.Text;

namespace ObserverPattern
{
    public class WeatherData:ISubject
    {
        List<IObserver> observers;
        private double temperature;
        private double humidity;
        private double pressure;

        public WeatherData()
        {
            observers = new List<IObserver>();
        }

        public void RegisterObserver(IObserver o)
        {
            observers.Add(o);
        }

        public void RemoveObserver(IObserver o)
        {
            observers.Remove(o);
        }

        public void NotifyObservers()
        {
            foreach(var observer in observers)
            {
                IObserver o = observer;
                observer.Update(temperature, humidity, pressure);
            }
        }

        public double GetTemperature()
        {
            return 0.0;
        }

        public double GetHumidity()
        {
            return 0.0;
        }

        public double GetPressure()
        {
            return 0.0;
        }

        public void MeasurementChanged()
        {
            NotifyObservers();
        }

        public void SetMeasurements(double temperature, double humidity, double pressure)
        {
            this.temperature = temperature;
            this.humidity = humidity;
            this.pressure = pressure;

            MeasurementChanged();
        }

    }
}
