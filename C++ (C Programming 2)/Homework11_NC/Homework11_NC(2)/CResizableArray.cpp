// --------------------------------------------------------------------------------
// Name: CResizableArray
// Abstract: Class method definitions
// --------------------------------------------------------------------------------

// --------------------------------------------------------------------------------
// Pre-compiler Directives
// --------------------------------------------------------------------------------
#ifndef CRESIZABLE_ARRAY_CPP
#define CRESIZABLE_ARRAY_CPP
// --------------------------------------------------------------------------------
// Includes
// --------------------------------------------------------------------------------
#include "CResizableArray.h"



// --------------------------------------------------------------------------------
// Name: Constructor
// Abstract: Default Constructor
// --------------------------------------------------------------------------------
template <typename GenericDataType>
CResizableArray<GenericDataType>::CResizableArray()
{
	Initialize(0, GenericDataType());
}



// --------------------------------------------------------------------------------
// Name: Constructor
// Abstract: Parameterized Constructor
// --------------------------------------------------------------------------------
template <typename GenericDataType>
CResizableArray<GenericDataType>::CResizableArray(long lngInitalSize)
{
	Initialize(lngInitalSize, GenericDataType());
}



// --------------------------------------------------------------------------------
// Name: Constructor
// Abstract: Parameterized Constructor
// --------------------------------------------------------------------------------
template <typename GenericDataType>
CResizableArray<GenericDataType>::CResizableArray(long lngInitalSize, GenericDataType gdtDefaultValue)
{
	Initialize(lngInitalSize, gdtDefaultValue);
}



// --------------------------------------------------------------------------------
// Name: Copy Constructor
// Abstract: Called whenever passed by value
// --------------------------------------------------------------------------------
template <typename GenericDataType>
CResizableArray<GenericDataType>::CResizableArray(const CResizableArray& clsOriginalToCopy)
{
	// Not necessary, but here for consistency
	Initialize(0, GenericDataType());

	DeepCopy(clsOriginalToCopy);
}



// --------------------------------------------------------------------------------
// Name: Initialize
// Abstract: Set all the class properties to a default value. 
// --------------------------------------------------------------------------------
template <typename GenericDataType>
void CResizableArray<GenericDataType>::Initialize(long lngInitalSize, GenericDataType gdtDefaultValue)
{
	m_pagdtValues =  0; 
	m_lngArraySize = 0;
}



// --------------------------------------------------------------------------------
// Name: operator=
// Abstract: Called when assigning data from one existing object to another
// --------------------------------------------------------------------------------
template <typename GenericDataType>
void CResizableArray<GenericDataType>::operator=(const CResizableArray& clsOriginalToCopy)
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
// Name: operator[] (CONST)
// Abstract: Called when assigning array elements to an object,
//			returns an object by value.
// --------------------------------------------------------------------------------
template <typename GenericDataType>
GenericDataType CResizableArray<GenericDataType>::operator[](long lngIndex) const
{
	if (lngIndex < 0) lngIndex = 0;
	if (lngIndex > m_lngArraySize - 1) lngIndex = m_lngArraySize - 1;

	return *(m_pagdtValues + lngIndex);

}



// --------------------------------------------------------------------------------
// Name: operator[]
// Abstract: Called when assigning array elements to an object,
//			Returns an object by reference 
// --------------------------------------------------------------------------------
template <typename GenericDataType>
GenericDataType& CResizableArray<GenericDataType>::operator [] (long lngIndex)
{
	if (lngIndex < 0) lngIndex = 0;
	if (lngIndex > m_lngArraySize) lngIndex = m_lngArraySize - 1;

	return *(m_pagdtValues + lngIndex);

}



