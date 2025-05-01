// --------------------------------------------------------------------------------
// Name: CStack
// Abstract: This class creates a stack of nodes
// --------------------------------------------------------------------------------

// --------------------------------------------------------------------------------
// Pre-compiler Directives
// --------------------------------------------------------------------------------
#pragma once		// Include this file only once even if referenced multiple times

// --------------------------------------------------------------------------------
// Includes
// --------------------------------------------------------------------------------
#include <stdlib.h>
#include <iostream>
#include "CNode.h"
using namespace std;

class CStack
{
	// --------------------------------------------------------------------------------
	// Properties
	// --------------------------------------------------------------------------------
public:			// Never make public properties.  
	// Make protected or private with public get/set methods

protected:

private:
	CNode* m_pclsHeadNode;

	// --------------------------------------------------------------------------------
	// Methods
	// --------------------------------------------------------------------------------
public:
	// Default Constructor
	CStack();

	// Copy constructor with deep copy! 
	CStack(const CStack& clsOriginalToCopy);

	// Destructor
	~CStack();

	// Deep copy! 
	void operator=(const CStack& clsOriginalToCopy);

	// Push/Pop Value
	void Push(int intValue);
	int  Pop();

	bool isEmpty() const;
	void Print() const;
	void Print(const char* pstrCaption) const;

protected:

private:
	void Initialize();	// Set class properties to zero.
	void DeepCopy(const CStack& clsOriginalToCopy);
	void CleanUp();		// Delete the list
};
