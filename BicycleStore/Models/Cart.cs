using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BicycleStore.Models
{
    public class Cart
    {
        private List<Line> lineCollection = new List<Line>();
        public void AddItem(Bicycle bicycle, int Count)
        {
            Line line =
                lineCollection
                .Where(x => x.BicycleInLine.BicycleId == bicycle.BicycleId)
                .FirstOrDefault();
            if (line == null)
            {
                lineCollection.Add(new Line
                {
                    BicycleInLine = bicycle,
                    Count = Count
                });
            }
            else
            {
                line.Count += Count;
            }
        }
        public void RemoveLine(Bicycle bicycle)
        {
            lineCollection.RemoveAll(x => x.BicycleInLine.BicycleId == bicycle.BicycleId);
        }
        public void Clear()
        {
            lineCollection.Clear();
        }
        public decimal ComputeTotalValue()
        {
            return lineCollection.Sum(x => x.BicycleInLine.BicyclePrice * x.Count);
        }

        public IEnumerable<Line> Lines
        {
            get => lineCollection;
            set
            {
                lineCollection = (List<Line>)value;
            }
        }
    }

    public class Line
    {
        public Bicycle BicycleInLine { get; set; }
        public int Count { get; set; }
    }
}