// --------------------------------------------------------------------------------
// Name: operator+=
// Abstract: Appends original instance to the end of the current instance.
// --------------------------------------------------------------------------------
template <typename GenericDataType>
void CResizableArray<GenericDataType>::operator += (const CResizableArray& clsOriginalToAppend)
{
	long lngIndex = 0;
	GenericDataType* pagdtNewValues = 0;
	long lngOriginalIndex = 0;

	long lngOrginalArraySize = clsOriginalToAppend.GetSize(); // Get Original Array Size
	long lngCurrentArraySize = this->GetSize(); // Get Current Instance’s Array Size
	long lngNewArraySize = lngOrginalArraySize + lngCurrentArraySize; // Combine the two

	// Allocate new memory
	pagdtNewValues = new GenericDataType[lngNewArraySize];

	// Initalize
	for (lngIndex = 0; lngIndex < lngNewArraySize;lngIndex += 1)
	{
		*(pagdtNewValues + lngIndex) = GenericDataType();
	}

	// Add values from current instance
	for (lngIndex = 0; lngIndex < this->GetSize(); lngIndex += 1)
	{
		*(pagdtNewValues + lngIndex) = *(this->m_pagdtValues + lngIndex);
	}

	// Add values from original instance
	for (lngIndex = this->GetSize(); lngIndex < lngNewArraySize; lngIndex += 1)
	{
		*(pagdtNewValues + lngIndex) = *(clsOriginalToAppend.m_pagdtValues + lngOriginalIndex);
		lngOriginalIndex += 1;
	}

	// Free old memory from current instance
	delete[] this->m_pagdtValues;
	this->m_pagdtValues = 0;

	// Point current instance to new array
	this->m_pagdtValues = pagdtNewValues;

	// Update Array Size
	this->m_lngArraySize = lngNewArraySize;




}



// --------------------------------------------------------------------------------
// Name: DeepCopy
// Abstract: Because we have pointers to dynimically allocated memory
//		  we must manually allocate duplicate blocks and copy all of the values
//		  in the original blocks of memory to the copy instance. This is known
//		  as a deep copy. The default behavior is a shallow copy.
// --------------------------------------------------------------------------------
template <typename GenericDataType>
void CResizableArray<GenericDataType>::DeepCopy(const CResizableArray& clsOriginalToCopy)
{
	long lngIndex = 0;
	long lngArraySize = clsOriginalToCopy.m_lngArraySize;

	// Deep copy 
	m_pagdtValues = new GenericDataType[lngArraySize];

	for (lngIndex = 0; lngIndex < lngArraySize; lngIndex += 1)
		*(m_pagdtValues + lngIndex) = *(clsOriginalToCopy.m_pagdtValues + lngIndex);

	// Copies of values for non-pointers
	m_lngArraySize = lngArraySize;

}



// --------------------------------------------------------------------------------
// Name: SetSize
// Abstract: Set the array size 
// --------------------------------------------------------------------------------
template <typename GenericDataType>
void CResizableArray<GenericDataType>::SetSize(long lngNewSize)
{
	SetSize(lngNewSize, GenericDataType());
}



// --------------------------------------------------------------------------------
// Name: SetSize
// Abstract: Set the array size 
// --------------------------------------------------------------------------------
template <typename GenericDataType>
void CResizableArray<GenericDataType>::SetSize(long lngNewSize, GenericDataType gdtDefaultValue)
{
	GenericDataType* pagdtNewValues = 0;
	long lngIndex = 0;
	long lngStop = 0;
	long lngStart = 0;
	// Boundry check NewSize
	if (lngNewSize < 0) lngNewSize = 0;
	if (lngNewSize > 100000) lngNewSize = 100000;

	// Allocate new memory
	pagdtNewValues = new GenericDataType[lngNewSize];

	// Initalize new memory
	for (lngIndex = 0; lngIndex < lngNewSize;lngIndex += 1)
	{
		*(pagdtNewValues + lngIndex) = GenericDataType();
	}

	// Add Default Value
	if (lngNewSize != 0)
	{
		*(pagdtNewValues + 0) = gdtDefaultValue;
		lngStart += 1;
	}

	// Find stoping point for array
	if (lngNewSize < m_lngArraySize) lngStop = lngNewSize;
	else                             lngStop = m_lngArraySize;

	// Copy old values
	for (lngIndex = lngStart; lngIndex < lngStop;lngIndex += 1)
	{
		*(pagdtNewValues + lngIndex) = *(m_pagdtValues + lngIndex);
	}

	// Delete old array
	if (m_pagdtValues != 0)
	{
		delete[] m_pagdtValues;
		m_pagdtValues = 0;
	}

	// Assign new values
	m_pagdtValues = pagdtNewValues;

	// Assign new size
	m_lngArraySize = lngNewSize;

}



