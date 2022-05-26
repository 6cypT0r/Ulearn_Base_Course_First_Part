private static int GetMinPowerOfTwoLargerThan(int number)
{
    int result = 1;
    while (number >= result)
	{
        result *= 2;
	}
    return result;
}
