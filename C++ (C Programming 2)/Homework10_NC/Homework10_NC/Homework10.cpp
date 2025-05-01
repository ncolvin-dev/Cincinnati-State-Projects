// -------------------------------------------------------------------------------- 
// Name: Nicholas Colvin
// Class: C++
// Abstract: Homework 10. This program will create stacks and queues with classes
// -------------------------------------------------------------------------------- 
// -------------------------------------------------------------------------------- 
// Includes – built-in libraries of functions 
// -------------------------------------------------------------------------------- 
#define _CRT_SECURE_NO_WARNINGS
#include <iostream>
#include "CNode.h"
#include "CStack.h"
#include "CQueue.h"
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
void Test1(CStack clsStack);
void Test2(CQueue clsQueue);
// -------------------------------------------------------------------------------- 
// Name: main 
// Abstract: This is where the program starts 
// -------------------------------------------------------------------------------- 
int main()
{
	cout << "-- Test Cases for CStack ----------------------------" << endl << endl;
	
	CStack clsStack;

	clsStack.Pop();

	clsStack.Print("Before Push: 20, 30, 40, 50");
	clsStack.Push(20);
	clsStack.Push(30);
	clsStack.Push(40);
	clsStack.Push(50);
	clsStack.Print("After Push: 20, 30, 40, 50");

	
	clsStack.Pop();
	clsStack.Print("After Pop");
	
	clsStack.Print("Before Pass by value");

	//Pass By Value 
	Test1(clsStack);

	clsStack.Print("After Pass by value");

	cout << "-- Test Cases for CQueue ----------------------------" << endl << endl;

	CQueue clsQueue;

	clsQueue.Print("Before Push: 5, 10, 15, 20");
	clsQueue.Push(5);
	clsQueue.Push(10);
	clsQueue.Push(15);
	clsQueue.Push(20);
	clsQueue.Print("After Push: 5, 10, 15, 20");

	clsQueue.Pop();
	clsQueue.Print("After Pop");

	Test2(clsQueue);

	clsQueue.Print("After Pass by value");

	return 0;
}



// --------------------------------------------------------------------------------
// Name: Test1
// Abstract: Pass by value for stack
// --------------------------------------------------------------------------------
void Test1(CStack clsStack)
{
	clsStack.Print("During pass by value");
}



// --------------------------------------------------------------------------------
// Name: Test2
// Abstract: Pass by value for queue
// --------------------------------------------------------------------------------
void Test2(CQueue clsQueue)
{
	clsQueue.Print("During pass by value");
}