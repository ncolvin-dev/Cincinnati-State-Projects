// --------------------------------------------------------------------------------
// Name: CNode
// Abstract: This class creates a node for a stack or queue
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
using namespace std;

class CNode
{
	// --------------------------------------------------------------------------------
	// Properties
	// --------------------------------------------------------------------------------
public:			// Never make public properties.  
	// Make protected or private with public get/set methods

protected:

private:
	int m_intValue;
	CNode* m_pclsNextNode;

	// --------------------------------------------------------------------------------
	// Methods
	// --------------------------------------------------------------------------------
public:
	// Default Constructor
	CNode();

	// Parameterized constructor #1
	CNode(int intValue);

	// Parameterized constructor #2
	CNode(int intValue, CNode* pclsNextNode);

	// Copy constructor with shallow copy! 
	CNode(const CNode& clsOriginalToCopy);

	// Destructor
	~CNode();

	// Shallow copy! 
	void operator=(const CNode& clsOriginalToCopy);


	// Set/Get Value
	void SetValue(int intNewValue);
	int GetValue();

	// Set/Get Next Node
	void SetNextNode(CNode* pclsNextNode);
	CNode* GetNextNode();

protected:
	
private:
	void ShallowCopy(const CNode& clsOriginalToCopy);
	void CleanUp();
	void Initialize(int intValue, CNode* pclsNextNode);
};
