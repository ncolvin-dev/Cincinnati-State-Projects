// -------------------------------------------------------------------------------- 
// Name: Nicholas Colvin
// Class: C++
// Abstract: Final Project. This program will ... 
// -------------------------------------------------------------------------------- 
// -------------------------------------------------------------------------------- 
// Includes – built-in libraries of functions 
// -------------------------------------------------------------------------------- 
#define _CRT_SECURE_NO_WARNINGS
#include <iostream>
#include "CSuperString.h"
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
void ConstructorTests();
void ToBooleanTests();
void ToShortTests();
void ToIntegerTests();
void ToLongTests();
void ToFloatTests();
void ToDoubleTests();
void ConcatenateOperatorTests();
void ComparisonOperatorTests();
void OtherOperatorTests();
void FindIndexOfTests();
void StringUtilityFunctions01();
void StringUtilityFunctions02();
void Test1();
void Test2();

// -------------------------------------------------------------------------------- 
// Name: main 
// Abstract: This is where the program starts 
// -------------------------------------------------------------------------------- 
int main()
{
	cout << "--------------------------------------------------------------------------------" << endl;
	cout << "CSuperString Tests" << endl;
	cout << "--------------------------------------------------------------------------------" << endl;
	cout << endl;

	// #1 - Constructor, Assignment operators, deep copy, ToString and Print
	ConstructorTests();

	// #2 - ToBool, ToShort, ToInteger, ToFloat and ToDouble 
	ToBooleanTests();
	ToShortTests();
	ToIntegerTests();
	ToLongTests();
	ToFloatTests();
	ToDoubleTests();

	// #3 - Operator +=, Operator ==, Operator != , Operator <, Operator >, Operator >=, Operator <=, Operator <<, Operator >>
	ConcatenateOperatorTests();
	ComparisonOperatorTests();
	OtherOperatorTests();
	
	// #4 - FindFirstIndexOf, FindLastIndexOf 
	FindIndexOfTests();

	// #5 - ToUpperCase, ToLowerCase, TrimLeft, TrimRight, Trim, IsWhiteSpace, Reverse,
	//		Left, Right, Substring, Replace, Insert
	// NOTE: The caller MUST delete memory after calling these functions
	StringUtilityFunctions01();
	StringUtilityFunctions02();

	// #6 - Test1 and Test2
	Test1();
	Test2();

	// #7 - Double Call Problem
	cout << endl << endl;

	cout << "Double call problem\n" << endl;
	cout << "-----------------------------------------------------------------" << endl;
	CSuperString ssSource1("Test");
	printf("Left( 2 ): %s, Left( 4 ): %s\n", ssSource1.Left(2), ssSource1.Left(4));

	cout << endl << endl;

	cout << "--------------------------------------------------------------------------------" << endl;
	cout << " END OF TESTS" << endl;
	cout << "--------------------------------------------------------------------------------" << endl;

	return 0;
}

#pragma region ConstructorTests

