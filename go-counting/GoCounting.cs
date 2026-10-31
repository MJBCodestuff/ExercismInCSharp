public enum Owner
{
    None,
    Black,
    White
}

public class GoCounting
{

    private string[] board;
    private Dictionary<HashSet<(int, int)>, Owner> reverseLookup = new Dictionary<HashSet<(int, int)>, Owner>();
    private Dictionary<Owner, HashSet<(int, int)>> lookup = new Dictionary<Owner, HashSet<(int, int)>>();
    public GoCounting(string input)
    {
        board = input.Split("\n");
        CreateLookup();
        
    }

    public Tuple<Owner, HashSet<(int, int)>> Territory((int, int) coord)
    {
        HashSet<(int, int)> key = new HashSet<(int, int)>();
        foreach (var territory in reverseLookup.Keys){
            if (territory.Contains(coord)){
                key = territory;
                break;
            }
        }
        return new Tuple<Owner, HashSet<(int, int)>>(reverseLookup[key], key);
    }

    public Dictionary<Owner, HashSet<(int, int)>> Territories()
    {
        return lookup;
    }

    private void CreateLookup(){
        List<(int, int)> emptySpaces = new List<(int, int)>();
        for (var y = 0; y < board.Count(); y++){
            for (var x = 0; x < board[y].Length; x++){
                if (board[y][x] == ' '){
                    emptySpaces.Add((x, y));
                }
            }
        }
        List<HashSet<(int, int)>> territories = new List<HashSet<(int, int)>>();
        foreach ((int, int) space in emptySpaces){
            var foundOne = false;
            for (var i = 0; i < territories.Count; i++){
                var territory = territories[i];
                foreach (var intersection in territory){
                    if (Math.Abs(space.Item1 - intersection.Item1) == 1 ^
                        Math.Abs(space.Item2 - intersection.Item2) == 1){
                            foundOne = true;
                            territory.Add(space);
                            break;
                    }
                        
                }
            }
            if(!foundOne){
                territories.Add(new HashSet<(int, int)>([(space.Item1, space.Item2)]));        
            }
                
        }
        lookup.Add(Owner.None, new HashSet<(int, int)>());
        lookup.Add(Owner.White, new HashSet<(int, int)>());
        lookup.Add(Owner.Black, new HashSet<(int, int)>());
        foreach (HashSet<(int, int)> territory in territories){
            
            var currentOwner = Owner.None;
            foreach ((int, int) space in territory){
                char[] directions = {' ',' ',' ',' '};
                if (space.Item2 > 1){ // North possible
                    directions[0] = board[space.Item2 - 1][space.Item1];
                }
                if (space.Item1 < board[0].Length - 1){ // East possible
                    directions[1] = board[space.Item2][space.Item1 + 1];
                }
                if (space.Item2 < board.Length - 1){ // South possible
                    directions[2] = board[space.Item2 + 1][space.Item1];
                }
                if (space.Item1 > 1){
                    directions[3] = board[space.Item2][space.Item1 - 1];
                }
                if (directions.Contains('B') && directions.Contains('W') 
                    || directions.Contains('B') && currentOwner == Owner.White
                    || directions.Contains('W') && currentOwner == Owner.Black){
                    currentOwner = Owner.None;
                    break;
                }
                if (directions.Contains('B')){
                    currentOwner = Owner.Black;
                }
                if (directions.Contains('W')){
                    currentOwner = Owner.White;
                }
                
            }
            foreach (var place in territory){
                lookup[currentOwner].Add(place);    
            }
            reverseLookup.Add(territory, currentOwner);
        }
    }
}