// --------------------------------------------------------------------------------
// Name: GetSize
// Abstract: Get the array size 
// --------------------------------------------------------------------------------
template <typename GenericDataType>
long CResizableArray<GenericDataType>::GetSize() const
{
	return m_lngArraySize;
}



// --------------------------------------------------------------------------------
// Name: SetValueAt
// Abstract: Set the value at a specified location
// --------------------------------------------------------------------------------
template <typename GenericDataType>
void CResizableArray<GenericDataType>::SetValueAt(GenericDataType gdtValue, long lngIndex)
{
	// Size not 0?
	if (m_lngArraySize > 0)
	{
		// Yes, boundry check the index
		if (lngIndex < 0) lngIndex = 0;
		if (lngIndex > m_lngArraySize - 1) lngIndex = m_lngArraySize - 1;

		// Set the value
		*(m_pagdtValues + lngIndex) = gdtValue;
	}
}



// --------------------------------------------------------------------------------
// Name: GetValueAt
// Abstract: Get a value based on the given index
// --------------------------------------------------------------------------------
template <typename GenericDataType>
GenericDataType CResizableArray<GenericDataType>::GetValueAt(long lngIndex) const
{
	GenericDataType gdtValue = GenericDataType();

	// Size not 0?
	if (m_lngArraySize > 0)
	{
		// Yes, boundry check the index
		if (lngIndex < 0) lngIndex = 0;
		if (lngIndex > m_lngArraySize - 1) lngIndex = m_lngArraySize - 1;

		// Get the value
		gdtValue = *(m_pagdtValues + lngIndex);
	}

	return gdtValue;
}



// --------------------------------------------------------------------------------
// Name: AddValueToFront
// Abstract: Add a given value to the front of the array
// --------------------------------------------------------------------------------
template <typename GenericDataType>
void CResizableArray<GenericDataType>::AddValueToFront(GenericDataType gdtValueToAdd)
{
	long lngIndex = 0;

	// Create a new array
	GenericDataType* pagdtNewValues = new GenericDataType[GetSize() + 1];


	// Add value to the front
	*(pagdtNewValues + 0) = gdtValueToAdd;

	// Copy values from old array to new array.
	for (lngIndex = 0; lngIndex < GetSize(); lngIndex += 1)
	{
		*(pagdtNewValues + lngIndex + 1) = *(m_pagdtValues + lngIndex);
	}

	// Delete old array, Prevent Memory Leaks.
	delete[] m_pagdtValues;
	m_pagdtValues = 0;

	// Point to new array in memory
	m_pagdtValues = pagdtNewValues;

	// Assign new size
	m_lngArraySize += 1;
}



// --------------------------------------------------------------------------------
// Name: AddValueToEnd
// Abstract: Add a given value to the end of the array
// --------------------------------------------------------------------------------
template <typename GenericDataType>
void CResizableArray<GenericDataType>::AddValueToEnd(GenericDataType gdtValueToAdd)
{
	long lngIndex = 0;

	// Create a new array
	GenericDataType* pagdtNewValues = new GenericDataType[GetSize() + 1];


	// Copy values from old array to new array.
	for (lngIndex = 0; lngIndex < GetSize(); lngIndex += 1)
	{
		*(pagdtNewValues + lngIndex) = *(m_pagdtValues + lngIndex);
	}

	// Add value to the end
	*(pagdtNewValues + lngIndex) = gdtValueToAdd;

	// Delete old array, Prevent Memory Leaks.
	delete[] m_pagdtValues;
	m_pagdtValues = 0;

	// Point to new array in memory
	m_pagdtValues = pagdtNewValues;

	// Assign new size
	m_lngArraySize += 1;
}