// --------------------------------------------------------------------------------
// Name: ConstrutorTests
// Abstract: Test all the different parameterized constructors
// --------------------------------------------------------------------------------
void ConstructorTests()
{
	CSuperString ssSource1;
	CSuperString ssSource2("I Love Nova");
	CSuperString ssSource3a(true);
	CSuperString ssSource3b(false);
	CSuperString ssSource4('X');
	CSuperString ssSource5a( (short) SHRT_MIN);
	CSuperString ssSource5b( (short) SHRT_MAX);
	CSuperString ssSource6a( (int) INT_MIN);
	CSuperString ssSource6b( (int) INT_MAX);
	CSuperString ssSource7a( (long) LONG_MIN);
	CSuperString ssSource7b( (long) LONG_MAX);
	CSuperString ssSource8a( (float) FLT_MIN);
	CSuperString ssSource8b( (float) FLT_MAX);
	CSuperString ssSource9a( (double) DBL_MIN);
	CSuperString ssSource9b( (double) DBL_MAX);
	CSuperString ssSource10(ssSource2);

	cout << boolalpha;
	cout << "Constructors\n" << endl;
	cout << "-----------------------------------------------------------------" << endl;
	cout << " 1)  - Default     :  " << ssSource1.ToString() << endl;
	cout << " 2)  - char *      :  " << ssSource2.ToString() << endl;
	cout << " 3a) - bool        :  " << ssSource3a.ToString() << endl;
	cout << " 3b) - bool        :  " << ssSource3b.ToString() << endl;
	cout << " 4)  - char        :  " << ssSource4.ToString() << endl;
	cout << " 5a) - short       :  " << ssSource5a.ToString() << endl;
	cout << " 5b) - short       :  " << ssSource5b.ToString() << endl;
	cout << " 6a) - int         :  " << ssSource6a.ToString() << endl;
	cout << " 6b) - int         :  " << ssSource6b.ToString() << endl;
	cout << " 7a) - long        :  " << ssSource7a.ToString() << endl;
	cout << " 7b) - long        :  " << ssSource7b.ToString() << endl;
	cout << " 8a) - float       :  " << ssSource8a.ToString() << endl;
	cout << " 8b) - float       :  " << ssSource8b.ToString() << endl;
	cout << " 9a) - double      :  " << ssSource9a.ToString() << endl;
	cout << " 9b) - double      :  " << ssSource9b.ToString() << endl;
	cout << " 10) - SuperString :  " << ssSource10.ToString() << endl;
	cout << endl;
	cout << endl;

}
#pragma endregion



#pragma region To<DataType>Tests
// --------------------------------------------------------------------------------
// Name: ToBooleanTests
// Abstract: Test ToBoolean
// --------------------------------------------------------------------------------
void ToBooleanTests()
{
	CSuperString ssSource1a("true");
	CSuperString ssSource1b("false");
	CSuperString ssSource1c("Lorem ipsum dolor sit amet, consectetur adipiscing elit,");

	cout << boolalpha;

	cout << "ToBoolean\n" << endl;
	cout << "-----------------------------------------------------------------" << endl;
	cout << " 1a) - true           : " << ssSource1a.ToBoolean() << endl;
	cout << " 1b) - false          : " << ssSource1b.ToBoolean() << endl;
	cout << " 1c) - Lorem ipsum... : " << ssSource1c.ToBoolean() << endl;
	
	cout << endl;
	cout << endl;
}



// --------------------------------------------------------------------------------
// Name: ToShortTests
// Abstract: Test ToShort
// --------------------------------------------------------------------------------
void ToShortTests()
{
	CSuperString ssSource1a("32767");
	CSuperString ssSource1b("-32768");
	CSuperString ssSource1c("80000");
	CSuperString ssSource1d("-1 sed do eiusmod2");
	CSuperString ssSource1e("-99999999999999999999999999999999999999999");


	cout << "ToShort\n" << endl;
	cout << "-----------------------------------------------------------------" << endl;
	cout << " 1a) - 32767              : " << ssSource1a.ToShort() << endl;
	cout << " 1b) - -32768             : " << ssSource1b.ToShort() << endl;
	cout << " 1c) - 80000              : " << ssSource1c.ToShort() << endl;
	cout << " 1d) - -1 sed do eiusmod2 : " << ssSource1d.ToShort() << endl;
	cout << " 1e) - -999999999999...   : " << ssSource1e.ToShort() << endl;

	cout << endl;
	cout << endl;
}



// --------------------------------------------------------------------------------
// Name: ToIntegerTests
// Abstract: Test ToInteger
// --------------------------------------------------------------------------------
void ToIntegerTests()
{
	CSuperString ssSource1a("2147483647");
	CSuperString ssSource1b("-2147483648");
	CSuperString ssSource1c("-2800000000");
	CSuperString ssSource1d("-1tempor incididunt ut labore et2");
	CSuperString ssSource1e("-99999999999999999999999999999999999999999");

	cout << "ToInteger\n" << endl;
	cout << "-----------------------------------------------------------------" << endl;
	cout << " 1a) - 2147483647        : " << ssSource1a.ToInteger() << endl;
	cout << " 1b) - -2147483648       : " << ssSource1b.ToInteger() << endl;
	cout << " 1c) - -2800000000       : " << ssSource1c.ToInteger() << endl;
	cout << " 1d) - -1Lorem ipsum...  : " << ssSource1d.ToInteger() << endl;
	cout << " 1e) - -999999999999...  : " << ssSource1e.ToInteger() << endl;

	cout << endl;
	cout << endl;
}



