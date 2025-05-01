// --------------------------------------------------------------------------------
// Name: CNode
// Abstract: Class method definitions
// --------------------------------------------------------------------------------

// --------------------------------------------------------------------------------
// Includes
// --------------------------------------------------------------------------------
#include "CNode.h"


// --------------------------------------------------------------------------------
// Name: Constructor
// Abstract: Default Constructor
// --------------------------------------------------------------------------------
CNode::CNode()
{
	Initialize(0, 0);
}



// --------------------------------------------------------------------------------
// Name: Constructor
// Abstract: Parameterized Constructor
// --------------------------------------------------------------------------------
CNode::CNode(int intValue)
{
	Initialize(intValue, 0);
}



// --------------------------------------------------------------------------------
// Name: Constructor
// Abstract: Parameterized Constructor
// --------------------------------------------------------------------------------
CNode::CNode(int intValue, CNode* pclsNextNode)
{
	Initialize(intValue, pclsNextNode);
}



// --------------------------------------------------------------------------------
// Name: Copy Constructor
// Abstract: Called whenever passed by value
// --------------------------------------------------------------------------------
CNode::CNode(const CNode &clsOriginalToCopy)
{
	Initialize(0, 0);

	*this = clsOriginalToCopy;
}



	// --------------------------------------------------------------------------------
	// Name: Initialize
	// Abstract: Set all the class properties to a default value. 
	// --------------------------------------------------------------------------------
	void CNode::Initialize(int intValue, CNode* pclsNextNode)
	{
		SetValue(intValue);
		SetNextNode(pclsNextNode);
	}



// --------------------------------------------------------------------------------
// Name: operator=
// Abstract: Called when assigning data from one existing object to another
// --------------------------------------------------------------------------------
void CNode::operator=(const CNode& clsOriginalToCopy)
{
	// Self assignment? Compare instance's addresses
	if (this != &clsOriginalToCopy)
	{
		// No, copy
		CleanUp();
		ShallowCopy(clsOriginalToCopy);
	}
}



// --------------------------------------------------------------------------------
// Name: ShallowCopy
// Abstract: Copy values from orginal object
// -------------------------------------------------------------------------------- 
void CNode::ShallowCopy(const CNode& clsOriginalToCopy)
{
	m_pclsNextNode = clsOriginalToCopy.m_pclsNextNode;
	m_intValue = clsOriginalToCopy.m_intValue;
}



// --------------------------------------------------------------------------------
// Name: SetValue
// Abstract: Set the value
// --------------------------------------------------------------------------------
void CNode::SetValue(int intNewValue)
{
	m_intValue = intNewValue;
}



// --------------------------------------------------------------------------------
// Name: GetValue
// Abstract: Get the Value
// --------------------------------------------------------------------------------
int CNode::GetValue()
{
	return m_intValue;
}



// --------------------------------------------------------------------------------
// Name: SetNextNode
// Abstract: Set the next node
// --------------------------------------------------------------------------------
void CNode::SetNextNode(CNode* pclsNextNode)
{
	m_pclsNextNode = pclsNextNode;
}



// --------------------------------------------------------------------------------
// Name: GetNextNode
// Abstract: Get the next node
// --------------------------------------------------------------------------------
CNode* CNode::GetNextNode()
{
	return m_pclsNextNode;
}



// --------------------------------------------------------------------------------
// Name: Destructor
// Abstract: Destructor
// --------------------------------------------------------------------------------
CNode::~CNode()
{
	CleanUp();
}

	// --------------------------------------------------------------------------------
	// Name: CleanUp
	// Abstract: Delete any allocated memory
	// --------------------------------------------------------------------------------
	void CNode::CleanUp()
	{
		// No dynamically allocated memory
		// Here for consistency 
	}