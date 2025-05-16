public static class SquareRoot
{
    
    
    // Heron's Method
    public static int Root(int number)
    {
        // arbitrary
        int currentGuess = number / 2;
        if (currentGuess == 0)
        {
            currentGuess = 1;
        }

        while (currentGuess * currentGuess != number)
        {
            currentGuess = (currentGuess + (number / currentGuess)) / 2;

        }
        return currentGuess;
    }
}