// --------------------------------------------------------------------------------
// Name: ToLongTests
// Abstract: Test ToLong
// --------------------------------------------------------------------------------
void ToLongTests()
{
	CSuperString ssSource1a("2147483647");
	CSuperString ssSource1b("-2147483648");
	CSuperString ssSource1c("-2800000000");
	CSuperString ssSource1d("Excepteur sint occaecat2");
	CSuperString ssSource1e("-99999999999999999999999999999999999999999");

	cout << "ToLong\n" << endl;
	cout << "-----------------------------------------------------------------" << endl;
	cout << " 1a) - 2147483647       : " << ssSource1a.ToLong() << endl;
	cout << " 1b) - -2147483648      : " << ssSource1b.ToLong() << endl;
	cout << " 1c) - -2800000000      : " << ssSource1c.ToLong() << endl;
	cout << " 1d) - Lorem ipsum...   : " << ssSource1d.ToLong() << endl;
	cout << " 1e) - -999999999999... : " << ssSource1e.ToLong() << endl;

	cout << endl;
	cout << endl;
}



// --------------------------------------------------------------------------------
// Name: ToFloatTests
// Abstract: Test ToFloat
// --------------------------------------------------------------------------------
void ToFloatTests() 
{
	CSuperString ssSource1a("1.17549e-38");
	CSuperString ssSource1b("3.40282e+38");
	CSuperString ssSource1c("-2800000000");
	CSuperString ssSource1d("Excepteur sint occaecat2");
	CSuperString ssSource1e("-9999999999999999999999999999999999999999999999999999999999999999999999999999999999");


	cout << "ToFloat\n" << endl;
	cout << "-----------------------------------------------------------------" << endl;
	cout << " 1a) - 1.17549e-38      : " << ssSource1a.ToFloat() << endl;
	cout << " 1b) - 3.40282e+38      : " << ssSource1b.ToFloat() << endl;
	cout << " 1c) - -2800000000      : " << ssSource1c.ToFloat() << endl;
	cout << " 1d) - Lorem ipsum...   : " << ssSource1d.ToFloat() << endl;
	cout << " 1e) - -999999999999... : " << ssSource1e.ToFloat() << endl;

	cout << endl;
	cout << endl;
}



// --------------------------------------------------------------------------------
// Name: ToDoubleTests
// Abstract: Test ToDouble
// --------------------------------------------------------------------------------
void ToDoubleTests()
{
	CSuperString ssSource1a("2.22507e-308");
	CSuperString ssSource1b("1.79769e+308");
	CSuperString ssSource1c("1.8e+308");
	CSuperString ssSource1d("occaecat2");
	CSuperString ssSource1e("-9999999999999999999999999999999999999999999999999999999999999999999999999999999999");

	cout << "ToDouble\n" << endl;
	cout << "-----------------------------------------------------------------" << endl;

	cout << " 1a) - 2.22507e-308     : " << ssSource1a.ToDouble() << endl;
	cout << " 1b) - 1.79769e+308     : " << ssSource1b.ToDouble() << endl;
	cout << " 1c) - 1.8e+308         : " << ssSource1c.ToDouble() << endl;
	cout << " 1d) - Lorem ipsum...   : " << ssSource1d.ToDouble() << endl;
	cout << " 1e) - -999999999999... : " << ssSource1e.ToDouble() << endl;

	cout << endl;
	cout << endl;
}
#pragma endregion



