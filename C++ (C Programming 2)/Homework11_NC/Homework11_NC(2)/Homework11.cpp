// -------------------------------------------------------------------------------- 
// Name: Nicholas Colvin
// Class: C++
// Abstract: Homework 8. Deep Copy + Operator Overloading
// -------------------------------------------------------------------------------- 
// -------------------------------------------------------------------------------- 
// Includes – built-in libraries of functions 
// -------------------------------------------------------------------------------- 
#include <iostream>
#include <iomanip> 
#include <vector> 
#include "CResizableArray.h"
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
template <typename GenericDataType>
void Test1(CResizableArray<GenericDataType>& clsValues);  // Forward declaration for Test1
template <typename GenericDataType>
void Test2(CResizableArray<GenericDataType> clsValues);   // Forward declaration for Test2

// -------------------------------------------------------------------------------- 
// Name: main 
// Abstract: This is where the program starts 
// -------------------------------------------------------------------------------- 
int main()
{
	cout << "--Long Test Cases---------------------" << endl;

	CResizableArray<long> clsValuesLong;

	// Create the array
	clsValuesLong.SetSize(4);

	// Populate Array (value, index)
	clsValuesLong[0] = 2;
	clsValuesLong[1] = 4;
	clsValuesLong[2] = 6;
	clsValuesLong[3] = 8;

	clsValuesLong.Print("After populate array 2, 4, 6, 8");

	// Test 1
	clsValuesLong.Print("Before Test 1");
	Test1(clsValuesLong);
	clsValuesLong.Print("After Test 1");

	// Test 2
	clsValuesLong.Print("Before Test 2");
	Test2(clsValuesLong);
	clsValuesLong.Print("After Test 2");

	CResizableArray<long> clsValuesLong2;

	// Create the array
	clsValuesLong2.SetSize(3);

	// Populate Array (value, index)
	clsValuesLong2[0] = 1;
	clsValuesLong2[1] = 2;
	clsValuesLong2[2] = 3;


	clsValuesLong2.Print("After SetSize(3)");
	// Append Array
	clsValuesLong2 += clsValuesLong2;

	clsValuesLong2.Print("After clsValuesLong2 += clsValuesLong2;");

	cout << "--Double Test Cases-------------------" << endl;

	CResizableArray<double> clsValuesDouble;

	// Create the array
	clsValuesDouble.SetSize(4);

	// Populate Array (value, index)
	clsValuesDouble[0] = 20.0;
	clsValuesDouble[1] = 40.0;
	clsValuesDouble[2] = 60.0;
	clsValuesDouble[3] = 70.80;

	clsValuesDouble.Print("After populate array 20.0, 40.0, 60.0, 70.80");

	// Test 1
	clsValuesDouble.Print("Before Test 1 (Double)");
	Test1(clsValuesDouble);
	clsValuesDouble.Print("After Test 1 (Double)");

	// Test 2
	clsValuesDouble.Print("Before Test 2 (Double)");
	Test2(clsValuesDouble);
	clsValuesDouble.Print("After Test 2 (Double)");

	CResizableArray<double> clsValuesDouble2;

	// Create the array
	clsValuesDouble2.SetSize(3);

	// Populate Array (value, index)
	clsValuesDouble2[0] = 1;
	clsValuesDouble2[1] = 2;
	clsValuesDouble2[2] = 3;


	clsValuesDouble2.Print("After SetSize(3)");
	// Append Array
	clsValuesDouble2 += clsValuesDouble2;

	clsValuesDouble2.Print("After clsValuesDouble2 += clsValuesDouble2;");


	cout << "--Characters Test Cases-------------------" << endl;

	CResizableArray<char> clsCharacters;

	// Create the array
	clsCharacters.SetSize(6);

	// Populate Array (value, index)
	clsCharacters[0] = 'h';
	clsCharacters[1] = 'e';
	clsCharacters[2] = 'l';
	clsCharacters[3] = 'l';
	clsCharacters[4] = 'o';
	clsCharacters[5] = '\0';

	clsCharacters.Print("After populate array h, e, l, l, o, 0");

	// Test 1
	clsCharacters.Print("Before Test 1");
	Test1(clsCharacters);
	clsCharacters.Print("After Test 1");

	// Test 2
	clsCharacters.Print("Before Test 2");
	Test2(clsCharacters);
	clsCharacters.Print("After Test 2");

	CResizableArray<char> clsCharacters2;

	// Create the array
	clsCharacters2.SetSize(3);

	// Populate Array (value, index)
	clsCharacters2[0] = 'h';
	clsCharacters2[1] = 'i';
	clsCharacters2[2] = '\0';


	clsCharacters2.Print("After SetSize(3)");
	// Append Array
	clsCharacters2 += clsCharacters2;

	clsCharacters2.Print("After clsValues2 += clsValues2;");

	return 0;
}



// --------------------------------------------------------------------------------
// Name: Test1
// Abstract: Pass by reference
// --------------------------------------------------------------------------------
template <typename GenericDataType>
void Test1(CResizableArray<GenericDataType>& clsValues)
{
	clsValues.Print("During Test 1");
}



// --------------------------------------------------------------------------------
// Name: Test2
// Abstract: Pass by value
// --------------------------------------------------------------------------------
template <typename GenericDataType>
void Test2(CResizableArray<GenericDataType> clsValues)
{
	clsValues.Print("During Test 2");
}