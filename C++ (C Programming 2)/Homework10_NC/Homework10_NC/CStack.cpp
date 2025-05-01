// --------------------------------------------------------------------------------
// Name: CStack
// Abstract: Class method definitions
// --------------------------------------------------------------------------------

// --------------------------------------------------------------------------------
// Includes
// --------------------------------------------------------------------------------
#include "CStack.h"


// --------------------------------------------------------------------------------
// Name: Constructor
// Abstract: Default Constructor
// --------------------------------------------------------------------------------
CStack::CStack()
{
	Initialize();
}



// --------------------------------------------------------------------------------
// Name: Copy Constructor
// Abstract: Called whenever passed by value
// --------------------------------------------------------------------------------
CStack::CStack(const CStack& clsOriginalToCopy)
{
	Initialize();

	*this = clsOriginalToCopy;
}



	// --------------------------------------------------------------------------------
	// Name: Initialize
	// Abstract: Set all the class properties to a default value. 
	// --------------------------------------------------------------------------------
	void CStack::Initialize()
	{
		m_pclsHeadNode = 0;
	}



// --------------------------------------------------------------------------------
// Name: operator=
// Abstract: Called when assigning data from one existing object to another
// --------------------------------------------------------------------------------
void CStack::operator=(const CStack& clsOriginalToCopy)
{
	// Self assignment? Compare instance's addresses
	if (this != &clsOriginalToCopy)
	{
		// No, copy
		CleanUp();
		DeepCopy(clsOriginalToCopy);
	}
}



	// --------------------------------------------------------------------------------
	// Name: DeepCopy
	// Abstract: Because we have pointers to dynimically allocated memory
	//		  we must manually allocate duplicate blocks and copy all of the values
	//		  in the original blocks of memory to the copy instance. This is known
	//		  as a deep copy. The default behavior is a shallow copy.
	// --------------------------------------------------------------------------------
	void CStack::DeepCopy(const CStack& clsOriginalToCopy)
	{
		CNode* pclsNextNode = 0;
		CNode* pclsCurrentNode = 0;
		CNode* pclsNewNode = 0;

		// Copy Head Node
		m_pclsHeadNode = new CNode(clsOriginalToCopy.m_pclsHeadNode->GetValue());

		// Get Location of Next Node
		pclsNextNode = clsOriginalToCopy.m_pclsHeadNode->GetNextNode();

		// Set the current node to head node
		pclsCurrentNode = m_pclsHeadNode;

		// Copy Values
		while (pclsNextNode != 0)
		{
			// Allocate, Assign
			pclsNewNode = new CNode(pclsNextNode->GetValue());

			// Link
			pclsCurrentNode->SetNextNode(pclsNewNode);

			// Ready for next
			pclsCurrentNode = pclsNewNode;
			pclsNextNode = pclsNextNode->GetNextNode();
		}
	}



// --------------------------------------------------------------------------------
// Name: Push
// Abstract: Add a single node to the stack
// --------------------------------------------------------------------------------
void CStack::Push(int intValue)
{
	CNode* pclsNextNode;

	// Alocate, Assign & Link using constuctors
	CNode* pclsNewNode = new CNode(intValue, m_pclsHeadNode);

	// Ready for the next node
	m_pclsHeadNode = pclsNewNode;
}



// --------------------------------------------------------------------------------
// Name: Pop
// Abstract: Remove a single node to the stack
// --------------------------------------------------------------------------------
int CStack::Pop()
{
	int intValue = 0;
	CNode* pclsNextNode = 0;

	// Empty list
	if (isEmpty() == false)
	{
		// No, get value
		intValue = m_pclsHeadNode->GetValue();

		// Get next
		pclsNextNode = m_pclsHeadNode->GetNextNode();

		// Delete
		delete m_pclsHeadNode;
		m_pclsHeadNode = 0;

		// Move to next
		m_pclsHeadNode = pclsNextNode;

	}
	return intValue;
}



// --------------------------------------------------------------------------------
// Name: IsEmpty
// Abstract: Checks if the stack is empty
// --------------------------------------------------------------------------------
bool CStack::isEmpty() const
{
	bool blnIsEmpty = false;

	// Empty?
	if (m_pclsHeadNode == 0)
	{
		// Yes
		blnIsEmpty = true;
	}

	return blnIsEmpty;
}



// --------------------------------------------------------------------------------
// Name: Print
// Abstract: Displays all values in the stack
// --------------------------------------------------------------------------------
void CStack::Print() const
{
	Print("Print Stack");
}



// --------------------------------------------------------------------------------
// Name: Print
// Abstract: Displays all values in the stack with caption!
// --------------------------------------------------------------------------------
void CStack::Print(const char* pstrCaption) const
{
	CNode* pclsCurrentNode;
	CNode* pclsNextNode;
	int intIndex = 0;

	cout << pstrCaption << " -------------" << endl;

	// Start from the top of the stack
	pclsCurrentNode = m_pclsHeadNode;

	while (pclsCurrentNode != 0)
	{
		// Count
		intIndex += 1;

		// Display Current Value
		cout << "Value at node #" << intIndex << " is " <<
			pclsCurrentNode->GetValue() << endl;

		// Get next node
		pclsNextNode = pclsCurrentNode->GetNextNode();

		// Move to the next node
		pclsCurrentNode = pclsNextNode;

	}
	cout << endl;
}



// --------------------------------------------------------------------------------
// Name: Destructor
// Abstract: Destructor
// --------------------------------------------------------------------------------
CStack::~CStack()
{
	CleanUp();
}



	// --------------------------------------------------------------------------------
	// Name: CleanUp
	// Abstract: Delete any allocated memory
	// --------------------------------------------------------------------------------
	void CStack::CleanUp()
	{
		while (isEmpty() != true)
		{
			Pop();
		}
	}