#pragma region OperatorTests
// -------------------------------------------------------------------------------- 
// Name: ConcatenateOperatorTests 
// Abstract: Test Concatenate operator functions.
// -------------------------------------------------------------------------------- 
void ConcatenateOperatorTests()
{

	CSuperString ssSource1("I love Nova, ");
	CSuperString ssSource2("I love Ella, my dog!");
	CSuperString ssSource3("I love Freddy, my dog!");
	CSuperString ssSource4("I love Abby, my dog!");
	CSuperString ssSource5("Hello ");
	CSuperString ssSource6("World");
	CSuperString ssSource7("Hello Hello! ");
	CSuperString ssSource8(" World World!");
	ssSource1 += "my dog!";
	ssSource2 += '!';
	ssSource3 += ssSource3;
	ssSource4 += ssSource1;

	cout << "Concatenate Operater Tests\n" << endl;
	cout << "-----------------------------------------------------------------" << endl;
	cout << "Data Entered :" << endl
		 << "ssSource1    : 'I love Nova, '" << endl
		 << "ssSource2    : 'I love Ella, my dog!'" << endl
		 << "ssSource3    : 'I love Freddy, my dog'" << endl
		 << "ssSource4    : 'I love Abby, my dog!'" << endl
		 << "ssSource5    : 'Hello '" << endl
		 << "ssSource6    : 'World'" << endl
		 << "ssSource7    : 'Hello Hello! '" << endl
		 << "ssSource8    : ' World World!'" << endl;
	cout << "-----------------------------------------------------------------" << endl;
	cout << "1a) - ssSource1 += my Dog!    : " << ssSource1 << endl;
	cout << "1b) - ssSource2 += '!'        : " << ssSource2 << endl;
	cout << "1c) - ssSource3 += ssSource1c : " << ssSource3 << endl;
	cout << "1d) - ssSource4 += ssSource1a : " << ssSource4 << endl;
	cout << "2a) - ssSource5 + ssSource6   : " << ssSource5 + ssSource6 << endl;
	cout << "2b) - ssSource6 + ssSource6   : " << ssSource6 + ssSource6 << endl;
	cout << "2c) - ssSource7 + World       : " << ssSource7 + "World" << endl;
	cout << "2d) - Hello + ssSource8       : " << "Hello" + ssSource8 << endl;
	cout << "2e) - ssSource7 + '!'         : " << ssSource7 + '!' << endl;
	cout << "2f) - '!' + ssSource8         : " << '!' + ssSource8 << endl;

	cout << endl;
	cout << endl;

}



