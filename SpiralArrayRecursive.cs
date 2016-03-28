using System;

namespace SpiralArrayInsertion
{
	static class SpiralArray
	{
		static int input;
		static int squareLast;
		static int squareCurrent;
		static int[,] resultArray;
		static int[,] finalArray;
		static int stepCurrent;
		static int stepLast;

	
		public static int[,] PerformInsertion(int n)
		{
			//Fills array with its values
			stepCurrent = 0;

			//For check
			stepLast = n * n;

			//How many squares should be calculated recursively 
			squareLast = (n / 2) - 1;

			//Fix for odd n
			if (squareLast % 2 > 0) {
				squareLast++;
			}

			squareCurrent = 0;

			//Initializing array
			finalArray = new int[n,n];

			SquareRecursion (n);

			return finalArray;
		}

		static void SquareRecursion(int n)
		{

			//Insertion of the upper side of the square
			for (int i = squareCurrent; i <= n-1 - squareCurrent; i++) {
				stepCurrent++;
				finalArray [squareCurrent, i] = stepCurrent; 
				//Console.WriteLine (stepCurrent);
			}

			//Add-hoc solution for odd n that termintes the method if needed
			if (stepCurrent == stepLast){
				return;
			}

			//Insertion of the right side of the square
			for (int i = squareCurrent+1; i <= n-1 - squareCurrent; i++) {
				stepCurrent++;
				finalArray [i, n-1 - squareCurrent] = stepCurrent; 
			}

			//Insertion of the lower side of the square
			for (int i = n-1 - squareCurrent-1; i >= squareCurrent; i--) {
				stepCurrent++;
				finalArray [n-1 - squareCurrent, i] = stepCurrent; 
			}

			//Insertion of the left side of the square
			for (int i = n-1 - squareCurrent-1; i >= squareCurrent + 1; i--) {
				stepCurrent++;
				finalArray [i, squareCurrent] = stepCurrent; 
			}

			//Invoke recursion if there are squares available
			if (squareLast != squareCurrent) {
				squareCurrent++;
				SquareRecursion (n);
			}
		}


		public static void Main (string[] args)
		{

			input = 10;

			resultArray = new int[input,input];
			resultArray = PerformInsertion(input);

			//Output in console
			for (int f = 0; f <= input - 1; f++) {
				for (int g = 0; g <= input - 1; g++) {
					Console.Write(resultArray[f,g]);
					Console.Write(" ");
				}
				Console.WriteLine();
			}
			Console.ReadLine ();
		}

	}

}
