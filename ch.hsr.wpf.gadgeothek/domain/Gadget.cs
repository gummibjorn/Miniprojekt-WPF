using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel;

namespace ch.hsr.wpf.gadgeothek.domain
{
    public class Gadget : INotifyPropertyChanged
    {
        private Condition condition;
        private double price;
        private string manufacturer;
        private string name;

        public string InventoryNumber { get; set; }

        public Condition Condition
        {
            get
            {
                return condition;
            }

            set
            {
                this.condition = value;
                this.OnPropertyChanged("Condition");
            }
        }

        public double Price
        {
            get
            {
                return price;
            }

            set
            {
                this.price = value;
                this.OnPropertyChanged("Price");
            }
        }

        public string Manufacturer
        {
            get
            {
                return manufacturer;
            }

            set
            {
                this.manufacturer = value;
                this.OnPropertyChanged("Manufacturer");
            }
        }

        public string Name {
            get
            {
                return name;
            }

            set
            {
                this.name = value;
                this.OnPropertyChanged("Name");
            }
        }

        // parameterless constructor is needed for automatic json conversion
        public Gadget()
        {
        }

        public Gadget(string name)
        {
            Name = name;
            var bits = Guid.NewGuid().ToByteArray().Take(8).ToArray();
            var nr = BitConverter.ToUInt64(bits, 0);
            InventoryNumber = nr.ToString();
            Condition = Condition.New;
        }

        public override int GetHashCode()
        {
            return InventoryNumber?.GetHashCode() ?? 31;
        }

        public override bool Equals(object obj)
        {
            if (this == obj)
                return true;
            if (obj == null)
                return false;
            var other = obj as Gadget;
            if (other == null)
                return false;
            if (InventoryNumber == null)
                return other.InventoryNumber == null;
            return InventoryNumber == other.InventoryNumber;
        }

        public override string ToString()
        {
            return FullDescription();
        }

        public string ShortDescription()
        {
            return $"{Name} [{InventoryNumber}]";
        }

        public string FullDescription()
        {
            return $"{Name} [{InventoryNumber}] by {Manufacturer} - Condition: {Condition.ToString().ToUpper()}";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