// -------------------------------------------------------------------------------- 
// Name: ComparisonOperatorTests 
// Abstract: Test Comparison operator functions.
// -------------------------------------------------------------------------------- 
void ComparisonOperatorTests()
{
	CSuperString ssSource1("Nova");
	CSuperString ssSource2('N');
	CSuperString ssSource3("Apple");
	CSuperString ssSource4("A");

	cout << boolalpha;
	cout << "Comparison Operator Tests\n" << endl;
	cout << "-----------------------------------------------------------------" << endl;
	cout << "Data Entered:" << endl
		<< "ssSource1  : 'Nova'" << endl
		<< "ssSource2  : 'N'" << endl
		<< "ssSource3  : 'Apple'" << endl
		<< "ssSource4  : 'A'" << endl;
	cout << "-----------------------------------------------------------------" << endl;
	cout << "1a) - ssSource1 == Nova       : " << (ssSource1 == "Nova") << endl;
	cout << "1b) - ssSource1 == nova       : " << (ssSource1 == "nova") << endl;
	cout << "1c) - ssSource2 == 'N'        : " << (ssSource2 == "N") << endl;
	cout << "1d) - ssSource2 == 'T'        : " << (ssSource2 == "T") << endl;
	cout << "1e) - ssSource1 == ssSource1  : " << (ssSource1 == ssSource1) << endl;
	cout << "1f) - ssSource1 == ssSource2  : " << (ssSource1 == ssSource2) << endl;
	cout << "2a) - ssSource3 != Apple      : " << (ssSource3 != "Apple") << endl;
	cout << "2b) - ssSource3 != apple      : " << (ssSource3 != "apple") << endl;
	cout << "2c) - ssSource4 != 'A'        : " << (ssSource4 != "A") << endl;
	cout << "2d) - ssSource4 != 'T'        : " << (ssSource4 != "T") << endl;
	cout << "2e) - ssSource1 != ssSource1  : " << (ssSource1 != ssSource1) << endl;
	cout << "2f) - ssSource1 != ssSource2  : " << (ssSource1 != ssSource2) << endl;
	cout << "3a) - ssSource1 >  Nova       : " << (ssSource1 > "Nova") << endl;
	cout << "3b) - ssSource1 >  Nova!      : " << (ssSource1 > "Nova!") << endl;
	cout << "3c) - ssSource3 >  'H'        : " << (ssSource3 > 'H') << endl;
	cout << "3e) - ssSource4 >  ssSource4  : " << (ssSource4 > ssSource4) << endl;
	cout << "3f) - ssSource3 >  ssSource4  : " << (ssSource3 > ssSource4) << endl;
	cout << "4a) - ssSource3 <  Apple      : " << (ssSource3 < "Apple") << endl;
	cout << "4b) - ssSource3 <  Apple!     : " << (ssSource3 < "Apple!") << endl;
	cout << "4c) - ssSource4 <  'W'        : " << (ssSource4 < 'W') << endl;
	cout << "4d) - ssSource1 <  ssSource1  : " << (ssSource1 < ssSource1) << endl;
	cout << "4e) - ssSource1 <  ssSource2  : " << (ssSource1 < ssSource2) << endl;
	cout << "5a) - ssSource1 >= Nova       : " << (ssSource1 >= "Nova") << endl;
	cout << "5b) - ssSource1 >= Nova!      : " << (ssSource1 >= "Nova!") << endl;
	cout << "5c) - ssSource2 >= 'O'        : " << (ssSource2 >= 'O') << endl;
	cout << "5d) - ssSource1 >= ssSource1  : " << (ssSource1 >= ssSource1) << endl;
	cout << "5e) - ssSource1 >= ssSource2  : " << (ssSource1 >= ssSource2) << endl;
	cout << "6a) - ssSource1 <= Nova       : " << (ssSource1 <= "Nova") << endl;
	cout << "6b) - ssSource1 <= Nova!      : " << (ssSource1 <= "Nova!") << endl;
	cout << "6c) - ssSource2 <= 'G'        : " << (ssSource2 <= 'G') << endl;
	cout << "6d) - ssSource1 <= ssSource1  : " << (ssSource1 <= ssSource1) << endl;
	cout << "6e) - ssSource1 <= ssSource2  : " << (ssSource1 <= ssSource2) << endl;

	cout << endl;
	cout << endl;
	
}



// -------------------------------------------------------------------------------- 
// Name: ComparisonOperatorTests 
// Abstract: Test all other operator functions.
// -------------------------------------------------------------------------------- 
void OtherOperatorTests()
{
	CSuperString ssSource1("This is a changeable string");
	CSuperString const ssSource2("This is a unchangeable string");
	CSuperString ssSource3("This is some random text");
	CSuperString ssSource4;

	cout << "Other Operator Tests\n" << endl;
	cout << "-----------------------------------------------------------------" << endl;
	cout << "Data Entered:" << endl
		<< "ssSource1       : 'This is a changeable string'" << endl
		<< "const ssSource2 : 'This is a unchangeable string'" << endl
	    << "ssSource3       : 'This is some random text'" << endl;
	cout << "-----------------------------------------------------------------" << endl;
	ssSource1[8] = 'A';
	cout << "1a) - ssSource1[8]   = 'A'    : " << ssSource1.ToString() << endl;
	ssSource1[-1] = 'H';
	cout << "1b) - ssSource1[-1]  = 'H'    : " << ssSource1.ToString() <<  endl;
	ssSource1[100] = 'G';
	cout << "1c) - ssSource1[100] = 't'    : " << ssSource1.ToString() << endl;
	ssSource1[2] = '\0';
	cout << "1d) - ssSource2[2]            : " << ssSource2[2] << endl;
	cout << "1e) - ssSource2[-1]           : " << ssSource2[-1] << endl;
	cout << "1f) - ssSource2[100]          : " << ssSource2[100] << endl;
	cout << "2)  - cout << ssSource3       : " << ssSource3 << endl;
	cout << "3)  - Please enter some text  : ";
	cin >> ssSource4;
	cout << "3)  - cin << ssSource4        : " << ssSource4.ToString() << endl;

	cout << endl;
	cout << endl;

	//friend ostream& operator << (ostream & osOut, const CSuperString & ssOutput);
	//friend istream& operator >> (istream & isIn, CSuperString & ssInput);
}

