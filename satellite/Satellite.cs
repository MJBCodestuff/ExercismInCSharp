public record Tree(char Value, Tree? Left, Tree? Right);

public static class Satellite
{
    public static Tree? TreeFromTraversals(char[] preOrder, char[] inOrder)
    {
        if (preOrder.Length == 0) return null;
        if (preOrder.Length != inOrder.Length 
            || preOrder.Distinct().Count() != preOrder.Length 
            || inOrder.Distinct().Count() != inOrder.Length
            || inOrder.Any(x => !preOrder.Contains(x))
            || preOrder.Any(x =>  !inOrder.Contains(x))) throw new ArgumentException("Not a valid tree.");
        char[] leftSideInOrder = inOrder.TakeWhile(x => x != preOrder[0]).ToArray();
        char[] rightSideInOrder = inOrder.SkipWhile(x => x != preOrder[0]).ToArray()[1..];
        char[] leftSidePreOrder = preOrder.Where(x => leftSideInOrder.Contains(x)).ToArray();
        char[] rightSidePreOrder = preOrder.Where(x => rightSideInOrder.Contains(x)).ToArray();
        return new Tree(preOrder[0], TreeFromTraversals(leftSidePreOrder, leftSideInOrder), TreeFromTraversals(rightSidePreOrder, rightSideInOrder));

    }
}
