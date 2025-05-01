// --------------------------------------------------------------------------------
// Name: CQueue
// Abstract: This class creates a queue of nodes
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

class CQueue
{
	// --------------------------------------------------------------------------------
	// Properties
	// --------------------------------------------------------------------------------
public:			// Never make public properties.  
	// Make protected or private with public get/set methods

protected:

private:
	CNode* m_pclsHeadNode;
	CNode* m_pclsTailNode;

	// --------------------------------------------------------------------------------
	// Methods
	// --------------------------------------------------------------------------------
public:
	// Default Constructor
	CQueue();

	// Copy constructor with deep copy! 
	CQueue(const CQueue& clsOriginalToCopy);

	// Destructor
	~CQueue();

	// Deep copy! 
	void operator=(const CQueue& clsOriginalToCopy);

	// Push/Pop Value
	void Push(int intValue);
	int  Pop();

	bool isEmpty() const;
	void Print() const;
	void Print(const char* pstrCaption) const;

protected:

private:
	void Initialize();	// Set class properties to zero.
	void DeepCopy(const CQueue& clsOriginalToCopy);
	void CleanUp();		// Delete the list
};