#pragma endregion



#pragma region FindIndexOfTests

// -------------------------------------------------------------------------------- 
// Name: FindIndexOfTests 
// Abstract: Test all the diffrent FindIndexOf Functions 
// -------------------------------------------------------------------------------- 
void FindIndexOfTests()
{
	CSuperString ssSource1("Ad litora torquent per conubia nostra inceptos per");


	cout << "FindIndexOf Tests\n" << endl;
	cout << "-----------------------------------------------------------------" << endl;
	cout << "Data Entered:" << endl
		 << "ssSource1: 'Ad litora torquent per conubia nostra inceptos per" << endl;
	cout << "-----------------------------------------------------------------" << endl;
	cout << "1a) - FindFirstIndexOf('n')       : " << ssSource1.FindFirstIndexOf('n') << endl;
	cout << "1b) - FindFirstIndexOf('n', 6)    : " << ssSource1.FindFirstIndexOf('i', 6) << endl;
	cout << "1c) - FindFirstIndexOf('per')     : " << ssSource1.FindFirstIndexOf("per") << endl;
	cout << "1d) - FindFirstIndexOf('per', 22) : " << ssSource1.FindFirstIndexOf("per", 22) << endl;
	cout << "1e) - FindFirstIndexOf('litora!') : " << ssSource1.FindFirstIndexOf("litora!") << endl;
	cout << "2a) - FindLastIndexOf('o')        : " << ssSource1.FindLastIndexOf('o') << endl;
	cout << "2b) - FindLastIndexOf('per')      : " << ssSource1.FindLastIndexOf("per") << endl;



	cout << endl;
	cout << endl;
}

#pragma endregion



#pragma region StringUtilityFunctions
// -------------------------------------------------------------------------------- 
// Name: StringUtilityFunctions01 
// Abstract: Test a large portion of string utilty functions
//     NOTE: The caller MUST delete memory after calling these functions
// -------------------------------------------------------------------------------- 
void StringUtilityFunctions01()
{
	CSuperString ssSource1("sunt in culpa qui officia");
	CSuperString ssSource2("               Excepteur sint               ");
	CSuperString ssSource3("Excepteur sint occaecat cupidatat non proident");
	CSuperString ssSource4("                                     ");
	CSuperString ssSource5;
	const char* strTest01;
	const char* strTest02;
	const char* strTest03a;
	const char* strTest03b;
	const char* strTest04a;
	const char* strTest04b;
	const char* strTest05a;
	const char* strTest05b;
	const char* strTest06a;
	const char* strTest06b;
	const char* strTest07;
	const char* strTest08;


	cout << "StringUtilityFunctions01\n" << endl;
	cout << "-----------------------------------------------------------------" << endl;
	cout << "Data Entered:" << endl
		 << "ssSource1: 'sunt in culpa qui officia'" << endl
		 << "ssSource2: '               Excepteur sint               '" << endl
		 << "ssSource3: 'Excepteur sint occaecat cupidatat non proident'" << endl
	     << "ssSource4: '                                     '" << endl
		 << "ssSource5: '(empty string)'" << endl;
	cout << "-----------------------------------------------------------------" << endl;
	cout << "1)  - strTest01  = ssSource1.ToUpperCase : " << (strTest01 = ssSource1.ToUpperCase()) << endl;
	cout << "2)  - strTest02  = ssSource1.ToLowerCase : " << (strTest02 = ssSource1.ToLowerCase()) << endl;
	cout << "3a) - strTest03a = ssSource2.TrimLeft    : " << (strTest03a = ssSource2.TrimLeft()) << endl;
	cout << "3b) - strTest03b = ssSource4.TrimLeft    : " << (strTest03b = ssSource4.TrimLeft()) << endl;
	cout << "4a) - strTest04a = ssSource2.TrimRight   : " << (strTest04a = ssSource2.TrimRight()) << endl;
	cout << "4b) - strTest04b = ssSource4.TrimRight   : " << (strTest04b = ssSource4.TrimRight()) << endl;
	cout << "5a) - strTest05a = ssSource2.Trim        : " << (strTest05a = ssSource2.Trim()) << endl;
	cout << "5b) - strTest05b = ssSource4.Trim        : " << (strTest05b = ssSource4.Trim()) << endl;
	cout << "6)  - strTest06a = ssSource1.Reverse     : " << (strTest06a = ssSource1.Reverse()) << endl;
	cout << "6)  - strTest06b = ssSource5.Reverse     : " << (strTest06b = ssSource5.Reverse()) << endl;
	cout << "7)  - strTest07  = ssSource1.Left(7)     : " << (strTest07 = ssSource1.Left(7)) << endl;
	cout << "8)  - strTest08  = ssSource1.Right(7)    : " << (strTest08 = ssSource1.Right(7)) << endl;

	// Memory Leak....
	//printf("Left( 2 ): %s\n", ssSource1.Left(2));
	//printf("Left( 2 ): %s, Left( 4 ): %s\n", ssSource1.Left(2), ssSource1.Left(4));

	cout << endl;
	cout << endl;
}



