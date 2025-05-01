// --------------------------------------------------------------------------------
// Name: CQueue
// Abstract: Class method definitions
// --------------------------------------------------------------------------------

// --------------------------------------------------------------------------------
// Includes
// --------------------------------------------------------------------------------
#include "CQueue.h"


// --------------------------------------------------------------------------------
// Name: Constructor
// Abstract: Default Constructor
// --------------------------------------------------------------------------------
CQueue::CQueue()
{
	Initialize();
}



// --------------------------------------------------------------------------------
// Name: Copy Constructor
// Abstract: Called whenever passed by value
// --------------------------------------------------------------------------------
CQueue::CQueue(const CQueue& clsOriginalToCopy)
{
	Initialize();

	*this = clsOriginalToCopy;
}



// --------------------------------------------------------------------------------
// Name: Initialize
// Abstract: Set all the class properties to a default value. 
// --------------------------------------------------------------------------------
void CQueue::Initialize()
{
	m_pclsHeadNode = 0;
	m_pclsTailNode = 0;
}



// --------------------------------------------------------------------------------
// Name: operator=
// Abstract: Called when assigning data from one existing object to another
// --------------------------------------------------------------------------------
void CQueue::operator=(const CQueue& clsOriginalToCopy)
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
void CQueue::DeepCopy(const CQueue& clsOriginalToCopy)
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
// Abstract: Add a single node to the Queue
// --------------------------------------------------------------------------------
void CQueue::Push(int intValue)
{
	CNode* pclsNewNode = 0;

	// Alocate and Assign using constuctor
	pclsNewNode = new CNode(intValue);

	// Empty List?
	if (isEmpty() == true)
	{
		// link
		m_pclsHeadNode = pclsNewNode;
		m_pclsTailNode = pclsNewNode;
	}
	else
	{
		//No, add to end... link
		m_pclsTailNode->SetNextNode(pclsNewNode);

		// Move to end... ready for next
		m_pclsTailNode = pclsNewNode;
	}

}



// --------------------------------------------------------------------------------
// Name: Pop
// Abstract: Remove a single node to the Queue
// --------------------------------------------------------------------------------
int CQueue::Pop()
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

		// Was that the last node in the list?
		if (isEmpty() == true)
		{
			// Yes, clear the tail node
			m_pclsTailNode = 0;
		}

	}
	return intValue;
}



// --------------------------------------------------------------------------------
// Name: IsEmpty
// Abstract: Checks if the stack is empty
// --------------------------------------------------------------------------------
bool CQueue::isEmpty() const
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
void CQueue::Print() const
{
	Print("Print Stack");
}



// --------------------------------------------------------------------------------
// Name: Print
// Abstract: Displays all values in the stack with caption!
// --------------------------------------------------------------------------------
void CQueue::Print(const char* pstrCaption) const
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
CQueue::~CQueue()
{
	CleanUp();
}



// --------------------------------------------------------------------------------
// Name: CleanUp
// Abstract: Delete any allocated memory
// --------------------------------------------------------------------------------
void CQueue::CleanUp()
{
	while (isEmpty() != true)
	{
		Pop();
	}
}