// --------------------------------------------------------------------------------
// Name: InsertValueAt
// Abstract: Add a given value from a given loction
// --------------------------------------------------------------------------------
template <typename GenericDataType>
void CResizableArray<GenericDataType>::InsertValueAt(GenericDataType gdtValue, long lngIndexToInsertAt)
{
	long lngIndex = 0;
	GenericDataType* pagdtNewValues = 0;
	// Boundry check the index
	if (lngIndexToInsertAt < 0) lngIndexToInsertAt = 0;
	if (lngIndexToInsertAt > m_lngArraySize) lngIndexToInsertAt = m_lngArraySize;

	// Create a new array
	pagdtNewValues = new GenericDataType[GetSize() + 1];

	// Copy 1st half of values from old array into new array
	for (lngIndex = 0; lngIndex < lngIndexToInsertAt; lngIndex += 1)
	{
		*(pagdtNewValues + lngIndex) = *(m_pagdtValues + lngIndex);
	}

	// Insert
	*(pagdtNewValues + lngIndexToInsertAt) = gdtValue;

	// Copy 2st half of values from old array into new array
	for (lngIndex = lngIndexToInsertAt; lngIndex < GetSize(); lngIndex += 1)
	{
		*(pagdtNewValues + lngIndex + 1) = *(m_pagdtValues + lngIndex);
	}

	// Delete old array
	delete[] m_pagdtValues;
	m_pagdtValues = 0;

	m_pagdtValues = pagdtNewValues; // Assign New Values to array 

	// Assign size
	m_lngArraySize += 1;

}



// --------------------------------------------------------------------------------
// Name: RemoveAt
// Abstract: Remove a value from a given loction
// --------------------------------------------------------------------------------
template <typename GenericDataType>
void CResizableArray<GenericDataType>::RemoveAt(long lngIndextoRemoveAt)
{
	long lngIndex = 0;
	GenericDataType* pagdtNewValues = 0;
	// Boundry check the index
	if (lngIndextoRemoveAt < 0) lngIndextoRemoveAt = 0;
	if (lngIndextoRemoveAt > m_lngArraySize - 1) lngIndextoRemoveAt = m_lngArraySize;

	// Create a new array
	GenericDataType* pagdtNewValues = new GenericDataType[GetSize() - 1];

	// Copy 1st half of values from old array into new array
	for (lngIndex = 0; lngIndex < lngIndextoRemoveAt; lngIndex += 1)
	{
		*(pagdtNewValues + lngIndex) = *(m_pagdtValues + lngIndex);
	}


	// Copy 2st half of values from old array into new array
	for (lngIndex = lngIndextoRemoveAt + 1; lngIndex < GetSize(); lngIndex += 1)
	{
		*(pagdtNewValues + lngIndex - 1) = *(m_pagdtValues + lngIndex);
	}

	// Delete old array
	delete[] m_pagdtValues;
	m_pagdtValues = 0;

	m_pagdtValues = pagdtNewValues; // Assign New Values to array 

	// Assign size
	m_lngArraySize -= 1;

}



// --------------------------------------------------------------------------------
// Name: Print
// Abstract: Print all the values
// --------------------------------------------------------------------------------
template <typename GenericDataType>
void CResizableArray<GenericDataType>::Print() const
{
	Print("Print Array");
}



// --------------------------------------------------------------------------------
// Name: Print
// Abstract: Print all the values
// --------------------------------------------------------------------------------
template <typename GenericDataType>
void CResizableArray<GenericDataType>::Print(const char* pstrCaption) const
{
	long lngIndex = 0;

	cout << pstrCaption << " ------------" << endl;

	if (m_lngArraySize > 0)
	{

		for (lngIndex = 0; lngIndex < m_lngArraySize; lngIndex += 1)
		{
			cout << "Location [" << lngIndex << "] = " << *(m_pagdtValues + lngIndex) << endl;
		}
	}
	else
	{
		cout << "Array Empty" << endl;
	}

	cout << endl;
	cout << endl;
}



// --------------------------------------------------------------------------------
// Name: Destructor
// Abstract: Destructor
// --------------------------------------------------------------------------------
template <typename GenericDataType>
CResizableArray<GenericDataType>::~CResizableArray()
{
	CleanUp();
}



// --------------------------------------------------------------------------------
// Name: CleanUp
// Abstract: Delete any allocated memory
// --------------------------------------------------------------------------------
template <typename GenericDataType>
void CResizableArray<GenericDataType>::CleanUp()
{
	if (m_pagdtValues != nullptr)
	{
		delete[] m_pagdtValues;
	}
}

#endif