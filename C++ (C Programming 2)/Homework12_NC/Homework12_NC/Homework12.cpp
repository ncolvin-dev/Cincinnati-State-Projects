// -------------------------------------------------------------------------------- 
// Name: Nicholas Colvin
// Class: C++
// Abstract: Homework 12. This program will use recursion to perform various tasks
// -------------------------------------------------------------------------------- 
// Includes – built-in libraries of functions 
// -------------------------------------------------------------------------------- 
#define _CRT_SECURE_NO_WARNINGS
#include <iostream>
#include <iomanip>
using namespace std;
// -------------------------------------------------------------------------------- 
// Constants 
// -------------------------------------------------------------------------------- 
// const long lngARRAY_SIZE = 100; 
// -------------------------------------------------------------------------------- 
// User Defined Types (UDT) 
// -------------------------------------------------------------------------------- 
// -------------------------------------------------------------------------------- 
// Prototypes 
// -------------------------------------------------------------------------------- 
int AddNumbers1To100Recusively(int intIndex);
int AddNumbersInRange(int intStartIndex, int intStopIndex);
int CalculateFactoral(int intIndex);
void CalculateFirst20Factorals();
int CalculateFibonacci(int intIndex);
void Print(const char* pstrCaption, int intTotal);

// -------------------------------------------------------------------------------- 
// Name: main 
// Abstract: This is where the program starts 
// -------------------------------------------------------------------------------- 
int main()
{

	// -------------------------------------------------------------------------------- 
	// Step 1
	// -------------------------------------------------------------------------------- 
	
	// Problem #1: Type in the code example and get it working
	int intTotal = 0;
	intTotal = AddNumbers1To100Recusively(0);
	Print("Add Numbers 1 to 100 Recusively", intTotal);


	// Problem #2 - Maximum number of times my PC can handle recursion is = 3577
	// The RAM installed on my system is 32GB


	// Problem #3: Write a procedure, AddNumbersInRange, that takes a starting value and a stop value as parameters.
	intTotal = AddNumbersInRange(0, 100);
	Print("Add Numbers in Range 0 to 100", intTotal);

	// -------------------------------------------------------------------------------- 
	// Step 2
	// --------------------------------------------------------------------------------
	
	// Problem #1: Write a procedure that will recursively find the factorial of a number.
	intTotal = CalculateFactoral(10);
	Print("Find Factoral of 10", intTotal);

	// Problem #2: Calculate the factorial for values 1-20 and display the results.
	CalculateFirst20Factorals();


	// Problem #3 - Maximum number of times my PC can handle recursion of CalculateFactoral is = 3218
	// The RAM installed on my system is 32GB
	
	// -------------------------------------------------------------------------------- 
	// Step 3
	// --------------------------------------------------------------------------------
	intTotal = CalculateFibonacci(10);
	Print("CalculateFibonacci 10", intTotal);

	// Problem #2 - Maximum number of times my PC can handle recursion of CalculateFactoral is = 2928

	return 0;
}



// --------------------------------------------------------------------------------
// Name:  AddNumbers1To100Recusively
// Abstract: Adds Numbers 1 to 100 using recursion
// --------------------------------------------------------------------------------
int AddNumbers1To100Recusively(int intIndex)
{
	int intTotal = 0;

	intIndex += 1;

	intTotal += intIndex;

	// Problem #2 - Maximum number of times my PC can handle recursion is = 3577
	// The RAM installed on my system is 32GB

	// Recurse? 
	if (intIndex < 100)
	{
		// Yes, we are below the limit
		intTotal += AddNumbers1To100Recusively(intIndex);
	}

	return intTotal;
}



// --------------------------------------------------------------------------------
// Name:  AddNumbersInRange
// Abstract: Adds Numbers in a range given
// --------------------------------------------------------------------------------
int AddNumbersInRange(int intStartIndex, int intStopIndex)
{
	int intTotal = 0;

	intTotal += intStartIndex;

	// Problem #2 - Maximum number of times my PC can handle recursion is = 3577

	// Recurse? 
	if (intStartIndex < intStopIndex)
	{
		// Yes, we are below the limit add 1 and recurse
		intStartIndex += 1;
		intTotal += AddNumbersInRange(intStartIndex, intStopIndex);
	}

	return intTotal;
}



// --------------------------------------------------------------------------------
// Name:  CalculateFactoral
// Abstract: Calculates the factoral of a given number
// --------------------------------------------------------------------------------
int CalculateFactoral(int intIndex)
{
	int intFactoral = 0;
	int intRecursiveResult = 0;
	// Is the current factoral = 1?
	if(intIndex <= 1)
	{
		// Yes, Start the chain
		intFactoral = 1;
	}
	else
	{
		// No, Recurse and store the result
		intRecursiveResult = CalculateFactoral(intIndex - 1);

		// Calculate Factoral after receive the result
		intFactoral = intRecursiveResult * intIndex;
	}
	
	return intFactoral;
}



// --------------------------------------------------------------------------------
// Name:  CalculateFirst20Factorals
// Abstract: Calculates the first 20 Factorals, 
//			then displays the result in two columns
// --------------------------------------------------------------------------------
void CalculateFirst20Factorals()
{
	int intIndex = 0;
	int intLeftIndex = 0;
	int intRightIndex = 0;
	unsigned long long ulngLeftFactorial = 0;
	unsigned long long ulngRightFactorial = 0;

	cout << endl;
	cout << "Calculate the first 20 factorals" << endl;
	cout << "-----------------------------------------------" << endl;
	for (intIndex = 0; intIndex < 10; intIndex += 1)
	{
		intLeftIndex = intIndex + 1;
		intRightIndex = intIndex + 11;

		ulngLeftFactorial = CalculateFactoral(intLeftIndex);
		ulngRightFactorial = CalculateFactoral(intRightIndex);

		cout << left
			<< setw(2) << intLeftIndex << ") "              // index + ") "
			<< setw(22) << ulngLeftFactorial
			<< " | "
			<< setw(2) << intRightIndex << ") "
			<< setw(22) << ulngRightFactorial
			<< endl;

	}
}



// --------------------------------------------------------------------------------
// Name:  CalculateFibonacci
// Abstract: Calculates the Fibonacci of a given number
// --------------------------------------------------------------------------------
int CalculateFibonacci(int intIndex)
{
	int intFirstNumber = 0;
	int intSecondNumber = 0;
	int intFibonacci = 0;
	if(intIndex <= 0)
	{
		intFibonacci = 0;
	}
	else if (intIndex == 1 || intIndex == 2)
	{
		intFibonacci = 1;
	}
	else
	{
		// No, recurse and store the result for intFirstNumber and intSecond Number
		intFirstNumber = CalculateFibonacci(intIndex - 1);
		intSecondNumber = CalculateFibonacci(intIndex - 2);
		intFibonacci = intFirstNumber + intSecondNumber;
	}

	return intFibonacci;
}




// --------------------------------------------------------------------------------
// Name:  Print
// Abstract: Prints out the total for test cases
// --------------------------------------------------------------------------------
void Print(const char* pstrCaption, int intTotal)
{
	// Caption
	cout << endl;
	cout << pstrCaption << endl;
	cout << "-----------------------------------------------" << endl;

	// Print the total
	cout << "Total = " << intTotal << endl;

}