// -------------------------------------------------------------------------------- 
// Name: StringUtilityFunctions02 
// Tested Functions: Replace, Substring, Insert
// NOTE: The caller MUST delete memory after calling these functions
// -------------------------------------------------------------------------------- 
void StringUtilityFunctions02()
{
	CSuperString ssSource1("I Love Spy X Family and I Love Fairy Tale");
	const char* strTest01a;
	const char* strTest01b;
	const char* strTest01c;
	const char* strTest02a;
	const char* strTest02b;
	const char* strTest02c;
	const char* strTest03a;
	const char* strTest03b;
	const char* strTest03c;


	cout << "StringUtilityFunctions02\n" << endl;
	cout << "-----------------------------------------------------------------" << endl;
	cout << "Data Entered:" << endl
		 << "ssSource1: 'I Love Spy X Family and I Love Fairy Tale'" << endl;
	cout << "-----------------------------------------------------------------" << endl;
	cout << "1a) - ... = ssSource1.Replace('I', '1')              : " << (strTest01a = ssSource1.Replace('I', '1')) << endl;
	cout << "1b) - ... = ssSource1.Replace('Love', 'Really Love') : " << (strTest01b = ssSource1.Replace("Love", "Really Love")) << endl;
	cout << "1c) - ... = ssSource1.Replace('Love', '')            : " << (strTest01c = ssSource1.Replace("Love", "")) << endl;
	cout << "2a) - ... = ssSource1.Insert('!', '100')             : " << (strTest02a = ssSource1.Insert('!', 100)) << endl;
	cout << "2b) - ... = ssSource1.Insert('Love ', '2')           : " << (strTest02b = ssSource1.Insert("Love ", 2)) << endl;
	cout << "2c) - ... = ssSource1.Insert('Do ', '-1')            : " << (strTest02c = ssSource1.Insert("Do ", -1)) << endl;
	cout << "3a) - ... = ssSource1.Substring('2', '4')            : " << (strTest03a = ssSource1.Substring(2, 4)) << endl;
	cout << "3b) - ... = ssSource1.Substring('1000', '-1')        : " << (strTest03b = ssSource1.Substring(1000, -1)) << endl;
	cout << "3c) - ... = ssSource1.Substring('-1', '1000')        : " << (strTest03c = ssSource1.Substring(-1, 1000)) << endl;

	cout << endl;
	cout << endl;
}

#pragma endregion



// -------------------------------------------------------------------------------- 
// Name: Test1 
// Abstract: cout << test
// -------------------------------------------------------------------------------- 
void Test1()
{
	CSuperString ssTest("Test 1");
	cout << "Test #1: " << ssTest << endl;
}



// -------------------------------------------------------------------------------- 
// Name: Test2
// Abstract: Replace char* test
// --------------------------------------------------------------------------------
void Test2()
{
	CSuperString ssTest = "I Love Star Wars and I Love Star Trek";

	ssTest = ssTest.Replace("Love", "Really Love Love");

	cout << "Test #2: " << ssTest << endl;
}




