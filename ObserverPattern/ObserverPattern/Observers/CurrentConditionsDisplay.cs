using ObserverPattern.Subject;
using System;
using System.Collections.Generic;
using System.Text;

namespace ObserverPattern.Observers
{
    public class CurrentConditionsDisplay : IObserver, IDisplayElement
    {
        private double temperature;
        private double humidity;

        private ISubject weatherData;
        
        public CurrentConditionsDisplay(ISubject weatherData)
        {
            this.weatherData = weatherData;
            weatherData.RegisterObserver(this);
        }
        
        public void Display()
        {
            Console.WriteLine("Current Conditions : " + temperature + "F degress and " + humidity + "% humidity");
        }

        public void Update(double temperature, double humidity, double pressure)
        {
            this.temperature = temperature;
            this.humidity = humidity;
            Display();
        }
    }
}
