using System.Text;

namespace SharkTaxonomy
{
    public class Classifier
    {
        public int Capacity { get; set; }
        public List<Shark> Species { get; set; }
        public int GetCount { get => Species.Count; }

        public Classifier(int capacity)
        {
            Capacity = capacity;
            Species = new List<Shark>();
        }

        public void AddShark(Shark shark)
        {
            if (Species.Count < Capacity && !Species.Contains(shark))
            {
                Species.Add(shark);
            }
        }

        public bool RemoveShark(string kind)
        {
            Shark findShark = Species.Find(s => s.Kind == kind);
            if (findShark != null)
            {
                Species.Remove(findShark);
                return true;
            }
            return false;
        }

        public string GetLargestShark()
        {
            Shark findShark = Species.MaxBy(s => s.Length);
            return findShark.ToString();
        }

        public double GetAverageLength()
        {
            double result = 0;
            foreach (Shark shark in Species)
            {
                result += shark.Length;
            }
            result = result / Species.Count;
            return result;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{Species.Count} sharks classified:");
            foreach (Shark shark in Species)
            {
                sb.AppendLine(shark.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
