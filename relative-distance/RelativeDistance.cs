public class RelativeDistance
{
    private static List<Relative> _tree = [];

    public RelativeDistance(Dictionary<string, string[]> familyTree)
    {
        _tree = [];
        foreach (var node in familyTree)
        {
            var person = new Relative(node.Key);
            if (!_tree.Contains(person))
            {
                _tree.Add(person);
            }

            person = _tree.Find(r => r.Name == node.Key)!;
            List<Relative> siblings = [];
            foreach (var childName in node.Value)
            {
                var child = new Relative(childName);
                if (!_tree.Contains(child))
                {
                    _tree.Add(child);
                }

                person.DirectRelations.Add(child);
                child.DirectRelations.Add(person);
                siblings.Add(child);
            }

            foreach (var child in siblings)
            {
                child.DirectRelations.AddRange(siblings.Except(new List<Relative> { child }).ToList());
            }
        }
    }

    public int DegreeOfSeparation(string personA, string personB)
    {
        List<Relative> directConnections = [];
        Relative pA;
        Relative pB;
        try
        {
            pA = _tree.Find(r => r.Name == personA) ?? throw new InvalidOperationException();
            pB = _tree.Find(r => r.Name == personB) ?? throw new InvalidOperationException();
        }
        catch (InvalidOperationException exception)
        {
            return -1;
        }

        directConnections.AddRange(pA.DirectRelations);


        var counter = 1;
        List<Relative> alreadyChecked = [pA];
        while (true)
        {
            if (directConnections.Count == 0)
            {
                return -1;
            }

            if (directConnections.Contains(pB))
            {
                return counter;
            }

            alreadyChecked.AddRange(directConnections);
            List<Relative> temp = [];
            directConnections.ForEach(x => temp.AddRange(x.DirectRelations));
            directConnections = temp.Except(alreadyChecked).ToList();


            counter++;
        }
    }

    private class Relative(string name)
    {
        public string Name { get; } = name;
        public List<Relative> DirectRelations { get; } = [];
        
        // in this simplified model we don't consider two people with the same name
        public override bool Equals(object? obj) => obj is Relative r && Name.Equals(r.Name);


        public override int GetHashCode() => Name.GetHashCode();
    }
}