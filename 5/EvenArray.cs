public static int[] GetFirstEvenNumbers(int count)
{
	int [] array = new int [count];
	int number = 0 ;
	for  ( int counter = 0; counter < count; counter++)
	{
		number = (counter + 1 ) * 2;
		array [counter] = number;
	}
	return array;
}
